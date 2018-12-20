using Glitter.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Entities
{
    public class TweetHashtag:IEntity
    {
        [Key]
        public Guid Key { get; set; }

        public virtual Tweet Tweet { get; set; }
        public virtual Hashtag Hashtag { get; set; }

    }
}
