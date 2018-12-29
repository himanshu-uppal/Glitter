using Business.Abstract;
using Glitter.Business.CustomActionFilters;
using Glitter.Business.Extensions;
using Glitter.Business.Extensions.ModelDtoExtensions;
using Glitter.Business.Extensions.RequestModelExtensions;
using Glitter.Business.Providers;
using Glitter.DataAccess;
using Shared.DTOs;
using Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Glitter.Business.Controllers
{
    
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

        //[HttpGet]
        //public IEnumerable<TweetDto> GetTweets()
        //{
        //    var userToken = HttpContext.Current.User.Identity.Name;
        //    var userEmail = TokenManager.GetEmailFromToken(userToken);             
        //    var user = _userManager.GetUserByEmail(userEmail);
        //    if (user != null)
        //    {              
        //        return _tweetManager.GetUserDashboardTweets(user.Key).Select(t=>t.ToTweetDto());
        //        //return tweets.ToPaginatedDto(tweets.Select(tw => tw.ToTweetDto()));

        //    }
        //    return null; //can send empty object
            
        //}

        [HttpGet]
        public HttpResponseMessage GetTweet(string key)
        {
            var tweetKey = new Guid(key);

            var tweet = _tweetManager.GetTweet(tweetKey);
            if (tweet != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,tweet.ToTweetDto());
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);

        }

        [UserAuthenticationFilter]
        public HttpResponseMessage PostTweet([FromBody] TweetRequestModel tweetRequestModel)
        {
            
            var userToken = HttpContext.Current.User.Identity.Name;
            var userEmail = TokenManager.GetEmailFromToken(userToken);
            var user = _userManager.GetUserByEmail(userEmail);
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    var tweet = _tweetManager.CreateTweet(tweetRequestModel.toTweet(user));
                    return Request.CreateResponse(HttpStatusCode.OK,tweet.ToTweetDto());
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

    }
}
