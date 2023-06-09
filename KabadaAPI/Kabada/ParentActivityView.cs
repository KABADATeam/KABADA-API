﻿using System;
using System.Collections.Generic;

namespace Kabada {
    public class ParentActivityView
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        
        public List<ActivityView> ChildActivities { get; set; }
    }
}
