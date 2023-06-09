﻿using System;
using System.Collections.Generic;

namespace Kabada {
  public class RevenueStreamAI
    {
        public List<RevenueStreamElementAI> consumer;
        public List<RevenueStreamElementAI> business;
        public List<RevenueStreamElementAI> publicNgo; 
    }
    public class RevenueStreamElementAI
    {
        public Guid id;
        public Guid category;
        public Guid price;
        public Guid pricingType;
        public List<string> segments;     
    }   
}
