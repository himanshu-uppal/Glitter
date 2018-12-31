using Business.Abstract;
using Glitter.Business.CustomActionFilters;
using Glitter.Business.Extensions.ModelDtoExtensions;
using Glitter.Business.Providers;
using Glitter.DataAccess.Abstract;
using Glitter.DataAccess.Entities;
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

    public class FollowerController : ApiController
    {
        private readonly IFollowManager _followManager;
        private readonly IUserManager _userManager;

        public FollowerController(IFollowManager followManager, IUserManager userManager)
        {
            _followManager = followManager;
            _userManager = userManager;
        }

        [HttpGet]
        public HttpResponseMessage GetUserFollowers()
        {
            var userToken = HttpContext.Current.User.Identity.Name;
            var userEmail = TokenManager.GetEmailFromToken(userToken);
            var user = _userManager.GetUserByEmail(userEmail);
            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _followManager.GetUserFollowers(user.Key).Select(uf => uf.ToUserDto()));
                //return tweets.ToPaginatedDto(tweets.Select(tw => tw.ToTweetDto()));

            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        } 
    }
}
