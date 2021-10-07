using Kabada;
using System.Collections.Generic;
using System.Linq;
using static KabadaAPI.MonthedCatalogRow;

namespace KabadaAPI {
  public class Plan_OwnMoney : FinancialInvestment {
    //===================MASTER===============================//

    protected Plan_OwnMoney dad { get { return (Plan_OwnMoney)_dad;}}
    protected List<Plan_OwnMoney> slaves;

    public Plan_OwnMoney(MonthedCatalog catalog, BusinessPlanBL businessPlan) {
      _mc=catalog; _bp=businessPlan;
      slaves=new List<Plan_OwnMoney>();
      }

    internal void generateRecords(List<InvestmentElementBL> us) {
      foreach(var p in us){
        var o=new Plan_OwnMoney(this, p);
        slaves.Add(o);
        o.generateRecords();
        }
      generateSumRecords();
      }

    public int summRow { get; protected set; }

    private void generateSumRecords() {
      var s=_mc.add(CatalogRowKind.ownMoneySum, "OwnMoney", new MonthedDataRow());
      summRow=s.id;
      var db=slaves.Select(x=>_mc.get(x.mcInW).data).ToList();
      for(var m=0; m<=_bp.pPeriod; m++)
        s.data.Add(NZ.Np(db.Select(x=>x.get(m))));
      }

    //===================SLAVE===============================//
    InvestmentElementBL p;

    public Plan_OwnMoney(Plan_OwnMoney master, InvestmentElementBL element) {_dad=master; this.p=element; }

    protected void generateRecords() { generateIncoming(mc, p); }

    internal CashFlowRow revenueRow() { return mc.expose(summRow, project_period); }

    //public int mcIn; // montlyTable.financialInvestment
    //public int mcInW; // montlyTable.financialInvestment windowed


    //protected int windowIt(int project_period, int mcId, CatalogRowKind kind = CatalogRowKind.unspecified, bool keepPostAsIs = false) {
    //  var o = mc.get(mcId);
    //  var w = o.data.window(project_period, keepPostAsIs);
    //  var n = mc.add(kind, o.title, w);
    //  return n.id;
    //  }

    //protected void generateIncoming(MonthedCatalog mc, InvestmentElementBL me){
    //  var o=mc.add(CatalogRowKind.financialInvestment, me.title, me); mcIn=o.id;
    //  mcInW=windowIt(bp.pPeriod, mcIn, CatalogRowKind.financialInvestmentW);
    //  }
    }
  }
