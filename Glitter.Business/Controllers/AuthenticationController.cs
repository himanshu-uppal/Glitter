using Business.Abstract;
using Glitter.Business.Providers;
using Glitter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Glitter.Business.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IUserManager _userManager;
        public AuthenticationController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public string GetRegister()
        {
            return "register";
        }

        public string PostRegister()
        {
            return "registered";
        }

       
    }
}