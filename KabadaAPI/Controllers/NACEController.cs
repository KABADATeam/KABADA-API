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
        [Route("activity/all/{industry}")]
        public IActionResult GetActivity(string industry)
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
            return Ok(repository.GetActivity(industry));
        }

        [HttpGet]
        [Route("industry/all")]
        public IActionResult GetIndustries()
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
            return Ok(repository.GetIndustries());
        }

        [HttpGet]
        [Route("industry/of/{language}")]
        public IActionResult GetAllIndustriesbyLanguage(string language)
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
            return Ok(repository.GetAllIndustriesbyLanguage(language));
        }

        //[HttpGet]
        //[Route("industry/of/{language}/{code}")]
        //public IActionResult GetIndustriesbyLanguageAndCode(string language,string code)
        //{
        //    IndustryActivityRepository repository = new IndustryActivityRepository();
        //    return Ok(repository.GetIndustriesbyLanguageAndCode(language, code));
        //}

        [HttpGet]
        [Route("activity/of/{language}")]
        public IActionResult GetAllActivitiesbyLanguage(string language)
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
            return Ok(repository.GetAllActivitiesbyLanguage(language));
        }

        [HttpGet]
        [Route("activity/of/{language}/{industry}")]
        public IActionResult GetAllActivitiesbyLanguageIndustry(string language, string industry)
        {
            IndustryActivityRepository repository = new IndustryActivityRepository();
            return Ok(repository.GetAllActivitiesbyLanguageIndustry(language, industry));
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

        [HttpPost]
        [Route("industry/addall")]
        public IActionResult AddIndustryActivity([FromBody]List<Industry> industry)
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
