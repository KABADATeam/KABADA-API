using KabadaAPI;
using System;

namespace Kabada {
  partial class BPpredictP {
    internal string perform(BLontext context) {
      var p=new BusinessPlansRepository(context).getPlanBLfull(planId, context.userGuid);
      p.textSupport=new TexterRepository(context);

      var pAI=new AIpredictP(){ location=location };
      pAI.plan=p.unloadForAI();

      // call predict action with the pAI as parameter
      return p.textSupport.pack(pAI);
     
      }
    }
  }
