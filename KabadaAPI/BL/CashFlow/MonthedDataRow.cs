using System.Collections.Generic;

namespace KabadaAPI {
  public class MonthedDataRow : List<decimal?> {
    public MonthedDataRow() {}

    public MonthedDataRow(int monthes) : this() {
      for(var i=Count; i<monthes; i++)  Add(null);
      }

    public MonthedDataRow(IEnumerable<decimal?> data) : this() { set(data); }

    public MonthedDataRow(decimal? startup) : this(new List<decimal?>(){ startup}) {}

    public void set(IEnumerable<decimal?> data) {
      var n=Count;
      var i=0;
      foreach(var o in data)
        if(i<n) this[i]=o;
         else   Add(o);
        i++;
      }

    public List<decimal?> range(int startPosition, int? endPosition=null){ return NZ.range(this,startPosition, endPosition); }    

    public decimal? get(int month){
      if(month>=0 && month<Count)
        return this[month];
      return null;
      }

    public MonthedDataRow window(int projectSize, bool keepPostAsIs) {
      var t=range(0, projectSize);
      if(keepPostAsIs)
        t.Add(get(projectSize+1));
       else {
        var tail=range(projectSize+1);
        var s=NZ.Np(tail);
        if(s!=null)
          t.Add(s);
        }

      while(t.Count>1){
        var k=t.Count-1;
        if(t[k]!=null)
          break;
        t.RemoveAt(k);
        }
      return new MonthedDataRow(t);
      }    
    }
  }
