using Business.Abstract;
using Glitter.Business.CustomActionFilters;
using Glitter.Business.Extensions;
using Glitter.Business.Extensions.ModelDtoExtensions;
using Glitter.Business.Providers;
using Glitter.DataAccess;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Glitter.Business.Controllers
{
    [UserAuthenticationFilter]
    public class TweetController:ApiController
    {
        private readonly ITweetManager _tweetManager;
        private readonly IUserManager _userManager;
        public TweetController(ITweetManager tweetManager, IUserManager userManager)
        {
            _tweetManager = tweetManager;
            _userManager = userManager;

        }
        //[Route("")]
        //public IEnumerable<object> Get()
        //{
        //    var identity = User.Identity as ClaimsIdentity;

        //    return identity.Claims.Select(c => new
        //    {
        //        Type = c.Type,
        //        Value = c.Value
        //    });
        //}

        [HttpGet]
        public IEnumerable<TweetDto> GetTweets()
        {
            var userToken = HttpContext.Current.User.Identity.Name;
            var userEmail = TokenManager.GetEmailFromToken(userToken);             
            var user = _userManager.GetUserByEmail(userEmail);
            if (user != null)
            {              
                return _tweetManager.GetUserDashboardTweets(user.Key).Select(t=>t.ToTweetDto());
                //return tweets.ToPaginatedDto(tweets.Select(tw => tw.ToTweetDto()));

            }
            return null; //can send empty object
            
        }
    }
}
