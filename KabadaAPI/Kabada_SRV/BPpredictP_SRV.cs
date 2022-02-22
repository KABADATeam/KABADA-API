using KabadaAPI;
using System;
using System.Threading.Tasks;

namespace Kabada {
  partial class BPpredictP {
    internal async Task<string> perform(BLontext context) {
      var p=new BusinessPlansRepository(context).getPlanBLfull(planId, context.userGuid);
      p.textSupport=new TexterRepository(context);

      var pAI=new AIpredictP(){ location=location };
      pAI.plan=p.unloadForAI();

      string r=null;
      var burl=new AppSettings(context.config).aiUrl;
      if(string.IsNullOrWhiteSpace(burl))
        r=p.textSupport.pack(pAI);
       else {
        var ai=new AIbridge(){ baseAddress=burl };
        r=await ai.predict(pAI);
        }

      return r;
      }
    }
  }
