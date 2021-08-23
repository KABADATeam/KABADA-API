using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
  public abstract class CsvLoader {
    public Action<string> infoReporter;
    public Action<string> errorReporter;
    public TimeSpan bellInterval=new TimeSpan(0, 15, 0);

    protected int errors=0;
    protected string _file="";
    protected CsvReader rdr;
    protected long statInputDatarecords=0;
    protected DateTime statStartTime;
    protected DateTime statEndTime;
    protected long statRejectedDatarecords=0;

    protected virtual void info(string txt){
      if(infoReporter!=null)
        infoReporter(txt);
      }

    protected virtual void error(string txt){
      errors++;
      if(errorReporter==null)
        info(txt);
       else
        errorReporter(txt);
      }

    protected virtual void csv_ParseError(object sender, ParseErrorEventArgs e) {
      // if the error is that a field is missing, then skip to next line
      if (e.Error is MissingFieldCsvException) {
        error(e.Error.Message+"--MISSING FIELD ERROR OCCURRED!");
        e.Action = ParseErrorAction.AdvanceToNextLine;
       }  else if (e.Error is MalformedCsvException) {
        error("--MALFORMED CSV ERROR OCCURRED!");
        // Logger.Error(e.Error);
        error(e.Error.Message+"--MALFORMED CSV ERROR OCCURRED!");
        e.Action = ParseErrorAction.AdvanceToNextLine;
       }  else {
        error(e.Error.Message+"--UNKNOWN PARSE ERROR OCCURRED!");
        e.Action = ParseErrorAction.AdvanceToNextLine;
        }
      }

    protected virtual void processRowObject(object me) {}

    protected virtual object storeRow(){ throw new NotImplementedException(this.GetType().Name+".storeRow"); }

    protected virtual void loadInternal(string fullFilePath, bool hasHeaders=true) {
      statStartTime=DateTime.Now;
      info(string.Format("{0} Started load of the '{1}'.", statStartTime, fullFilePath));
      if (File.Exists(fullFilePath)==false)
        throw new Exception("The input file '"+fullFilePath+"' does not exist.");
      var toBell=DateTime.Now.Add(bellInterval);
      using(var sr = new StreamReader(fullFilePath, System.Text.Encoding.Default, true)){
        using (rdr = new CsvReader(sr
                  , hasHeaders // has headers
                  , ';'  // field delimiter
                  , '"'  // quote           , '\0' // Set quote char to '\0' to ignore quoted characters
                  , '\0' // escape
                  , '#'  // comment
                  , ValueTrimmingOptions.UnquotedOnly)) {
          rdr.SkipEmptyLines = true;
          rdr.MissingFieldAction = MissingFieldAction.ParseError;
          rdr.DefaultParseErrorAction = ParseErrorAction.RaiseEvent;
          rdr.ParseError += csv_ParseError;
          while (rdr.ReadNextRecord()){
            if (DateTime.Now>toBell) {
              bell("Processing row "+(rdr.CurrentRecordIndex+2).ToString()+".");
              toBell=DateTime.Now.Add(bellInterval);
              }
            statInputDatarecords++;
            if (rdr.ParseErrorFlag) { 
              logRowError("parse error");
              statRejectedDatarecords++;
              continue;
              }
            try {
              var b=storeRow();
              if (b!=null)
                processRowObject(b);
              }
            //catch (MyException e) {
            //  logRowError(conMessage(e, true));
            //  statRejectedDatarecords++;
            //  }
            catch (Exception e) {
              logRowError(conMessage(e));
              statRejectedDatarecords++;
              }
            } // while ReadNextRecord
//        processBuffer();
          } // CsvReader
        } // StreamReader
       statEndTime=DateTime.Now;
       info(string.Format("{0} Ended load. Duration={1}.", statEndTime, statEndTime-statStartTime));
//     statReport();
      }


    protected virtual void bell(string txt){ info(txt); }

    protected virtual void logRowError(string text, long? row = null) {
      var m = string.Format("{1}[{2}]: {0}.", text, _file, row==null ? rdr.CurrentRecordIndex+2 : row.Value);
      error(m);
      }

    internal static string conMessage(Exception e, bool skipTrace = false) {
      var u = e;
      var m = "";
      var dlm = "";
      while (u!=null) {
        m+=dlm+u.Message;
        u=u.InnerException;
        dlm="; ";
        }
      if (skipTrace==false)
        m+=" "+e.StackTrace;
      return m;
      }

    protected string yOstring(string key) {
      var w = rdr[key];
      if (string.IsNullOrEmpty(w))
        return null;
      return w;
      }

    protected string yMstring(string key) {
      var w = yOstring(key);
      if (w==null)
        throw new Exception(string.Format("Missing mandatory '"+key+"'"));
      return w;
      }

    public static float Yfloat(string txt){
      var r=float.Parse(txt, CultureInfo.InvariantCulture);
      return r;
      }

    protected float? yOfloat(string key) {
      var w = yOstring(key);
      if (w==null)
        return null;
      return Yfloat(w);
      //var r=float.Parse(w, CultureInfo.InvariantCulture);
      //return r;
      }

    protected float yMfloat(string key) {
      var w = yOfloat(key);
      if (w==null)
        throw new Exception(string.Format("Missing mandatory '"+key+"'"));
      return w.Value;
      }

    protected bool? yObool(string key) {
      var w = yOstring(key);
      if (w==null)
        return null;
      if(w=="+")
        return true;
      if(w.ToLower()=="true")
        return true;
      return false;
      }

    protected bool yMbool(string key) {
      var w=yObool(key);
      if(w==null)
        return false;
      return w.Value;
      }

    protected string z(float v){ return v.ToString(CultureInfo.InvariantCulture); }
 
    protected string z(string v){ return v; }

    protected string z(bool v){ return v?"+":""; }

    protected long? yOlong(string key) {
      var w = yOstring(key);
      if (w==null)
        return null;
      var r=long.Parse(w, CultureInfo.InvariantCulture);
      return r;
      }

    protected long yMlong(string key) {
      var w = yOlong(key);
      if (w==null)
        throw new Exception(string.Format("Missing mandatory '"+key+"'"));
      return w.Value;
      }

    protected byte yMbyte(string key) { return (byte)yMlong(key); }
    protected byte? yObyte(string key) {
      var t=yOlong(key);
      if(t==null)
        return null;
      return (byte)t.Value;
      }

    protected int yMint(string key) { return (int)yMlong(key); }
    protected int? yOint(string key) {
      var t=yOlong(key);
      if(t==null)
        return null;
      return (int)t.Value;
      }
    }
  }
