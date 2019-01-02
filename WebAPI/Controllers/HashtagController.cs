using Business.Abstract;
using Glitter.Business.Extensions.ModelDtoExtensions;
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
    public class HashtagController : ApiController
    {
        private readonly IHashtagManager _hashtagManager;
        public HashtagController(IHashtagManager hashtagManager)
        {
            _hashtagManager = hashtagManager;
        }

        [HttpGet]
        public HttpResponseMessage GetTweetsSearched(string key)
        {
            var tweets = _hashtagManager.GetTweetsByHashtag(key).Select(t => t.ToTweetDto());
            TweetResponseDto tweetResponseDto = new TweetResponseDto
            {
                Tweets = tweets,
                TweetsCount = tweets.Count()

            };
            return Request.CreateResponse(HttpStatusCode.OK, tweetResponseDto);
        }
    }
}