using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI.ViewModels;
using KabadaAPI.DataSource.Repositories;
using KabadaAPI.Utilities;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KabadaAPI.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration config;

        public AuthenticationController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]UserViewModel userView)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid input" });

            UsersRepository repository = new UsersRepository();
            try
            {
                var user = repository.AddUser(userView.Name, userView.Email, userView.Password);
                return Ok(new { id = user.Id });
            }
            catch (Exception exc)
            {
                return BadRequest(new { message = exc.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Get([FromBody]UserViewModel userView)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid input" });

            UsersRepository repository = new UsersRepository();
            try
            {
                var user = repository.AuthenticateUser(userView.Email, userView.Password);
                var tokenString = Token.Generate(user, config);
                return Ok(new
                {
                    access_token = tokenString,
                    email = user.Email,
                    name = user.Name
                });
            }
            catch (Exception exc)
            {
                return BadRequest(new { message = exc.Message });
            }
        }
    }
}
