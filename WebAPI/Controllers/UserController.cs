using Business.Abstract;
using Glitter.Business.CustomActionFilters;
using Glitter.Business.Extensions.ModelDtoExtensions;
using Glitter.Business.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    [UserAuthenticationFilter]
    public class UserController : ApiController
    {
       
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
          
            _userManager = userManager;

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetUser()
        {
            var userToken = HttpContext.Current.User.Identity.Name;
            var userEmail = TokenManager.GetEmailFromToken(userToken);
            var user = _userManager.GetUserByEmail(userEmail);
            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user.ToUserDto());

            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }
    }
}