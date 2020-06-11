using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KabadaAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IConfiguration config;
        protected Guid userId;

        public BaseController(IConfiguration config)
        {
            this.config = config;
            //string str = User.FindFirst(ClaimTypes.Name)?.Value.ToString();
            //userId = Guid.Parse();
        }
    }
}
