﻿using KabadaAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kabada {
  partial class AIlearnP {
    public string pack(){
      var r = JsonConvert.SerializeObject(this, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
      return r;
    }

    internal async Task learn(BLontext blContext) {
      var idi=new BusinessPlansRepository(blContext).allPlans().ToList();
      var lastPos=idi.Count;
      if(lastPos<1)
        return;
      isFirst=true;
      var SLICE=10;
      learningSessionId=DateTime.UtcNow.Ticks;
      while(isLast==false){
        var npos=lastPos-SLICE;
        if(npos<0){
          npos=0;
          isLast=true;
          }
        await learn(idi.GetRange(npos, lastPos-npos), blContext);
        lastPos=npos;
        isFirst=false;
        }
      }

    private async Task learn(List<Guid> guids, BLontext blContext) {
      var repo=new BusinessPlansRepository(blContext);
      var tr=new TexterRepository(blContext, repo.daContext);
      var wp=new AIlearnP(){ isFirst=this.isFirst, learningSessionId=this.learningSessionId };
      var burl = new AppSettings(blContext.config).aiUrl;
      var b =new AIbridge() { baseAddress = burl };
      for(var i=guids.Count-1; i>=0; i--){
        if(i==0)
          wp.isLast=this.isLast;
        var t=repo.getPlanBLfullUnlimited(guids[i]);
        t.textSupport=tr;
        wp.plan=t.unloadForAI();
        var xyz=wp.pack();       // for making snapshots
        await b.learn(wp); // perform AI call with wp
        wp.isFirst=false;
        }
      }
    }
  }
