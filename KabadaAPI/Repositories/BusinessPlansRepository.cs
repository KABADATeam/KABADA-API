using KabadaAPIdao;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using static KabadaAPI.JobRepository;

namespace KabadaAPI
{
    public class BusinessPlansRepository : BaseRepository
    {
        public BusinessPlansRepository(BLontext bCcontext, DAcontext dContext=null) : base(bCcontext, dContext) {}

        private DbSet<BusinessPlan> q0 { get { return daContext.BusinessPlans; }}

        private IQueryable<BusinessPlan> qID(Guid id) { return q0.Where(x=>x.Id==id); }
        private IQueryable<BusinessPlan> qUid(Guid userId) { return q0.Where(x=>x.User.Id.Equals(userId)); }
        private IQueryable<BusinessPlan> qFull(IQueryable<BusinessPlan> basic) {
          return basic
            .Include(x => x.Country)
            .Include(x => x.User)
            .Include(x => x.Activity.Industry);
            }

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
        //private BusinessPlan GetPlan(Guid planId){
        //   return daContext.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));            
        //}
        public BusinessPlan GetPlan(Guid planId, Guid userId) {
          //check if public or mine
          var plan = daContext.BusinessPlans.Include(x => x.User).FirstOrDefault(i => i.Id.Equals(planId) && (i.Public||i.User.Id.Equals(userId)));
          if (plan!=null)
            return plan;
            //check if shared with me
            var shp = daContext.SharedPlans.Where(i => i.BusinessPlanId.Equals(planId) && i.UserId.Equals(userId)).Include(x => x.BusinessPlan).FirstOrDefault();
            if (shp?.BusinessPlan != null) return shp.BusinessPlan;
            return null;
        }
        public BusinessPlan GetPlanForUpdate(Guid userId, Guid planId)
        {
            var mp = daContext.BusinessPlans.Include(x =>x.User).Include(x => x.Country).Include(x => x.Language).FirstOrDefault(i => i.Id.Equals(planId) && i.User.Id.Equals(userId));            
            if (mp!=null) return mp; 
            var shp = daContext.SharedPlans.Where(i => i.BusinessPlanId.Equals(planId) && i.UserId.Equals(userId)).Include(x =>x.BusinessPlan).FirstOrDefault();
            if (shp?.BusinessPlan != null) return shp.BusinessPlan;
            throw new Exception("No plan found for update");
        }
        public List<BusinessPlan> GetPlans(Guid userId)
        {
            var pp = daContext.BusinessPlans.Include(x => x.User);
            var myPlans = pp.Where(x => x.User.Id.Equals(userId)).ToList();
            var shp = daContext.SharedPlans.Where(x => x.UserId.Equals(userId));
            var sharedPlans = from sh in shp
                              join bp in pp on sh.BusinessPlanId equals bp.Id
                              select bp;
            return myPlans.Concat(sharedPlans).ToList();
        }
        public BusinessPlan Save(Guid userId, string title, Guid activityId, Guid langId, Guid? imgId, Guid? countryId)
        {
            //User user = context.Users.Include(x => x.BusinessPlans).FirstOrDefault(i => i.Id.Equals(userId));
            var user = daContext.Users.FirstOrDefault(i => i.Id.Equals(userId));
            var activity = daContext.Activities.FirstOrDefault(i => i.Id.Equals(activityId));
            var country = daContext.Countries.FirstOrDefault(i => i.Id.Equals(countryId));
            var language = daContext.Languages.FirstOrDefault(i => i.Id.Equals(langId));
            var image = daContext.UserFiles.FirstOrDefault(i => i.Id.Equals(imgId));//&&i.UserId.Equals(userId));
            if (imgId != null && image == null) new Exception("Can't find the image specified");
            BusinessPlan plan = new BusinessPlan()
            {
                Title = title,
                Activity = activity,
                Country = country,
                Language = language,
                Img = imgId,
                User = user,
                Created = DateTime.Now
            };

            daContext.BusinessPlans.Add(plan);
            return plan;
        }
        public void Remove(Guid userId, Guid planId)
        {
            BusinessPlan businessPlan = GetPlan(planId, userId);// daContext.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));
            daContext.BusinessPlans.Remove(businessPlan);
            daContext.SaveChanges();
            // return plan;
        }
        internal void ChangePartnersCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsPartnersCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangePropositionCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsPropositionCompleted = newValue;
            daContext.SaveChanges();
        }

        internal void ChangeCostCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsCostCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangeRevenueCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsRevenueCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangeChannelsCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsChannelsCompleted = newValue;
            daContext.SaveChanges();
        }

    internal void changeStatus(Guid planId, bool newValue, Guid userId)        {
            var businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.Public = !newValue;
            daContext.SaveChanges();
        }

    protected override object[] getAll4snap() { return daContext.BusinessPlans.ToArray(); }

    protected override string myTable => "BusinessPlans";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.BusinessPlan, Guid>(daContext.BusinessPlans, json, overwrite, oldDeleted, generateInits);
      }

    internal void ChangeCustomerSegmentsCompleted(Guid planId, bool newValue, Guid userId) {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsCustomerSegmentsCompleted = newValue;
            daContext.SaveChanges();
      }

    internal void ChangeRelationshipCompleted(Guid planId, bool newValue, Guid userId) {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsCustomerRelationshipCompleted = newValue;
            daContext.SaveChanges();
      }

    internal string inviteMember(Guid planId, string email, Guid userId) {
      var businessPlan = GetPlanForUpdate(userId, planId); // ensure rights to change
      var u=new UsersRepository(blContext).byEmail(email);
      if(u==null){
        var jRepo=new JobRepository(blContext);
        var j=new Job(){ Author=userId, Kind=(short)JobKind.invitePlanMember, Lookup=email, Value=planId.ToString() };
        var d=new AppSettings(_config).memberInvitationLifetime;
        if(d!=null)
          j.ExpiresAt=DateTime.Now.Add(d.Value);
        new Kmail(blContext.config).sendInvitationEmail(email);
        jRepo.create(j);
        return "invitation e-mail sent";
       } else {
        var r=new SharedPlanRepository(blContext, daContext).add(new SharedPlan(){ BusinessPlanId=planId, UserId=u.Id, Id=Guid.NewGuid() });
        return r;
        }
      }

    public BusinessPlanBL getPlanBL(Guid planId, Guid userId){ return new BusinessPlanBL(GetPlan(planId, userId)); }

    public BusinessPlanBL getPlanBLfull(Guid planId, Guid userId){
      var r=new BusinessPlanBL(GetPlan(planId, userId));
      r.a=new Plan_AttributeRepository(blContext, daContext).get(planId).Select(x=>x.clone())
           .GroupBy(x=>x.Kind).ToDictionary(g => g.Key, g => g.ToList());
      r.s=new Plan_SpecificAttributesRepository(blContext, daContext).get(planId).Select(x=>x.clone())
           .GroupBy(x=>x.Kind).ToDictionary(g => g.Key, g => g.ToList());
      return r;
      }

    internal void ChangeActivitiesCompleted(Guid planId, bool newValue, Guid userId) {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsActivitiesCompleted = newValue;
            daContext.SaveChanges();
      }

    internal void updateLight(Guid userId, Kabada.BusinessPlan n) {
      var o=GetPlanForUpdate(userId, n.Id);

      if(n.CountryId!=null && o.Country.Id!=n.CountryId.Value)
        o.Country=daContext.Countries.FirstOrDefault(i => i.Id.Equals(n.CountryId.Value));
      if(o.Activity.Id!=n.ActivityId)
        o.Activity=daContext.Activities.FirstOrDefault(i => i.Id.Equals(n.ActivityId));
      if(o.Language.Id!=n.LanguageId)
        o.Language=daContext.Languages.FirstOrDefault(i => i.Id.Equals(n.LanguageId));
      o.Img=n.Img;
      o.Title=n.Title;

      daContext.SaveChanges();
      }
        internal void ChangeBusinessInvestmentsCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsBusinessInvestmentsCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangeFixedVariableCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsFixedVariableCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangeSalesForecastCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = GetPlanForUpdate(userId, planId);
            businessPlan.IsSalesForecastCompleted = newValue;
            daContext.SaveChanges();
        }
    }
}