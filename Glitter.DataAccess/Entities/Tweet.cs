using Glitter.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Entities
{
    public class Tweet:IEntity
    {
        [Key]
        public Guid Key { get; set; }

        [Required]
        [StringLength(240)]
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TweetReaction> TweetReactions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TweetHashtag> TweetHashtags { get; set; }
        public virtual ICollection<TweetImage> TweetImages { get; set; }

        public Tweet()
        {
            TweetReactions = new  HashSet<TweetReaction>();
            Comments = new HashSet<Comment>();
            TweetHashtags = new HashSet<TweetHashtag>();
            TweetImages = new HashSet<TweetImage>();

        }
    }
}
