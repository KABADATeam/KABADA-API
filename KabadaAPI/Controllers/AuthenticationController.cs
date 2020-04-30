using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI.ViewModels;
using KabadaAPI.DataSource.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KabadaAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        [HttpGet]
        [Route("login/empty")]
        public IActionResult Get()
        {
            return BadRequest("Bad request");
        }

        [HttpGet]
        [Route("login/{name}")]
        public IActionResult Get(string name)
        {
            if (name.Equals("Mindaugas"))
                return Ok("Login success");
            else
                return BadRequest("Login failed");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Get([FromBody]User user)
        {
            return Ok(user);
        }
    }
}
