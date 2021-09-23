using System;
using System.Collections.Generic;
using System.Linq;

namespace Kabada {
  partial class CashFlowRow {
    public CashFlowRow() {}
    public CashFlowRow(short lastMonth) {
      monthlyValue=new List<decimal?>();
      for(short i=0; i<=lastMonth; i++)
        monthlyValue.Add(null);
      }

    public CashFlowRow(string myTitle, decimal? zeroMontthValue=null, short? period=null) : this(period==null?(short)0:period.Value) {
      title=myTitle;
      monthlyValue[0]=zeroMontthValue;
      totalYear1=zeroMontthValue;
      }

    public static decimal? Sum(IEnumerable<decimal?> us){
      var vs=us.Where(x=>x!=null).Select(x=>x.Value).ToList();
      if(vs.Count<1)
        return null;
      return vs.Sum(x=>x);
      }


    public List<decimal?> year1W0() { return rangis(0, 12); }
    public List<decimal?> year1Strict() {  return rangis(1, 12); }
    public List<decimal?> year2() { return rangis(13, 24); }

    private List<decimal?> rangis(int v1, int v2) {
      var rn=new List<decimal?>();
      if(monthlyValue==null || v1<0 || v2<v1)
        return rn;
      var n=monthlyValue.Count-1;
      if(v1>n)
        return rn;
      var u=(v2<=n)?v2:n;
      return monthlyValue.GetRange(v1, u-v1+1);
      }

    public void y1TotW0(){ totalYear1=Sum(year1W0()); }
    public void y1TotWStrict(){ totalYear1=Sum(year1Strict()); }
    public void y2Tot(){ totalYear2=Sum(year2()); }

    public void totals(){ y1TotW0(); y2Tot(); }

    public static decimal? Sum(decimal? me, decimal? addendum){
      if(addendum==null)
        return me;
      if(me==null)
        return addendum;
      return me.Value+addendum.Value;
      }

    public static void Add(ref decimal? me, decimal? addendum){
      if(addendum==null)
        return;
      if(me==null)
        me=addendum;
       else
        me+=addendum.Value;
      }

    public decimal? mv(int month){
      if(monthlyValue==null || month<0 || month>=monthlyValue.Count)
        return null;
      return monthlyValue[month];
      }
    }
  }
