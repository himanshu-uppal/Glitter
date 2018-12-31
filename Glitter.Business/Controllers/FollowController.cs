using Business.Abstract;
using Glitter.Business.CustomActionFilters;
using Glitter.Business.Providers;
using Glitter.DataAccess.Abstract;
using Glitter.DataAccess.Entities;
using Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace Glitter.Business.Controllers
{

   
    [UserAuthenticationFilter]
    
    public class FollowController:ApiController
    {
        private readonly IFollowManager _followManager;
        private readonly IUserManager _userManager;

        public FollowController(IFollowManager followManager, IUserManager userManager)
        {
            _followManager = followManager;
            _userManager = userManager;
        }

        [HttpPost]
        public HttpResponseMessage FollowUser(string key)
        {
            Guid followeeKey = new Guid(key);
            var userToken = HttpContext.Current.User.Identity.Name;
            var userEmail = TokenManager.GetEmailFromToken(userToken);
            var user = _userManager.GetUserByEmail(userEmail);
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    var followee = _userManager.GetUser(followeeKey);
                    if (followee != null)
                    {
                        if (_followManager.AddFollowee(user.Key, followee.Key))
                        {
                            return Request.CreateResponse(HttpStatusCode.OK);
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }              

            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        [HttpDelete]
        public HttpResponseMessage UnfollowUser(string key)
        {
            Guid followerKey = new Guid(key);
            var userToken = HttpContext.Current.User.Identity.Name;
            var userEmail = TokenManager.GetEmailFromToken(userToken);
            var user = _userManager.GetUserByEmail(userEmail);
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    var followee = _userManager.GetUser(followerKey);
                    if (followee != null)
                    {
                        if (_followManager.RemoveFollowee(user.Key, followee.Key))
                        {
                            return Request.CreateResponse(HttpStatusCode.OK);
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }




    }
}
