using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class TweetReactionDto
    {      
        public  UserDto User { get; set; }
        public  ReactionDto Reaction { get; set; }        
    }
}
