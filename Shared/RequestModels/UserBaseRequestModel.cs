using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.RequestModels
{
    public abstract class UserBaseRequestModel
    {  

        [Required(ErrorMessage = "Please provide First Name")]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please provide valid First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide last Name")]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please provide valid last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide Email Address")]
        [MaxLength(60)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please provide valid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]        
        [RegularExpression(@"(?=^.{8,20}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$")]
        public string Password { get; set; }

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

    }
}
