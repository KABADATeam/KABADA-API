using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI.ViewModels;
using KabadaAPI.DataSource.Repositories;
using KabadaAPI.DataSource.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KabadaAPI.Controllers
{
    [ApiController]
    [Route("api/nace")]
    public class NACEController : KController
    {
        public NACEController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

        protected IndustryActivityRepository iRepo { get { return new IndustryActivityRepository(config, _logger); }}

        [HttpGet]
        [Route("industries")]
        public IActionResult GetIndustries(){ return grun(_GetIndustries); }
        private IActionResult _GetIndustries(){
            var industries = iRepo.GetIndustries();
            var industriesView = new List<IndustryView>();
            foreach (var item in industries)
                industriesView.Add(new IndustryView()
                {
                    id = item.Id,
                    title = item.Title,
                    code = item.Code
                });

            return Ok(industriesView);
        }

        [HttpGet]
        [Route("{TitleKeyword}")]
        public IActionResult GetActivitiesByKey(string TitleKeyword) { return prun<string>(_GetActivitiesByKey, TitleKeyword); }
        private IActionResult _GetActivitiesByKey(string TitleKeyword) {
            IndustryActivityRepository repository = iRepo;
            List<List<Activity>> a = repository.GetActivitiesByKeyword(TitleKeyword);
            List<List<ActivityView>> res = new List<List<ActivityView>>();
            foreach (var i in a)
            { 
                var l = i.Select(x => new ActivityView() { Id = x.Id, Code =x.Code, Title=x.Title }).ToList();
                res.Add(l);
            }
            return Ok(res);           
        }
        [HttpGet]
        [Route("industries/{industryId}/activities/")]
        public IActionResult GetActivities(Guid industryId) { return prun<Guid>( _GetActivities, industryId); }
        private IActionResult _GetActivities(Guid industryId) {
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

            return Ok(activitiesView);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("industries")]
        public IActionResult AddIndustryActivity([FromBody]List<ViewModels.Industry> industry){ return prun<List<ViewModels.Industry>>( _AddIndustryActivity, industry); }
        private IActionResult _AddIndustryActivity([FromBody]List<ViewModels.Industry> industry){
            IndustryActivityRepository repository = iRepo;
                foreach (var ind in industry)
                {
                    foreach (var act in ind.Activities)
                    {
                        repository.AddIndustryAndActivities(ind.Code, ind.Title, ind.Language, act.Code, act.Title);
                    }
                }

                return Ok("Success");
        }
    }
}
