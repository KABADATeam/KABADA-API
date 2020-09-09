﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI.ViewModels;
using KabadaAPI.DataSource.Repositories;
using KabadaAPI.DataSource.Models;

namespace KabadaAPI.Controllers
{
    [ApiController]
    [Route("api/nace")]
    public class NACEController : ControllerBase
    {
        [HttpGet]
        [Route("industries")]
        public IActionResult GetActivities()
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
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
            IndustryActivityRepository repository = new IndustryActivityRepository();
            List<List<Activity>> a = repository.GetActivitiesByKeyword(TitleKeyword);
            if (a != null) { return Ok(repository.GetActivitiesByKeyword(TitleKeyword)); }
            else return BadRequest("Not found");
            
        }
        [HttpGet]
        [Route("industries/{industryId}/activities/")]
        public IActionResult GetActivities(Guid industryId)
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
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

        [HttpPost]
        [Route("industries")]
        public IActionResult AddIndustryActivity([FromBody]List<DataSource.Models.Industry> industry)
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
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
