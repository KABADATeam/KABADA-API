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

        [HttpGet]
        [Route("users/all")]
        public IActionResult GetAll()
        {
            UsersRepository repository = new UsersRepository();
            return Ok(repository.GetUsers());
        }

        [HttpPost]
        [Route("users/register")]
        public IActionResult AddUser([FromBody]User user)
        {
            UsersRepository repository = new UsersRepository();
            try
            {
                repository.AddUser(user.UserName, user.Password);
                return Ok("Success");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost]
        [Route("users/updatepassword")]
        public IActionResult UpdatePassword([FromBody]User user)
        {
            UsersRepository repository = new UsersRepository();
            repository.UpdatePassword(user.UserName, user.Password);
            return Ok("Success on password");
        }
    }
}
