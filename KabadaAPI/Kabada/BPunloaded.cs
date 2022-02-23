using System;
using System.Collections.Generic;

namespace Kabada {
  public partial class BPunloaded {
    public Guid businessPlan_id;
    public Guid nace;
    public Guid language;
    public Guid country;
    public CustomerSegmentAI custSegs;
    public List<ChannelAI> channels;
    public List<KeyValuePair<string, List<KeyActivityAI>>> keyActivities;
    public List<KeyPartnerAI> keyPartners;
    public List<KeyResourceAI> keyResources;
    public CustomerRelationshipAI custRelationship;
        //costs
        //swot
        //revenue
        //valueProposition
    }
  }
