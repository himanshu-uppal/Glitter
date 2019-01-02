using Business.Abstract;
using Glitter.Business.Extensions.ModelDtoExtensions;
using Shared.DTOs;
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
    
    public class TweetSearchController : ApiController
    {
        private readonly ITweetManager _tweetManager;
        public TweetSearchController(ITweetManager tweetManager)
        {
            _tweetManager = tweetManager;
        }

        [HttpGet]
        [Route("api/tweetsearch/{key}")]
        public HttpResponseMessage GetTweetsSearched(string key)
        {
            var tweets = _tweetManager.SearchTweets(key).OrderByDescending(t=>t.CreatedOn).Select(sp => sp.ToTweetDto());
            TweetResponseDto tweetsResponseDto = new TweetResponseDto
            {
                Tweets = tweets,
                TweetsCount = tweets.Count()
            };
            return Request.CreateResponse(HttpStatusCode.OK, tweetsResponseDto);
        }
    }
}
