using KabadaAPIdao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.Extensions.Logging;
using Kabada;

namespace KabadaAPI.Controllers {
  [Route("api/user")]
  [ApiController]
  public class UserController : KController {

    public UserController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}
     
    private UsersRepository uRepo { get { return new UsersRepository(context); }}

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
        public ActionResult<UserUpdate> getSettings(){ return Grun<UserUpdate>(_getSettings); }
        private ActionResult<UserUpdate> _getSettings() {
          var r=uRepo.Read(uGuid);
          return convert(r);
          }

        [Route("updateWithoutPhoto")]
        [Authorize]
        [HttpPost]
        public IActionResult updateWithoutPhoto([FromBody]UserUpdate userUpdate){ return prun<UserUpdate>(_updateWithoutPhoto, userUpdate); }
        private IActionResult _updateWithoutPhoto(UserUpdate userUpdate){
          uRepo.UpdateUser(uGuid, convert(userUpdate), 1);
          return Ok("Success");
        }

        [Route("updateWithPhoto")]
        [Authorize]
        [HttpPost]
        public IActionResult updateWithPhoto([FromBody]UserUpdate userUpdate){ return prun<UserUpdate>(_updateWithPhoto, userUpdate); }
        private IActionResult _updateWithPhoto([FromBody]UserUpdate userUpdate){
          uRepo.UpdateUser(uGuid, convert(userUpdate), 2);
          return Ok("Success");
        }

    //[Route("jst")]
    //[HttpGet]
    //public IActionResult jst() { return grun(_jst); }

    //private  IActionResult _jst() {
    //  //LogInformation($"-- User.getSettings entered at {DateTime.Now}");

    //  //new DataSource.Utilities.Kmail(config).SendOnMailchangeConfirmation("juris.strods@sets.lv", "User.jst");
    //  return Ok("ok");
    //  }
    }
  }
