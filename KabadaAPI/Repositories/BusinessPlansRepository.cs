﻿using KabadaAPIdao;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace KabadaAPI
{
    public class BusinessPlansRepository : BaseRepository
    {
        public BusinessPlansRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

        public List<BusinessPlan> GetPublicPlans()
        {
            var plans = daContext.BusinessPlans.Where(x => x.Public == true)
                        .Include(x => x.Country).Include(x => x.User)
                        .Include(x => x.Activity.Industry);
            return plans.OrderBy(x => x.Title).ToList();           
        }
        public void ChangeSwotCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId,planId);
            businessPlan.IsSwotCompleted = newValue;
            daContext.SaveChanges();
        }
        public void ChangeResourcesCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsResourcesCompleted = newValue;
            daContext.SaveChanges();
        }
        public BusinessPlan GetPlan(Guid planId)
        {
           return daContext.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));            
        }
        public BusinessPlan GetPlanForUpdate(Guid userId, Guid planId)
        {
            var mp = daContext.BusinessPlans.Include(x =>x.User).FirstOrDefault(i => i.Id.Equals(planId) && i.User.Id.Equals(userId));            
            if (mp!=null) return mp; 
            var shp = daContext.SharedPlans.Where(i => i.BusinessPlanId.Equals(planId) && i.UserId.Equals(userId)).Include(x =>x.BusinessPlan).FirstOrDefault();
            if (shp?.BusinessPlan != null) return shp.BusinessPlan;
            throw new Exception("No plan found for update");
        }

        internal void ChangePartnersCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsPartnersCompleted = newValue;
            daContext.SaveChanges();
        }
    }
}