using Glitter.DataAccess.Abstract;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Entities
{
    public class User:IEntity
    {
        [Key]
        public Guid Key { get; set; }

        [Required(ErrorMessage ="Please provide First Name")]
        [MaxLength(30)]        
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage ="Please provide valid First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide last Name")]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please provide valid last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide Email Address")]
        [Index(IsUnique = true)]
        [MaxLength(60)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please provide valid email address")]
        public string Email { get; set; }

        public string HashedPassword { get; set; }
        public string Salt { get; set; }


        public byte[] ProfileImageData { get; set; }

        

        public string ProfileImageMimeType { get; set; }

        [Required(ErrorMessage = "Please provide Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please provide valid Phone Number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Please provide Country Code")]
        [RegularExpression(@"^([a-zA-Z]{3})$", ErrorMessage = "Please provide valid Country Code")]
        public string Country { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        //public virtual ICollection<UserFollower> UserFollowers { get; set; }
        //public virtual ICollection<UserFollower> UserFollowees { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
        public virtual ICollection<TweetReaction> TweetReactions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public User()
        {
            Tweets = new HashSet<Tweet>();
            TweetReactions = new HashSet<TweetReaction>();
            Comments = new HashSet<Comment>();
        }

    }
}
