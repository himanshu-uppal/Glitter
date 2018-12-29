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

            //List<Tweet> tweets = new List<Tweet>();

            ////adding tweets of user
            //tweets.AddRange(user.Tweets);

            ////adding tweets of user followees
            //var userFollowees = _followManager.GetUserFollowees(user.Key);            

            //foreach (var userFollowee in userFollowees)
            //{
            //    tweets.AddRange(userFollowee.Tweets);
            //}
            //return tweets;

            var tweets = user.Tweets;
            foreach(var tweet in tweets)
            {
                var hashtags = tweet.TweetHashtags;
                Console.WriteLine(hashtags);
            }

            var userFollowees = _followManager.GetUserFollowees(user.Key);

            foreach (var userFollowee in userFollowees)
            {
                tweets.Union(userFollowee.Tweets);
            }
            return tweets.OrderBy(t=>t.CreatedOn);





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

        public Tweet UpdateTweet(Tweet oldTweet, string newTweetMessage)
        {
            var regex = new Regex(@"(?<=#)\w+");

            //old Tweet Hashtags
            var matches = regex.Matches(oldTweet.Message);
            List<string> oldHashtags = new List<string>();
            foreach (Match match in matches)
            {
                oldHashtags.Add(match.Value);
            }

            //new Tweet Hashtags
            matches = regex.Matches(newTweetMessage);
            List<string> newHashtags = new List<string>();
            foreach (Match match in matches)
            {
                newHashtags.Add(match.Value);
            }

            IEnumerable<string> hashtagsToAdd;
            IEnumerable<string> hashtagsToRemove;

            hashtagsToAdd = newHashtags.Except(oldHashtags);
            hashtagsToRemove = oldHashtags.Except(newHashtags);

            //check if new hastag present , if no create one 

            List<Hashtag> newHashtagsSaved = new List<Hashtag>();
            Hashtag hashtagSaved;
            foreach (var hashtag in hashtagsToAdd)
            {
                hashtagSaved = _hashtagManager.GetHashTagByName(hashtag);
                if (hashtagSaved == null)
                {
                    hashtagSaved = _hashtagManager.CreateHashtag(hashtag);
                }
                if (hashtagSaved != null)
                {
                    newHashtagsSaved.Add(hashtagSaved);
                }
            }

            //fetching old Hashtags to be removed
            List<Hashtag> toBeRemovedHashtagsSaved = new List<Hashtag>();
            Hashtag toBeRemovedHashtagSaved;
            foreach (var hashtag in hashtagsToRemove)
            {
                toBeRemovedHashtagSaved = _hashtagManager.GetHashTagByName(hashtag);

                toBeRemovedHashtagsSaved.Add(toBeRemovedHashtagSaved);
                
            }

            oldTweet.Message = newTweetMessage;
            var updatedTweet = _glitterService.UpdateTweet(oldTweet, newHashtagsSaved, toBeRemovedHashtagsSaved);

            return updatedTweet;


        }

        public bool DeleteTweet(Tweet tweet)
        {
            if (_glitterService.DeleteTweet(tweet))
                return true;
            else
                return false;
        }

        public IEnumerable<Tweet> SearchTweets(string text)
        {
            return _glitterService.SearchTweets(text);
        }
    }
}
