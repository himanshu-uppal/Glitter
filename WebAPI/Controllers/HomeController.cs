using Business.Abstract;
using Glitter.Business.CustomActionFilters;
using Glitter.Business.Extensions.ModelDtoExtensions;
using Glitter.Business.Providers;
using Shared.DTOs;
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
   
    public class HomeController:ApiController
    {
        private readonly ITweetManager _tweetManager;
        private readonly IUserManager _userManager;
        public HomeController(ITweetManager tweetManager, IUserManager userManager)
        {
            _tweetManager = tweetManager;
            _userManager = userManager;

        }

        [HttpGet]
        public HttpResponseMessage GetTweets()
        {
            var userToken = HttpContext.Current.User.Identity.Name;
            var userEmail = TokenManager.GetEmailFromToken(userToken);
            var user = _userManager.GetUserByEmail(userEmail);
            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _tweetManager.GetUserDashboardTweets(user.Key).Select(t => t.ToTweetDto()));
                //return tweets.ToPaginatedDto(tweets.Select(tw => tw.ToTweetDto()));

            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }
    }
}
