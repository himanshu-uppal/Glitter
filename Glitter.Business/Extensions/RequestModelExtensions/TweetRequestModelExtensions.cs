using Glitter.DataAccess.Entities;
using Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.Business.Extensions.RequestModelExtensions
{
    public static class TweetRequestModelExtensions
    {
        public static Tweet toTweet(this TweetRequestModel tweetRequestModel,User user)
        {
            return new Tweet
            {
                Message = tweetRequestModel.Message,
                User = user                

            };
        }
    }
}
