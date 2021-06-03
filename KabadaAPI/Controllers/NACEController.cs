using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI.ViewModels;
using KabadaAPI.DataSource.Repositories;
using KabadaAPI.DataSource.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace KabadaAPI.Controllers
{
    [ApiController]
    [Route("api/nace")]
    public class NACEController : ControllerBase
    {
        private readonly IConfiguration config;

        public NACEController(IConfiguration config){ this.config = config; }

        protected IndustryActivityRepository iRepo { get { return new IndustryActivityRepository(config); }}

        [HttpGet]
        [Route("industries")]
        public IActionResult GetActivities()
        {
            IndustryActivityRepository repository = iRepo;
            var industries = repository.GetIndustries();
            var industriesView = new List<object>();
            foreach (var item in industries)
                industriesView.Add(new
                {
                    id = item.Id,
                    title = item.Title,
                    code = item.Code
                });

            return Ok(industriesView);
        }

        [HttpGet]
        [Route("{TitleKeyword}")]
        public IActionResult GetActivitiesByKey(string TitleKeyword)
        {
            IndustryActivityRepository repository = iRepo;
            List<List<Activity>> a = repository.GetActivitiesByKeyword(TitleKeyword);
            if (a != null) { return Ok(repository.GetActivitiesByKeyword(TitleKeyword)); }
            else return BadRequest("Not found");
            
        }
        [HttpGet]
        [Route("industries/{industryId}/activities/")]
        public IActionResult GetActivities(Guid industryId)
        {
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
        public IActionResult AddIndustryActivity([FromBody]List<ViewModels.Industry> industry)
        {
            IndustryActivityRepository repository = iRepo;
            try
            {
                foreach (var ind in industry)
                {
                    foreach (var act in ind.Activities)
                    {
                        repository.AddIndustryAndActivities(ind.Code, ind.Title, ind.Language, act.Code, act.Title);
                    }
                }

                return Ok("Success");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
