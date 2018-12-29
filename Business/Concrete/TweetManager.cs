using Business.Abstract;
using Glitter.DataAccess;
using Glitter.DataAccess.Entities;
using Glitter.DataAccess.Services;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TweetManager:ITweetManager
    {
        private readonly IGlitterService _glitterService;
        private readonly IMembershipService _membershipService;
        private readonly IFollowManager _followManager;
        public TweetManager(IGlitterService glitterService, IMembershipService membershipService, IFollowManager followManager)
        {
            _glitterService = glitterService;
            _membershipService = membershipService;
            _followManager = followManager;

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
    }
}
