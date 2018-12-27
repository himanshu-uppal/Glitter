using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class CommentDto:IDto
    { 
        public Guid Key { get; set; }
        
        public string Message { get; set; }
        public  UserDto User { get; set; }
        
    }
}
