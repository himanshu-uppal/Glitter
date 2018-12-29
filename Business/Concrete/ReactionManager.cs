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
    public class ReactionManager:IReactionManager
    {
        private readonly IGlitterService _glitterService;
        public ReactionManager(IGlitterService glitterService)
        {
            _glitterService = glitterService;
        }
        public Reaction GetReaction(Guid key)
        {
            return _glitterService.GetReaction(key);
        }

        public bool AddReaction(User user, Tweet tweet, Reaction reaction)
        {
            return _glitterService.AddReaction(user,tweet,reaction);

        }

        public bool RemoveReaction(User user, Tweet tweet, Reaction reaction)
        {
            return _glitterService.RemoveReaction(user, tweet, reaction);
        }
    }
}
