using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class UserDto
    {
        public Guid Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }       
        public byte[] ProfileImageData { get; set; }
        public string ProfileImageMimeType { get; set; }
        public string ContactNumber { get; set; }
        public string Country { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }      
       
    }
}
