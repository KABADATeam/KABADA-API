using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
  public abstract class NZ {
    public static int Z(int? x, int defaultValue=0){ return (x==null)?defaultValue:x.Value; }
    public static decimal Z(decimal? x, decimal defaultValue=0m){ return (x==null)?defaultValue:x.Value; }

    public static decimal? N(decimal? x, decimal defaultValue=0m){ return (x==null || x==defaultValue)?null:x; }

    protected static Func<decimal, decimal> r = x => decimal.Round(x,2);
    public static Func<decimal?, decimal?>  Nr = x => (x==null)?x:r(x.Value);
    public static Func<decimal?, decimal>   Zr = x => r(Z(x));

    public static List<decimal?> range(List<decimal?> x, int startPosition, int? endPosition=null){
      var r=new List<decimal?>();
      if(x!=null){
        var n=x.Count;
        var s=(startPosition<0)?0:startPosition;
        if(s<n){
          var e=(endPosition==null || endPosition.Value>=n)?n-1:endPosition.Value;
          var l=e-s+1;
          if(l>0)
            r=x.GetRange(s, l);
          }
        }
      return r;
      }

     protected static Func<decimal, decimal, decimal> p = (x,y) => x+y;

     public static decimal Zp(decimal? x, decimal? y){ return p(Z(x), Z(y));}
     public static decimal Zp(IEnumerable<decimal?> x){
       return (x==null)?0m:x.Where(y=>y!=null).Select(y=>y.Value).Sum(z=>z);
       }
     public static decimal? Np(decimal? x, decimal? y){ return (x==null && y==null)?null:Zp(x, y); }
     public static decimal? Np(IEnumerable<decimal?> x){
       return (x==null)?null:N(Zp(x));
       }


     }
  }
