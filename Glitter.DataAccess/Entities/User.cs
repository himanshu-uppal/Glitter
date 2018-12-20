using Glitter.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Entities
{
    public class User:IEntity
    {
        [Key]
        public Guid Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public byte[] ProfileImageData { get; set; }
        public string ProfileImageMimeType { get; set; }
        public string ContactNumber { get; set; }
        public string Country { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        //public virtual ICollection<UserFollower> UserFollowers { get; set; }
        //public virtual ICollection<UserFollower> UserFollowees { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
        public virtual ICollection<TweetReaction> TweetReactions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
