using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Kabada;

namespace KabadaAPI.Controllers {
  [Authorize]
    [Route("api/auth")]
    public class AuthenticationController : KController
    {

       private UsersRepository uRepo { get { return new UsersRepository(config, _logger); }}

        public AuthenticationController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]UserViewModel userView){ return prun<UserViewModel>(_Register, userView); }
        private IActionResult _Register([FromBody]UserViewModel userView){
          var user = uRepo.AddUser(userView.Email, userView.Password);
          return Ok(new { id = user.Id });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]UserViewModel userView){ return prun<UserViewModel>(_Login, userView); }
        private IActionResult _Login([FromBody]UserViewModel userView){
           var user = uRepo.AuthenticateUser(userView.Email, userView.Password);
           var tokenString = Token.Generate(user, config);
           return Ok(new {
                    access_token = tokenString,
                    email = user.Email,
                    name = user.Name,
                    role = user.Type.Title
                });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("google")]
        public IActionResult GoogleLogin([FromBody] UserViewModel userView){ return prun<UserViewModel>(_GoogleLogin, userView); }
        private IActionResult _GoogleLogin([FromBody] UserViewModel userView){
          var user = uRepo.AuthenticateGoogleUser(userView.Email);
          var tokenString = Token.Generate(user, config);
          return Ok(new {
                    access_token = tokenString,
                    email = user.Email,
                    name = user.Name,
                    role = user.Type.Title
                });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("reset")]
        public IActionResult RequestPassword([FromBody] UserViewModel userView){ return prun<UserViewModel>(_RequestPassword, userView); }
        private IActionResult _RequestPassword([FromBody] UserViewModel userView){
                uRepo.RequestPassword(userView.Email);
                return Ok();
         }

        [AllowAnonymous]
        [HttpPost]
        [Route("set_password")]
        public IActionResult SetNewPassword([FromBody] UserViewModel userView){ return prun<UserViewModel>(_SetNewPassword, userView); }
        private IActionResult _SetNewPassword([FromBody] UserViewModel userView){
                uRepo.ResetPassword(userView.PasswordResetString, userView.Password);
                return Ok();
        }

        [Route("change_email")]
        [Authorize]
        [HttpPost]
        public IActionResult change_email([FromBody]ChangeUserParameter userUpdate){ return prun<ChangeUserParameter>(_change_email, userUpdate); }
        private IActionResult _change_email([FromBody]ChangeUserParameter userUpdate){
           uRepo.ChangeEmail(uGuid, userUpdate.password, userUpdate.newValue);
           return Ok("Success");
        }

        [Route("change_password")]
        [Authorize]
        [HttpPost]
        public IActionResult change_password([FromBody]ChangeUserParameter userUpdate){ return prun<ChangeUserParameter>(_change_password, userUpdate); }
        private IActionResult _change_password([FromBody]ChangeUserParameter userUpdate){
           uRepo.ChangePassword(uGuid, userUpdate.password, userUpdate.newValue);
           return Ok("Success");
        }
    }
}
