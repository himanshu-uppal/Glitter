﻿using Glitter.DataAccess.Abstract;
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
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TweetReaction> TweetReactions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public ICollection<Hashtag> Hashtags { get; set; }
        public ICollection<TweetImage> TweetImages { get; set; }
    }
}