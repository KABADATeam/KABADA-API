using Kabada;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class MonthedCatalog {
    protected List<MonthedCatalogRow> rows;

    public MonthedCatalog() { rows=new List<MonthedCatalogRow>(); }

    public MonthedCatalogRow add(CatalogRowKind kind, string title=null, MonthedDataRow data=null){
      var o=new MonthedCatalogRow(rows.Count+2, title, data){ kind=kind };
      rows.Add(o);
      return o;
      }

    public MonthedCatalogRow get(int id){ return rows[id-2]; }

    internal void snapMe(string filePath) {
      var mam=1;
      if(rows.Count>0)
        mam=rows.Select(x=>x.data.Count).Max();
      var t="title;kind;";
      for(var m=0; m<mam; m++) t+=m.ToString()+";";
      t+="id;master;";
      using(var os=new StreamWriter(filePath, false, System.Text.Encoding.UTF8)){
        os.WriteLine(t);
        foreach(var o in rows){
          t=$"{o.title};{o.kind.ToString()};";
          var n=o.data.Count;
          for(var m=0; m<n; m++)
            t+=o.data[m].ToString()+";";
          for(var m=n;m<mam;m++)t+=";";
          t+=$"{o.id};{o.master};";
          os.WriteLine(t);
          }
        os.Close();
        }
      }

    public CashFlowRow expose(int rowId, int lastMonth){ return get(rowId).expose(lastMonth); }

    public MonthedCatalogRow plus(CatalogRowKind kind, string title=null, params int[] rows){
      var r=add(kind, title, new MonthedDataRow());
      for(int i=0; i<rows.Length; i++){
        if(rows[i]<2)
          continue;
        var t=get(rows[i]).data;
        for(var m=0; m<t.Count && m<r.data.Count; m++){
          r.data[m]=NZ.Np( r.data[m],  t[m]);
          }
        for(var m=r.data.Count; m<t.Count; m++)
          r.data.Add(t[m]);
        }
      return r;
      }
    }
  }
