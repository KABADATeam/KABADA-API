using Kabada;

namespace KabadaAPI {
  public class MonthedCatalogRow {
    public enum CatalogRowKind { unspecified=0
      , financialInvestment, financialInvestmentW, actualDebt, actualDebtW, actualDebtMstart, payback, paybackW, percentPayment, percentPaymentW
      , ownMoneySum, initialRevenue, initialRevenueW
      , productSelledPure, productVat, productSelledPureSum, productVatSum
      , pendingInvestment
      , buildingsElement, buildingsSum, buildingsVat
      , equipElement, equipSum, equipVat
      , inteliaElement, inteliaSum, inteliaVat
      , costValue, costVat, salaryTax
      }

    public int id { get; protected set; }
    public CatalogRowKind kind;
    public string master;
    public string title;
    public MonthedDataRow data;

    public MonthedCatalogRow(int id, string title=null, MonthedDataRow data=null) { this.id=id; this.title=title; this.data=(data==null)?new MonthedDataRow() : data; }

    public CashFlowRow expose(int lastMonth){
      var r=new CashFlowRow((short)lastMonth){ title=this.title, postProject=this.data.get(lastMonth+1) };
      var w=NZ.range(this.data, 0, lastMonth);
      for(var m=0; m<w.Count; m++)
        r.monthlyValue[m]=w[m];
      r.totals();
      return r;
      }
    }
  }
