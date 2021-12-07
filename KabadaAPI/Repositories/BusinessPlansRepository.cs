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
        //private IQueryable<BusinessPlan> qUid(Guid userId) { return q0.Where(x=>x.User.Id.Equals(userId)); }
        //private IQueryable<BusinessPlan> qFull(IQueryable<BusinessPlan> basic) {
        //  return basic
        //    .Include(x => x.Country)
        //    .Include(x => x.User)
        //    .Include(x => x.Activity.Industry);
        //    }

        public List<BusinessPlan> GetPublicPlans()
        {
            var plans = daContext.BusinessPlans.Where(x => x.Public == true)
                        .Include(x => x.Country).Include(x => x.User)
                        .Include(x => x.Activity.Industry);
            return plans.OrderBy(x => x.Title).ToList();           
        }
        public void ChangeSwotCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan = get(planId, userId); //   GetPlanForUpdate(userId,planId);
            businessPlan.IsSwotCompleted = newValue;
            daContext.SaveChanges();
        }
        public void ChangeResourcesCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan =get(planId, userId); // GetPlanForUpdate(userId, planId);
            businessPlan.IsResourcesCompleted = newValue;
            daContext.SaveChanges();
        }
        //private BusinessPlan GetPlan(Guid planId){
        //   return daContext.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));            
        //}
        //public BusinessPlan GetPlan(Guid planId, Guid userId) {
        //    //check if public or mine
        //     var plan = daContext.BusinessPlans.Where(i => i.Id.Equals(planId) && (i.User.Id.Equals(userId)|| i.Public == true)).Include(x => x.User).Include(x => x.Country)
        //         //.Include(x => x.Language)
        //         .Include(x => x.Activity.Industry).FirstOrDefault();
        //    if (plan!=null)
        //    return plan;
        //    //check if shared with me
        //    var shp = daContext.SharedPlans.Where(i => i.BusinessPlanId.Equals(planId) && i.UserId.Equals(userId)).Include(x => x.BusinessPlan).Include(x => x.BusinessPlan.Country)
        //           //.Include(x => x.BusinessPlan.Language)
        //           .Include(x => x.BusinessPlan.Activity).FirstOrDefault();
        //    if (shp?.BusinessPlan != null) return shp.BusinessPlan;
        //    return null;
        //}
        //public BusinessPlan GetPlanForUpdate(Guid userId, Guid planId)
        //{
        //    var mp = daContext.BusinessPlans.Where(i => i.Id.Equals(planId) && i.User.Id.Equals(userId)).Include(x => x.User).Include(x => x.Country).Include(x => x.Language).Include(x => x.Activity).FirstOrDefault();            
        //    if (mp!=null) return mp; 
        //    var shp = daContext.SharedPlans.Where(i => i.BusinessPlanId.Equals(planId) && i.UserId.Equals(userId)).Include(x =>x.BusinessPlan).Include(x => x.BusinessPlan.Country).Include(x => x.BusinessPlan.Language).Include(x => x.BusinessPlan.Activity).FirstOrDefault();
        //    if (shp?.BusinessPlan != null) return shp.BusinessPlan;
        //    throw new Exception("No plan found for update");
        //}
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
                LanguageId = language.Id,
                Img = imgId,
                User = user,
                Created = DateTime.Now
            };

            daContext.BusinessPlans.Add(plan);
            return plan;
        }
        public void Remove(Guid userId, Guid planId)
        {
            var businessPlan = get(planId, userId); // GetPlan(planId, userId);// daContext.BusinessPlans.FirstOrDefault(i => i.Id.Equals(planId));
            daContext.BusinessPlans.Remove(businessPlan);
            daContext.SaveChanges();
            // return plan;
        }
        internal void ChangePartnersCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan =get(planId, userId); // GetPlanForUpdate(userId, planId);
            businessPlan.IsPartnersCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangePropositionCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan =get(planId, userId); // GetPlanForUpdate(userId, planId);
            businessPlan.IsPropositionCompleted = newValue;
            daContext.SaveChanges();
        }

        internal void ChangeCostCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan =get(planId, userId); // GetPlanForUpdate(userId, planId);
            businessPlan.IsCostCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangeRevenueCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan =get(planId, userId); // GetPlanForUpdate(userId, planId);
            businessPlan.IsRevenueCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangeChannelsCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan =get(planId, userId); // GetPlanForUpdate(userId, planId);
            businessPlan.IsChannelsCompleted = newValue;
            daContext.SaveChanges();
        }

    internal void changeStatus(Guid planId, bool newValue, Guid userId)        {
            var businessPlan =get(planId, userId); // GetPlanForUpdate(userId, planId);
            businessPlan.Public = !newValue;
            daContext.SaveChanges();
        }

    protected override object[] getAll4snap() { return daContext.BusinessPlans.ToArray(); }

    protected override string myTable => "BusinessPlans";

    protected override bool loadData(string json, bool overwrite, bool oldDeleted, bool generateInits) {
      return loadDataRow<KabadaAPIdao.BusinessPlan, Guid>(daContext.BusinessPlans, json, overwrite, oldDeleted, generateInits);
      }

    internal void ChangeCustomerSegmentsCompleted(Guid planId, bool newValue, Guid userId) {
            BusinessPlan businessPlan =get(planId, userId); // GetPlanForUpdate(userId, planId);
            businessPlan.IsCustomerSegmentsCompleted = newValue;
            daContext.SaveChanges();
      }

    internal void ChangeRelationshipCompleted(Guid planId, bool newValue, Guid userId) {
            BusinessPlan businessPlan =get(planId, userId); // GetPlanForUpdate(userId, planId);
            businessPlan.IsCustomerRelationshipCompleted = newValue;
            daContext.SaveChanges();
      }

    internal string inviteMember(Guid planId, string email, Guid userId) {
      //var businessPlan = GetPlanForUpdate(userId, planId); // ensure rights to change
      get(planId, userId); // ensure rights to change
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

    //public BusinessPlanBL getPlanBL(Guid planId, Guid userId){
    //  //var t=joinRO(planId);
    //  return new BusinessPlanBL(GetPlan(planId, userId));
    //  }

    public BusinessPlanBL getPlanBLfull(Guid planId, Guid userId){
      var r=new BusinessPlanBL(join(planId, userId)); //      GetPlan(planId, userId));
      var w1=new Plan_AttributeRepository(blContext, daContext).get(planId).Select(x=>x.clone()).ToList();
      r.a=w1.GroupBy(x=>x.Kind).ToDictionary(g => g.Key, g => g.ToList());
      var w2=new Plan_SpecificAttributesRepository(blContext, daContext).get(planId).Select(x=>x.clone()).ToList();
      r.s=w2.GroupBy(x=>x.Kind).ToDictionary(g => g.Key, g => g.ToList());
      return r;
      }

    internal void ChangeActivitiesCompleted(Guid planId, bool newValue, Guid userId) {
            BusinessPlan businessPlan =get(planId, userId); //  GetPlanForUpdate(userId, planId);
            businessPlan.IsActivitiesCompleted = newValue;
            daContext.SaveChanges();
      }

    //private Guid? countryId(BusinessPlan p){ return p.CountryId; } // p.Country==null?null:p.Country.Id; }
    //private Guid? activityId(BusinessPlan p){ return p.ActivityID; } // p.Activity==null?null:p.Activity.Id; }
    //private Guid? languageId(BusinessPlan p){ return p.LanguageId; } // p.Language==null?null:p.Language.Id; }

    //internal void updateLight(Guid userId, Kabada.BusinessPlan n) {
    //  var o=GetPlanForUpdate(userId, n.Id);
      
      
    //  if(o.CountryId!=n.CountryId)
    //    if(n.CountryId!=null)
    //      o.Country=daContext.Countries.FirstOrDefault(i => i.Id.Equals(n.CountryId.Value));
    //     else
    //      o.Country=null;
    //  if(o.ActivityID!=n.ActivityId)
    //    o.Activity=daContext.Activities.FirstOrDefault(i => i.Id.Equals(n.ActivityId));
    //  if(o.LanguageId!=n.LanguageId)
    //    o.Language=daContext.Languages.FirstOrDefault(i => i.Id.Equals(n.LanguageId));
    //  o.Img=n.Img;
    //  o.Title=n.Title;

    //  daContext.SaveChanges();
    //  }

    internal void updateLight(Guid userId, Kabada.BusinessPlan n) {
      var o=getRW(n.Id);
      
      if(o.CountryId!=n.CountryId){
        if(n.CountryId!=null)
          o.CountryId=daContext.Countries.FirstOrDefault(i => i.Id.Equals(n.CountryId.Value)).Id;
         else
          o.CountryId=null;
        }

      if(o.ActivityID!=n.ActivityId){
        if(n.ActivityId!=null)
          o.ActivityID=daContext.Activities.FirstOrDefault(i => i.Id.Equals(n.ActivityId)).Id;
         else
          o.ActivityID=null;
         }

      if(o.LanguageId!=n.LanguageId){
        //if(n.LanguageId!=null)
          o.LanguageId=daContext.Languages.FirstOrDefault(i => i.Id.Equals(n.LanguageId)).Id;
         //else
         // o.LanguageId=null;
        }

      o.Img=n.Img;
      o.Title=n.Title;

      daContext.SaveChanges();
      }

        internal void ChangeBusinessInvestmentsCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan =get(planId, userId); //  GetPlanForUpdate(userId, planId);
            businessPlan.IsBusinessInvestmentsCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangeFixedVariableCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan =get(planId, userId); //  GetPlanForUpdate(userId, planId);
            businessPlan.IsFixedVariableCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangeSalesForecastCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan =get(planId, userId); //  GetPlanForUpdate(userId, planId);
            businessPlan.IsSalesForecastCompleted = newValue;
            daContext.SaveChanges();
        }
        internal void ChangeAssetsCompleted(Guid planId, bool newValue, Guid userId)
        {
            BusinessPlan businessPlan =get(planId, userId); //  GetPlanForUpdate(userId, planId);
            businessPlan.IsAssetsCompleted = newValue;
            daContext.SaveChanges();
        }

    protected Guid? LV;
    protected bool isJH;
    protected Guid? JH;
    protected override void adjust(object me) {
      var o=(KabadaAPIdao.BusinessPlan)me;
      if(o.CountryId==null){
        if(LV==null)
          LV=new CountryRepository(blContext, daContext).Q("LV").Select(x=>x.Id).FirstOrDefault();
        o.CountryId=LV;
        }
      if(o.Public==false && o.UserId==null){
        if(isJH==false){
          isJH=true;
          JH=new UsersRepository(blContext, daContext).Q().Where(x=>x.Email=="janis.hermanis@ba.lv").Select(x=>x.Id).FirstOrDefault();
          }
        o.UserId=JH;
        }
      }

    protected override Guid? guid(string json) {
      var o = Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.BusinessPlan>(json);
      return o.Id;
      }

    protected override object unloadChildren(object o, Kabada.UnloadSet us, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet) {
      var oo=(BusinessPlan)o;
      var planId=oo.Id;

      var p=getPlanBLfull(planId, blContext.userGuid);
      p.textSupport=new TexterRepository(blContext, daContext);
      us.descriptor="jst bp2f test";
      us.user=p.o.User.Email;
      if(us.outfile==null)
        us.outfile=p.filePath("bpU.csv");
      unloadHim<UserFilesRepository>(p.o.Img, us, skipSet, unloadedSet);
      unloadHim<CountryRepository>(p.o.CountryId, us, skipSet, unloadedSet);
      unloadHim<LanguagesRepository>(p.o.LanguageId, us, skipSet, unloadedSet);
      unloadHim<IndustryActivityRepository>(p.o.ActivityID, us, skipSet, unloadedSet);

      oo.Activity=null; oo.Country=null;
      //oo.Language=null;
      oo.User=null;

      return p;
      }

    protected override object byIdU(Guid myId) { return getRO(myId); } // GetPlan(myId, blContext.userGuid); }

    protected override void unloadFollowers(object o, Kabada.UnloadSet us, Dictionary<Guid, bool> skipSet, Dictionary<Guid, bool> unloadedSet) {
      var p=(BusinessPlanBL)o;
      var tidi=new List<Guid>();
      foreach(var st in p.a.Values)
        tidi.AddRange(st.Select(x=>x.TexterId).ToList());
      p.textSupport.unloadMe(tidi, us, skipSet, unloadedSet);

      foreach (var st in p.a.Values) {
        foreach (var t in st)
          unloadMeInternalPlain(t, t.Id, us, skipSet, unloadedSet);
        }
      foreach (var st in p.s.Values) {
        foreach (var t in st)
          unloadMeInternalPlain(t, t.Id, us, skipSet, unloadedSet);
        }
      var akti=unloadedSet.Keys.ToList();
      var uaR=new UniversalAttributeRepository(blContext, daContext);
      var ui=uaR.referencers(akti);
      foreach(var t in ui)
       unloadMeInternalPlain(t, t.Id, us, skipSet, unloadedSet);
      }

    internal override void import(Guid newId, string json, UnloadSetImport unloadSetImport) {
      var o = Newtonsoft.Json.JsonConvert.DeserializeObject<KabadaAPIdao.BusinessPlan>(json);
      o.Title=string.Format( unloadSetImport.targetNamePattern, o.Title);
      o.Id=newId;
      o.UserId=unloadSetImport.targetOwner;
      o.Img=upis(o.Img, unloadSetImport);
      o.ActivityID=upis(o.ActivityID, unloadSetImport);
      o.LanguageId=upis(o.LanguageId, unloadSetImport);
      o.CountryId=upis(o.CountryId, unloadSetImport);
      daContext.Add(o);
      }

    public Kabada.UnloadSet unload(Guid planId){
      var r=new Kabada.UnloadSet();
      unloadMe(planId, r, initGuids, new Dictionary<Guid, bool>());
      return r;
      }

    public Guid reload(Kabada.UnloadSet me, Guid? targetOwner=null){
      var w=new UnloadSetImport(){ bR=this, targetOwner=targetOwner };
      return w.import(me);
      }

    public Guid clone(Guid planId, bool exportCSV=false){
      var t=unload(planId);
      if(exportCSV)
        t.toCSV();
      return reload(t, blContext.userGuid);
      }

    public bool isShared(BusinessPlan plan, Guid userId) {
      var cnt=daContext.SharedPlans.Where(x=>x.BusinessPlanId==plan.Id && x.UserId==userId).Count();
      return (cnt>0);
      }

    private bool validateAccessRights(BusinessPlan plan, Guid userId, bool acceptRO, bool quiet) {
      if(plan!=null){
        if(plan.UserId==userId)
          return true;
        if(acceptRO && plan.Public)
          return true;
        if(isShared(plan, userId))
          return true;
        }
      if(quiet)
        return false;
      throw new Exception("Access denied");
      }

    public BusinessPlan get(Guid planId, Guid userId, bool acceptRO=false, bool quiet=false) {
      var plan=qID(planId).FirstOrDefault();
      if(validateAccessRights(plan, userId, acceptRO, quiet))
        return plan;
      return null;
      }

    public BusinessPlan getRW(Guid planId) { return get(planId, blContext.userGuid); }

    public BusinessPlan getRO(Guid planId) { return get(planId, blContext.userGuid, true); }

    protected IQueryable<BPjoin> joinQ(IQueryable<BusinessPlan> planQuery){
      var r=from p in planQuery
            join ct in daContext.Countries  on p.CountryId  equals ct.Id into ctlist from c in ctlist.DefaultIfEmpty()
            join lt in daContext.Languages  on p.LanguageId equals lt.Id into ltlist from l in ltlist.DefaultIfEmpty()
            join ut in daContext.Users      on p.UserId     equals ut.Id into utlist from u in utlist.DefaultIfEmpty()
            join at in daContext.Activities on p.ActivityID equals at.Id into atlist from a in atlist.DefaultIfEmpty()
            join it in daContext.Industries on a.IndustryId equals it.Id into itlist from i in itlist.DefaultIfEmpty()
            select new BPjoin { bp=p, cn=c, us=u, lng=l, ac=a, ind=i };
      return r;
      }

    public BPjoin join(Guid planId, Guid userId, bool acceptRO=false, bool quiet=false) {
      var plan=joinQ(qID(planId)).FirstOrDefault();
      if(validateAccessRights(plan==null?null:plan.bp, userId, acceptRO, quiet))
        return plan;
      return null;
      }

    public BPjoin joinRO(Guid planId) { return join(planId, blContext.userGuid, true); }

    public BPextended getROe(Guid planId) { return new BPextended(joinRO(planId)); }
    }
}