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
      var t="id;title;kind;master;";
      for(var m=0; m<mam; m++) t+=m.ToString()+";";
      using(var os=new StreamWriter(filePath, false, System.Text.Encoding.UTF8)){
        os.WriteLine(t);
        foreach(var o in rows){
          t=$"{o.id};{o.title};{o.kind.ToString()};{o.master};";
          var n=o.data.Count;
          for(var m=0; m<n; m++)
            t+=o.data[m].ToString()+";";
          os.WriteLine(t);
          }
        os.Close();
        }
      }
    }
  }
