using Business.Abstract;
using Glitter.DataAccess.Entities;
using Glitter.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FollowManager:IFollowManager
    {
        private readonly IGlitterService _glitterService;

        public FollowManager(IGlitterService glitterService)
        {
            _glitterService = glitterService;
        }

        public IEnumerable<User> GetUserFollowers(Guid userKey)
        {
            return _glitterService.GetUserFollowers(userKey);           

        }
        public IEnumerable<User> GetUserFollowees(Guid userKey)
        {
            return _glitterService.GetUserFollowees(userKey);
        }
        public bool AddFollowee(Guid followerKey, Guid followeeKey)
        {
            if (_glitterService.AddFollowee(followerKey, followeeKey))
                return true;

            return false;
        }
        public bool RemoveFollowee(Guid followerKey, Guid followeeKey)
        {
            if (_glitterService.RemoveFollowee(followerKey, followeeKey))
                return true;

            return false;
        }
    }
}
