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
using System.Web;
using System.Web.Http;


namespace WebAPI.Controllers
{
    [UserAuthenticationFilter]
    public class FeedController : ApiController
    {
        private readonly ITweetManager _tweetManager;
        private readonly IUserManager _userManager;
        public FeedController(ITweetManager tweetManager, IUserManager userManager)
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
                var tweets = _tweetManager.GetUserDashboardTweets(user.Key).Select(t => t.ToTweetDto());
                TweetResponseDto tweetResponseDto = new TweetResponseDto
                {
                    Tweets = tweets,
                    TweetsCount = tweets.Count()

                };
                //return Request.CreateResponse(HttpStatusCode.OK, _tweetManager.GetUserDashboardTweets(user.Key).Select(t => t.ToTweetDto()));
                return Request.CreateResponse(HttpStatusCode.OK, tweetResponseDto);
                //return tweets.ToPaginatedDto(tweets.Select(tw => tw.ToTweetDto()));

            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }
    }
}