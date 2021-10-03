using System.Collections.Generic;

namespace KabadaAPI {
  public class MonthedDataRow : List<decimal?> {
    public MonthedDataRow() {}

    public MonthedDataRow(int monthes) : this() {
      for(var i=Count; i<monthes; i++)  Add(null);
      }

    public MonthedDataRow(IEnumerable<decimal?> data) : this() { set(data); }

    public void set(IEnumerable<decimal?> data) {
      var n=Count;
      var i=0;
      foreach(var o in data)
        if(i<n) this[i]=o;
         else   Add(o);
        i++;
      }

    

    }
  }
