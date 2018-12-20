using Glitter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Concrete
{
    public class EFDbContext:DbContext
    {
        public EFDbContext() : base("Glitter")
        {
            
        }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Tweet> Tweets { get; set; }
        public IDbSet<Reaction> Reactions { get; set; }
        public IDbSet<Hashtag> Hashtags { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<TweetHashtag> TweetHashtags { get; set; }
        public IDbSet<TweetReaction> TweetReactions { get; set; }
        public IDbSet<UserFollower> UserFollowers { get; set; }

    }
}
