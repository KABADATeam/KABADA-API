﻿using System;
using System.Collections.Generic;

namespace Kabada {
  public class UserBusinessPlan
    {   public Guid Id { get; set; }
        public  UserViewModel User { get; set; }
        public List<BusinessPlan> BusinessPlans { get; set; }
    }
}