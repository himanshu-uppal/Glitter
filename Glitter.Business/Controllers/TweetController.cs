using Business.Abstract;
using Glitter.DataAccess;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Glitter.Business.Controllers
{
    public class TweetController:ApiController
    {
        private readonly ITweetManager _tweetManager;
        public TweetController(ITweetManager tweetManager)
        {
            _tweetManager = tweetManager;

        }
        public PaginatedList<TweetDto> GetTweets()
        {
            var tweets = _tweetManager.GetTweets();
            return tweets.ToPaginatedDto(tweets.Select(tw=>tw.ToTweetDto()));
        }
    }
}
