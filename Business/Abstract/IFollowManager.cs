using Glitter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFollowManager
    {
        IEnumerable<User> GetUserFollowers(Guid userKey);
        IEnumerable<User> GetUserFollowees(Guid userKey);
        bool AddFollowee(Guid followerKey, Guid followeeKey);
        bool RemoveFollowee(Guid followerKey, Guid followeeKey);
    }
}
