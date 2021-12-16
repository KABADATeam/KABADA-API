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
    //public decimal? postProject;

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

    public decimal? yv(int year){ // start with 1
      switch(year){
        case 1: return totalYear1;
        case 2: return totalYear2;
        default: return null;
        }
      }

    internal CashFlowRow minusots(string v, CashFlowRow t) { return makots(v, t, minuso); }
      //var n=(short)(monthlyValue.Count-1);
      //var r=new CashFlowRow(title, null, n);
      //for(var m=0; m<=n; m++)
      //  r.monthlyValue[m]=minuso(monthlyValue[m], t.monthlyValue[m]);
      //r.totalYear1=minuso(totalYear1, t.totalYear1);
      //r.totalYear2=minuso(totalYear2, t.totalYear2);
      //return r;
      //}

    internal CashFlowRow plusots(string v, CashFlowRow t) { return makots(v, t, pluso); }
      //var n=(short)(monthlyValue.Count-1);
      //var r=new CashFlowRow(title, null, n);
      //for(var m=0; m<=n; m++)
      //  r.monthlyValue[m]=pluso(monthlyValue[m], t.monthlyValue[m]);
      //r.totalYear1=pluso(totalYear1, t.totalYear1);
      //r.totalYear2=pluso(totalYear2, t.totalYear2);
      //return r;
      //}

    internal CashFlowRow multoRow(string v, decimal? multiplier, int shift=0) { 
      var n=(short)(monthlyValue.Count-1);
      var r=new CashFlowRow(v, null, (short)(n+shift));
      for(var m=0; m<=n; m++)
        r.monthlyValue[m+shift]=multo(monthlyValue[m], multiplier);
      r.totalYear1=multo(totalYear1, multiplier);
      r.totalYear2=multo(totalYear2, multiplier);
      return r;
      }

    private decimal? multo(decimal? arg1, decimal? arg2) {
      if(arg1==null || arg2==null)
        return null;
      return decimal.Round(arg1.Value*arg2.Value, 2);
      }

    protected CashFlowRow makots(string title, CashFlowRow t, Func<decimal?, decimal?, decimal?> mako) {
      var n=(short)(monthlyValue.Count-1);
      var r=new CashFlowRow(title, null, n);
      for(var m=0; m<=n; m++)
        r.monthlyValue[m]=mako(monthlyValue[m], t.mv(m) /*t.monthlyValue[m]*/);
      r.totalYear1=mako(totalYear1, t.totalYear1);
      r.totalYear2=mako(totalYear2, t.totalYear2);
      return r;
      }

    private decimal v(decimal? me){ return me==null?0:me.Value; }

    private decimal? pluso(decimal? v1, decimal? v2) {
      if(v1==null && v2==null)
        return null;
      return v(v1)+v(v2);
      }

    private decimal? minuso(decimal? v1, decimal? v2) {
      if(v1==null && v2==null)
        return null;
      return v(v1)-v(v2);
      }
    }
  }
