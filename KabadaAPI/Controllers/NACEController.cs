﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Kabada;

namespace KabadaAPI.Controllers
{
    [ApiController]
    [Route("api/nace")]
    public class NACEController : KController
    {
        public NACEController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

        protected IndustryActivityRepository iRepo { get { return new IndustryActivityRepository(context); }}

        [HttpGet]
        [Route("industries")]
        public ActionResult<List<IndustryView>> GetIndustries(){ return Grun<List<IndustryView>>(_GetIndustries); }
        private ActionResult<List<IndustryView>> _GetIndustries(){
            var industries = iRepo.GetIndustries();
            var industriesView = new List<IndustryView>();
            foreach (var item in industries)
                industriesView.Add(new IndustryView()
                {
                    id = item.Id,
                    title = item.Title,
                    code = item.Code
                });

            return industriesView;
        }

        [HttpGet]
        [Route("{TitleKeyword}")]
        public ActionResult<List<List<ActivityView>>> GetActivitiesByKey(string TitleKeyword) { return Prun<string, List<List<ActivityView>>>(_GetActivitiesByKey, TitleKeyword); }
        private ActionResult<List<List<ActivityView>>> _GetActivitiesByKey(string TitleKeyword) {
            IndustryActivityRepository repository = iRepo;
            var a = repository.GetActivitiesByKeyword(TitleKeyword);
            var res = new List<List<ActivityView>>();
            foreach (var i in a)
            { 
                var l = i.Select(x => new ActivityView() { Id = x.Id, Code =x.Code, Title=x.Title }).ToList();
                res.Add(l);
            }
            return res;           
        }
        [HttpGet]
        [Route("industries/{industryId}/activities/")]
        public ActionResult<List<ParentActivityView>> GetActivities(Guid industryId) { return Prun<Guid, List<ParentActivityView>>( _GetActivities, industryId); }
        private ActionResult<List<ParentActivityView>> _GetActivities(Guid industryId) {
            IndustryActivityRepository repository = iRepo;
            var activities = repository.GetActivities(industryId);
            var activitiesView = new List<ParentActivityView>();

            foreach (var item in activities)
            {
                string[] s = item.Code.Split('.');
                if (s.Length == 2)
                {
                    activitiesView.Add(new ParentActivityView()
                    {
                        Id = item.Id,
                        Code = item.Code,
                        Title = item.Title,
                        ChildActivities = new List<ActivityView>()
                    });
                }
                else
                {
                    var parentActivity = activitiesView.FirstOrDefault(x => x.Code.Equals(s[0] + "." + s[1]));
                    parentActivity?.ChildActivities.Add(new ActivityView()
                    {
                        Code = item.Code,
                        Id = item.Id,
                        Title = item.Title
                    });
                }   
            }

            return activitiesView;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("industries")]
        //public IActionResult AddIndustryActivity([FromBody]List<Industry> industry){ return prun<List<Industry>>( _AddIndustryActivity, industry); }
        //private IActionResult _AddIndustryActivity([FromBody]List<Industry> industry){
        //    IndustryActivityRepository repository = iRepo;
        //        foreach (var ind in industry)
        //        {
        //            foreach (var act in ind.Activities)
        //            {
        //                repository.AddIndustryAndActivities(ind.Code, ind.Title, ind.Language, act.Code, act.Title);
        //            }
        //        }

        //        return Ok("Success");
        //}

        [HttpGet]
        [Route("wood")]
        public ActionResult<IndustryWood> GetIndustriesWood(){ return Grun<IndustryWood>(_GetIndustriesWood); }
        private ActionResult<IndustryWood> _GetIndustriesWood(){
          var wood = new IndustryWood();
          wood.read(context, iRepo);
          return wood;
          }

        [HttpGet]
        [Route("risks/{activityId}")]
        public ActionResult<IndustryRiskS> GetRisks(Guid activityId) { return Prun<Guid, IndustryRiskS>( _GetRisks, activityId); }
        private ActionResult<IndustryRiskS> _GetRisks(Guid activityId) {
          var r=new IndustryRiskS();
          r.read(context, activityId);
          return r;
        }
    }
}
