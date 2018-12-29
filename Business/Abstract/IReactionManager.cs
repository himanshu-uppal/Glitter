using Glitter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReactionManager
    {
        Reaction GetReaction(Guid key);

        bool AddReaction(User user,Tweet tweet,Reaction reaction);
        bool RemoveReaction(User user, Tweet tweet, Reaction reaction);
    }
}
