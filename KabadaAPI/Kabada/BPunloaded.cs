using KabadaAPI;
using System;
using System.Collections.Generic;

namespace Kabada {
  public partial class BPunloaded {
    public Guid businessPlan_id;
    public Guid nace;
    public Guid language;
    public Guid country;
    public CustomerSegmentAI custSegs
        {
            get
            {
                var r = new CustomerSegmentAI();
                //r.consumer = new List<ConsumerSegmentAI>() { new ConsumerSegmentAI() {} };
                //r.business = new List<BusinessSegmentAI>() { new BusinessSegmentAI() {} };
                //r.publicNgo = new List<PublicSegmentAI>() { new PublicSegmentAI() { } };
                return r;
            }
        }
    }
  }
