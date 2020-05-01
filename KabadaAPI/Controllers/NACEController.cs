using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI.ViewModels;
using KabadaAPI.DataSource.Repositories;

namespace KabadaAPI.Controllers
{
    [Route("api/[controller]")]
    public class NACEController : Controller
    {
        [HttpGet]
        [Route("activity/all")]
        public IActionResult GetActivities()
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
            return Ok(repository.GetActivities());
        }

        [HttpGet]
        [Route("activity/{industry}")]
        public IActionResult GetActivity(string industry)
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
            return Ok(repository.GetActivity(industry));
        }

        [HttpGet]
        [Route("industry/all")]
        public IActionResult GetIndustriess()
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
            return Ok(repository.GetIndustries());
        }

        [HttpPost]
        [Route("industry/add")]
        public IActionResult AddIndustry([FromBody]List<Industry> industry)
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
            try
            {
                foreach (var ind in industry)
                {
                    repository.AddIndustry(ind.Code, ind.Title);
                }
                return Ok("Success");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost]
        [Route("activity/add")]
        public IActionResult AddActivity([FromBody]List<Activity> activity)
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
            try
            {
                foreach (var act in activity)
                {
                    repository.AddActivity(act.Code, act.Title, act.Industry);
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
