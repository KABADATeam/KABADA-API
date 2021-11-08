using KabadaAPI;
using System;

namespace Kabada {
  partial class IndustryRiskS {
    internal void read(BLontext context, Guid activityId) {
      var m=new IndustryActivityRepository(context);
      var w=m.getMyRisks(activityId);
      if(w!=null){
        this.associationPoint=m.masterForRisk;
        var t=IndustryRiskDescriptor.ById(w.Value, context, m.daContext);
        this.risks=t.risks;
        }
      }
    }
  }
