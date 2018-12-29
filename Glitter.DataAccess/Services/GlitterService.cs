using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glitter.DataAccess.Abstract;
using Glitter.DataAccess.Entities;

namespace Glitter.DataAccess.Services
{
    public class GlitterService : IGlitterService
    {
        private readonly IEntityRepository<Tweet> _tweetRepository;
        private readonly IEntityRepository<UserFollower> _userFollowerRepository;
        private readonly IMembershipService _membershipService;
        public GlitterService(IEntityRepository<Tweet> tweetRepository, IEntityRepository<UserFollower> userFollowerRepository, IMembershipService membershipService)
        {
            _tweetRepository = tweetRepository;
            _userFollowerRepository = userFollowerRepository;
            _membershipService = membershipService;

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
    }
}
