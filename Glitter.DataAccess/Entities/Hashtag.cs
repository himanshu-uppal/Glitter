using Glitter.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Entities
{
    public class Hashtag:IEntity
    {
        [Key]
        public Guid Key { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}
