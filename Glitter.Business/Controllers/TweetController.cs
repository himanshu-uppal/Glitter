using Business.Abstract;
using Glitter.Business.Extensions;
using Glitter.Business.Extensions.ModelDtoExtensions;
using Glitter.DataAccess;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Glitter.Business.Controllers
{
    [Authorize]
    public class TweetController:ApiController
    {
        private readonly ITweetManager _tweetManager;
        public TweetController(ITweetManager tweetManager)
        {
            _tweetManager = tweetManager;

        }
        [Route("")]
        public IEnumerable<object> Get()
        {
            var identity = User.Identity as ClaimsIdentity;

            return identity.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            });
        }

        //public PaginatedDto<TweetDto> GetTweets()
        //{
        //    var tweets = _tweetManager.GetTweets();
        //    return tweets.ToPaginatedDto(tweets.Select(tw=>tw.ToTweetDto()));
        //}
    }
}
