using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.RequestModels
{
    public abstract class UserBaseRequestModel
    {

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(320)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
