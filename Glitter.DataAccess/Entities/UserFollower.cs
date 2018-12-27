using Glitter.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Entities
{
    public class UserFollower:IEntity
    {
        [Key]
        public Guid Key { get; set; }      
        
        public virtual User Follower { get; set; }       
        
        public virtual User Followee { get; set; }

    }
}
