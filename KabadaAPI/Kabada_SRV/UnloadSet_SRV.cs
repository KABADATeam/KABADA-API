using Newtonsoft.Json;
using System;
using System.IO;

namespace Kabada {
  partial class UnloadSet {
    public string outfile;

    public UnloadSet(){ elements=new System.Collections.Generic.List<UnloadSetElement>(); }

    internal void regIt(Guid id, object o) {
      var t=new UnloadSetElement(){ id=id, type=o.GetType().Name, contents=JsonConvert.SerializeObject(o, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })  };
      elements.Add(t);
      }

    private string t(string name){
      var p=GetType().GetProperty(name);
      var v=p.GetValue(this, null);
      return (string)v;
      }

    internal void toCSV(string filePath=null) {
      var fp=filePath;
      if(string.IsNullOrWhiteSpace(fp))
        fp=this.outfile;
      var t="id;type;contents;";
      using(var os=new StreamWriter(fp, false, System.Text.Encoding.UTF8)){
        os.WriteLine(t);

        var ps=GetType().GetProperties();
        foreach(var p in ps){
          var w=p.GetValue(this, null);
          var v=(string)w;
          t=$"{p.Name};$;{v};";
          os.WriteLine(t);
          }

        foreach(var o in elements){
          t=$"{o.id};{o.type};{o.contents};";
          os.WriteLine(t);
          }
        os.Close();
        }
      }
    }
  }
