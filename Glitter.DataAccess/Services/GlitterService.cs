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
        private readonly IEntityRepository<TweetReaction> _tweetReactionRepository;
        private readonly IEntityRepository<Reaction>  _reactionRepository;
        public GlitterService(IEntityRepository<Tweet> tweetRepository, IEntityRepository<UserFollower> userFollowerRepository,
            IMembershipService membershipService, IEntityRepository<Hashtag> hashtagRepository, IEntityRepository<TweetHashtag> tweetHashtagRepository,
            IEntityRepository<TweetReaction> tweetReactionRepository, IEntityRepository<Reaction> reactionRepository)
        {
            _tweetRepository = tweetRepository;
            _userFollowerRepository = userFollowerRepository;
            _membershipService = membershipService;
            _hashtagRepository = hashtagRepository;
            _tweetHashtagRepository = tweetHashtagRepository;
            _tweetReactionRepository = tweetReactionRepository;
            _reactionRepository = reactionRepository;

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

        public Tweet UpdateTweet(Tweet tweet, IEnumerable<Hashtag> hashtagsToAdd, IEnumerable<Hashtag> hashtagsToRemove)
        {

            //save the tweet
            tweet.LastUpdatedOn = DateTime.Now;

            _tweetRepository.Edit(tweet);
            _tweetRepository.Save();


            AssociateTweetWithHashtags(tweet, hashtagsToAdd);
            DisAssociateTweetWithHashtags(tweet, hashtagsToRemove);

            return tweet;
        }

        private void DisAssociateTweetWithHashtags(Tweet tweet, IEnumerable<Hashtag> hashtags)
        {
            TweetHashtag tweetHashtag;

            foreach (var hashtag in hashtags)
            {
                tweetHashtag = _tweetHashtagRepository.GetAll().FirstOrDefault(th=>th.Tweet.Key == tweet.Key && th.Hashtag.Key == hashtag.Key);
                _tweetHashtagRepository.Delete(tweetHashtag);
                _tweetHashtagRepository.Save();

                //checking if the hashtag being used in another tweet
                tweetHashtag = _tweetHashtagRepository.GetAll().FirstOrDefault(th=>th.Hashtag.Key == hashtag.Key);

                //if not used, the delete it
                if(tweetHashtag == null)
                {
                    RemoveHashtag(hashtag);

                }
            }
           


        }

        public bool DeleteTweet(Tweet tweet)
        {
            var tweetHashTags = tweet.TweetHashtags;
            List<Hashtag> hashtags = new List<Hashtag>();

            foreach(var tweetHashtag in tweetHashTags)
            {
                hashtags.Add(tweetHashtag.Hashtag);
            }

            DisAssociateTweetWithHashtags(tweet, hashtags);

            var tweetReactions = tweet.TweetReactions;
            if (DeleteTweetReactions(tweetReactions))
            {
                _tweetRepository.Delete(tweet);
                try
                {
                    _tweetRepository.Save();
                }
                catch(Exception e)
                {
                    return false;
                }
                
                return true;
            }


            return false;
        }

        private bool DeleteTweetReactions(IEnumerable<TweetReaction> tweetReactions)
        {
            foreach(var tweetReaction in tweetReactions)
            {
                _tweetReactionRepository.Delete(tweetReaction);

            }

            try
            {
                _tweetReactionRepository.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
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

        public bool RemoveHashtag(Hashtag hashtag)
        {           
            _hashtagRepository.Delete(hashtag);

            try
            {
                _hashtagRepository.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }

        public Reaction GetReaction(Guid key)
        {
            return _reactionRepository.GetAll().FirstOrDefault(r=>r.Key == key);

        }

        public bool AddReaction(User user, Tweet tweet, Reaction reaction)
        {
            TweetReaction previousTweetReaction = _tweetReactionRepository.GetAll().FirstOrDefault(tr=>tr.User.Key == user.Key && tr.Tweet.Key == tweet.Key);

            if(previousTweetReaction != null)
            {
                _tweetReactionRepository.Delete(previousTweetReaction);
                _tweetReactionRepository.Save();
            }
            
            TweetReaction tweetReaction = new TweetReaction
            {
                Key = Guid.NewGuid(),
                User = user,
                Tweet = tweet,
                Reaction = reaction

            };


            _tweetReactionRepository.Add(tweetReaction);

            try
            {
                _tweetReactionRepository.Save();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool RemoveReaction(User user, Tweet tweet, Reaction reaction)
        {
            TweetReaction tweetReaction = _tweetReactionRepository.GetAll().
                FirstOrDefault(tr=>tr.User.Key == user.Key && tr.Tweet.Key == tweet.Key && tr.Reaction.Key == reaction.Key);

            _tweetReactionRepository.Delete(tweetReaction);           

            try
            {
                _tweetReactionRepository.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
