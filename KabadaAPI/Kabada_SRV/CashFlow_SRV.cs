using KabadaAPI;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kabada {
  partial class CashFlow {
    protected void empty(List<string> csv){
      var l="";
      csv.Add(l);
      for(var i=0; i<27; i++)
        lA(ref l, "");
      }

    protected void addRow(List<string> csv, CashFlowRow row=null){
      var l="";
      csv.Add(l);
      lA(ref l, title(row));
      for(var m=0; m<13; m++)
        lA(ref l, month(m, row));
      lA(ref l, tote1(row));
      for(var m=13; m<25; m++)
        lA(ref l, month(m, row));
      lA(ref l, tote2(row));
      }

    private string tote1(CashFlowRow row) {
      if(row==null)
        return "Total (Year 1)";
      return deco(row.totalYear1);
      }

    private string tote2(CashFlowRow row) {
      if(row==null)
        return "Total (Year 2)";
      return deco(row.totalYear2);
      }

    private string month(int m, CashFlowRow row) { return row==null?m.ToString():moval(row, m); }

    private string moval(CashFlowRow row, int m) { return deco(row.mv(m)); }

    private string deco(decimal? v) { return v==null?"":v.ToString(); }

    private string title(CashFlowRow row) { return row==null?"Title":row.title; }

    private void lA(ref string l, string v) { l+=(v==null?"":v)+";"; }

    public List<string> toCSV(){
      var r=new List<string>();
      addRow(r);
      addRows(r, this.initialRevenue);
      addRows(r, this.salesForecast);
      addRows(r, this.investments);
      addRows(r, this.variableCosts);
      addRows(r, this.fixedCosts);
      return r;
      }

    private void addRows(List<string> r, CashFlowTable table) {
      if(table==null)
        return;
      addRows(r, table.rows);
      addRows(r, table.summaries);
      }

    private void addRows(List<string> r, List<CashFlowRow> rows) {
      if(rows==null)
        return;
      foreach(var o in rows)
        addRow(r, o);
      }

    public void snapMe(){
      var csv=toCSV();
      var filename=$"CashFlow-{DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss")}.csv";
      var path = Directory.GetCurrentDirectory(); 
      var opa=Path.Combine(path, "Logs",filename);
      using(var os=new StreamWriter(opa, false, System.Text.Encoding.UTF8)){
        foreach(var o in csv)
          os.WriteLine(o);
        os.Close();
        }
      }
    }
  }
