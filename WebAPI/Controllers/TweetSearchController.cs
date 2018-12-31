using Business.Abstract;
using Glitter.Business.Extensions.ModelDtoExtensions;
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
        public HttpResponseMessage GetTweetsSearched(string key)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _tweetManager.SearchTweets(key).Select(sp => sp.ToTweetDto()));
        }
    }
}
