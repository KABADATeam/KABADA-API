using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KabadaAPI.ViewModels;
using KabadaAPI.DataSource.Repositories;
using KabadaAPI.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace KabadaAPI.Controllers
{
    [Authorize]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration config;

        public AuthenticationController(IConfiguration config)
        {
            this.config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]UserViewModel userView)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid input" });

            UsersRepository repository = new UsersRepository();
            try
            {
                var user = repository.AddUser(userView.Email, userView.Password);
                return Ok(new { id = user.Id });
            }
            catch (Exception exc)
            {
                return BadRequest(new { message = exc.Message });
            }
        }

        [AllowAnonymous]
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
                    name = user.Name,
                    role = user.Type.Title
                });
            }
            catch (Exception exc)
            {
                return BadRequest(new { message = exc.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("google")]
        public IActionResult GoogleLogin([FromBody] UserViewModel userView)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid input" });

            UsersRepository repository = new UsersRepository();
            try
            {
                var user = repository.AuthenticateGoogleUser(userView.Email);
                var tokenString = Token.Generate(user, config);
                return Ok(new
                {
                    access_token = tokenString,
                    email = user.Email,
                    name = user.Name,
                    role = user.Type.Title
                });
            }
            catch (Exception exc)
            {
                return BadRequest(new { message = exc.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("reset")]
        public IActionResult RequestPassword([FromBody] UserViewModel userView)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid input" });

            UsersRepository repository = new UsersRepository();
            try
            {
                repository.RequestPassword(userView.Email);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(new { message = exc.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("set_password")]
        public IActionResult SetNewPassword([FromBody] UserViewModel userView)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid input" });

            UsersRepository repository = new UsersRepository();
            try
            {
                repository.ResetPassword(userView.PasswordResetString, userView.Password);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(new { message = exc.Message });
            }
        }

        [Route("change_email")]
        [Authorize]
        [HttpPost]
        public IActionResult change_email([FromBody]ChangeUserParameter userUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            try
            {               
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                
                var repository = new UsersRepository();
                repository.ChangeEmail(userId, userUpdate.password, userUpdate.newValue);
                return Ok("Success");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [Route("change_password")]
        [Authorize]
        [HttpPost]
        public IActionResult change_password([FromBody]ChangeUserParameter userUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            try
            {               
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                
                var repository = new UsersRepository();
                repository.ChangePassword(userId, userUpdate.password, userUpdate.newValue);
                return Ok("Success");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
