using Business.Abstract;
using Glitter.DataAccess;
using Glitter.DataAccess.Entities;
using Glitter.DataAccess.Services;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TweetManager:ITweetManager
    {
        private readonly IGlitterService _glitterService;
        private readonly IMembershipService _membershipService;
        private readonly IFollowManager _followManager;
        private readonly IHashtagManager _hashtagManager;
        public TweetManager(IGlitterService glitterService, IMembershipService membershipService, IFollowManager followManager, IHashtagManager hashtagManager)
        {
            _glitterService = glitterService;
            _membershipService = membershipService;
            _followManager = followManager;
            _hashtagManager = hashtagManager;

        }
        public PaginatedList<Tweet> GetTweets()
        {
            return _glitterService.GetTweets(1, _glitterService.GetAllTweets().Count());
        }
        public IEnumerable<Tweet> GetUserDashboardTweets(Guid userKey)
        {
            var user = _membershipService.GetUser(userKey);
            if(user == null)
            {
                return null;
            }

            List<Tweet> tweets = new List<Tweet>();

            //adding tweets of user
            tweets.AddRange(user.Tweets);

            //adding tweets of user followees
            var userFollowees = _followManager.GetUserFollowees(user.Key);            

            foreach (var userFollowee in userFollowees)
            {
                tweets.AddRange(userFollowee.Tweets);
            }
            return tweets;
            

            
        }

        public Tweet GetTweet(Guid key)
        {
            return _glitterService.GetTweet(key);
        }

        
        public Tweet CreateTweet(Tweet tweet)
        {
            //it recieves the tweet message with hashtags in it
            
            var regex = new Regex(@"(?<=#)\w+");
            var matches = regex.Matches(tweet.Message);
            List<string> hashtags = new List<string>();
            foreach (Match match in matches)
            {
                hashtags.Add(match.Value);
            }

            //check if hastag present , if no create one 

            List<Hashtag> hashtagsSaved = new List<Hashtag>();
            Hashtag hashtagSaved;
            foreach(var hashtag in hashtags)
            {
                hashtagSaved = _hashtagManager.GetHashTagByName(hashtag);
                if(hashtagSaved == null)
                {
                    hashtagSaved = _hashtagManager.CreateHashtag(hashtag);
                }
                if (hashtagSaved != null)
                {
                    hashtagsSaved.Add(hashtagSaved);
                }               
            }

            var tweetSaved = _glitterService.CreateTweet(tweet, hashtagsSaved);

            return tweetSaved;


        }
    }
}
