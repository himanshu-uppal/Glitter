using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.RequestModels
{
    public class UserRequestModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]       
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
