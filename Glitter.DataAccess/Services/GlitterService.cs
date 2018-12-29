using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glitter.DataAccess.Abstract;
using Glitter.DataAccess.Entities;
using Glitter.DataAccess.Extensions;


namespace Glitter.DataAccess.Services
{
    public class GlitterService : IGlitterService
    {
        private readonly IEntityRepository<Tweet> _tweetRepository;
        private readonly IEntityRepository<UserFollower> _userFollowerRepository;
        private readonly IMembershipService _membershipService;
        private readonly IEntityRepository<Hashtag> _hashtagRepository;
        private readonly IEntityRepository<TweetHashtag> _tweetHashtagRepository;
        public GlitterService(IEntityRepository<Tweet> tweetRepository, IEntityRepository<UserFollower> userFollowerRepository,
            IMembershipService membershipService, IEntityRepository<Hashtag> hashtagRepository, IEntityRepository<TweetHashtag> tweetHashtagRepository)
        {
            _tweetRepository = tweetRepository;
            _userFollowerRepository = userFollowerRepository;
            _membershipService = membershipService;
            _hashtagRepository = hashtagRepository;
            _tweetHashtagRepository = tweetHashtagRepository;

        }
        public IEnumerable<Tweet> GetAllTweets()
        {
            var tweets = _tweetRepository.GetAll();
            return tweets;
            
        }

        public PaginatedList<Tweet> GetTweets(int pageIndex, int pageSize)
        {
            var tweets = _tweetRepository.Paginate(pageIndex, pageSize, x => x.Key);
            return tweets;
        }

        public IEnumerable<User> GetUserFollowers(Guid userKey)
        {
            var userFollowers = _userFollowerRepository.GetAll().Where(uf => uf.Followee.Key == userKey).Select(uf => uf.Follower);
            return userFollowers;

        }
        public IEnumerable<User> GetUserFollowees(Guid userKey)
        {
            var userFollowees = _userFollowerRepository.GetAll().Where(uf => uf.Follower.Key == userKey).Select(uf => uf.Followee);
            return userFollowees;
        }

        public bool AddFollowee(Guid followerKey,Guid followeeKey)
        {
            UserFollower userFollower = new UserFollower
            {
                Key = Guid.NewGuid(),
                Follower = _membershipService.GetUser(followerKey),
                Followee = _membershipService.GetUser(followeeKey)
            };

            _userFollowerRepository.Add(userFollower);
            try
            {
                _userFollowerRepository.Save();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
           
        }
        public bool RemoveFollowee(Guid followerKey, Guid followeeKey)
        {
            UserFollower userFollower = _userFollowerRepository.GetAll().FirstOrDefault(uf => uf.Follower.Key == followerKey && uf.Followee.Key == followeeKey);

            _userFollowerRepository.Delete(userFollower);
            try
            {
                _userFollowerRepository.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public Tweet GetTweet(Guid tweetKey)
        {
            return _tweetRepository.GetAll().FirstOrDefault(t=>t.Key == tweetKey);
        }

        public Tweet CreateTweet(Tweet tweet, IEnumerable<Hashtag> hashtags)
        {

            //save the tweet
            tweet.Key = Guid.NewGuid();
            tweet.CreatedOn = DateTime.Now;

            _tweetRepository.Add(tweet);
            _tweetRepository.Save();


           AssociateTweetWithHashtags(tweet,hashtags);

            return tweet;

        }

        private void AssociateTweetWithHashtags(Tweet tweet, IEnumerable<Hashtag> hashtags)
        {
            TweetHashtag tweetHashtag;

            foreach(var hashtag in hashtags)
            {                
                tweetHashtag = new TweetHashtag
                {
                    Key = Guid.NewGuid(),
                    Tweet = tweet,
                    Hashtag = hashtag

                };

                _tweetHashtagRepository.Add(tweetHashtag);
            }
            try
            {
                _tweetHashtagRepository.Save();
            }
            catch(Exception e)
            {
                return;
            }
            
            
        }

        public Hashtag GetHashtagByName(string hashtagName)
        {
            return _hashtagRepository.GetHashtagByName(hashtagName);
        }

        public Hashtag CreateHashtag(string hashtagName)
        {
            Hashtag hashtag = new Hashtag
            {
                Key = Guid.NewGuid(),
                Name = hashtagName
            };

            _hashtagRepository.Add(hashtag);

            try
            {
                _hashtagRepository.Save();
                return hashtag;
            }
            catch (Exception e)
            {
                return null;

            }
        }
    }
}
