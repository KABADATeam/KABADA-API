using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI {
  public class Plan_Assets {
    //===================MASTER===============================//
    protected MonthedCatalog _mc;
    protected BusinessPlanBL _bp;

    protected Plan_Assets dad;
    //protected List<Plan_Assets> slaves;

    private MonthedCatalog mc { get { return _mc==null?dad._mc:_mc; }}
    private BusinessPlanBL bp { get { return _bp==null?dad._bp:_bp; }}

    public Plan_Assets(MonthedCatalog catalog, BusinessPlanBL businessPlan) {
      _mc=catalog; _bp=businessPlan;
      //slaves=new List<Plan_SaleForecast>();
      }

    public List<int> mcRows { get; protected set; }

    internal void generateRecords(List<KeyResourceBL> pi) {
      //foreach(var p in pi){
      //  var o=new Plan_SaleForecast(this,p);
      //  slaves.Add(o);
      //  o.generateRecords();
      //  }
      //GenerateSumRecords();
      }
    }
  }
