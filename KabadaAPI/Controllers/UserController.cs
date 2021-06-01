using KabadaAPI.DataSource.Models;
using KabadaAPI.DataSource.Repositories;
using KabadaAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
using System.Linq;

namespace KabadaAPI.Controllers {
  [Route("api/user")]
  [ApiController]
  public class UserController : ControllerBase {
        private readonly IConfiguration config;

        public UserController(IConfiguration config)
        {
            this.config = config;
        }

        private User convert(UserUpdate parms){
          var r=new User();
          r.Name=parms.firstName;
          r.Surname=parms.lastName;
          r.EmailConfirmed=parms.isEmailConfirmed;
          r.Facebook=parms.facebook;
          r.Google=parms.google;
          r.ReceiveEmail=parms.recieveEmail;
          r.ReceiveNotification=parms.recieveNotification;
          if(parms.userPhoto==null)
            r.UserPhoto=null;
           else
            r.UserPhoto = parms.userPhoto.ToArray();
          return r;
          }

        private UserUpdate convert(User p){
          var r=new UserUpdate();
          r.firstName=p.Name;
          r.lastName=p.Surname;
          r.isEmailConfirmed=p.EmailConfirmed;
          r.facebook=p.Facebook;
          r.google=p.Google;
          r.recieveEmail=p.ReceiveEmail;
          r.recieveNotification=p.ReceiveNotification;
          if(p.UserPhoto==null)
            r.userPhoto=null;
           else
            r.userPhoto = p.UserPhoto.ToArray();
          return r;
          }

        [Route("getSettings")]
        [Authorize]
        [HttpGet]
        public IActionResult getSettings()
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            try
            {               
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                var repository = new UsersRepository();
                var r=repository.Read(userId);
                return Ok(convert(r));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [Route("updateWithoutPhoto")]
        [Authorize]
        [HttpPost]
        public IActionResult updateWithoutPhoto([FromBody]UserUpdate userUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            try
            {               
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                
                var repository = new UsersRepository();
                repository.UpdateUser(userId, convert(userUpdate), 1);
                return Ok("Success");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [Route("updateWithPhoto")]
        [Authorize]
        [HttpPost]
        public IActionResult updateWithPhoto([FromBody]UserUpdate userUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            try
            {               
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.Name)?.Value.ToString());
                
                var repository = new UsersRepository();
                repository.UpdateUser(userId, convert(userUpdate), 2);
                return Ok("Success");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

    }
  }
