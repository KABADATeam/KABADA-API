﻿using System;
using System.Collections.Generic;

namespace KabadaAPI {
  public class ChannelElementBL {
        public Guid channel_type_id;
        public Guid? channel_subtype_id;
        public Guid? subtype_type_id;
        public Guid? location_type_id;
        public List<Guid> product_id;
        public List<Guid> distribution_channels_id;    
    }
  }
