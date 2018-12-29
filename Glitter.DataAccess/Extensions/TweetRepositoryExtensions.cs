using Glitter.DataAccess.Abstract;
using Glitter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Extensions
{
    public static class TweetRepositoryExtensions
    { 
        public static IEnumerable<Tweet> SearchTweets(this IEntityRepository<Tweet> tweetRepository, string text)
        {
            List<Tweet> tweetsSearched = new List<Tweet>();

            var tweets = tweetRepository.GetAll();

            foreach(var tweet in tweets)
            {
                if (tweet.TweetHashtags != null)
                {
                    var tweetHashtags = tweet.TweetHashtags.Where(th => th.Hashtag.Name.Contains(text));

                    if (tweetHashtags.Count() > 0)
                    {
                        tweetsSearched.Add(tweet);
                    }

                }
                
            }

            return tweetsSearched;

        }
    }
}
