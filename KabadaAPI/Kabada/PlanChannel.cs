using System;
using System.Collections.Generic;

namespace Kabada {
  public class PlanChannel {
    public Guid id;
    public ChannelBase channel_type;
    public PlanChannelSubtype channel_subtype;
    public List<ChannelBase> distribution_channels;
    public List<ChannelBase> products;    
    }
    
}
