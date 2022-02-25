using System;
using System.Collections.Generic;

namespace Kabada {
  public class ChannelAI {       
        public Guid channelType;
        public Guid? channelSubtype;
        public Guid? subtypeType;
        public Guid? locationType;
        public List<Guid> distributionChannels; 
        public List<Guid> products; //value proposition
    }
}
