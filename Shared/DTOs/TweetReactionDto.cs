using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class TweetReactionDto:IDto
    {
        public Guid Key { get; set; }
        public  UserDto User { get; set; }
        public  ReactionDto Reaction { get; set; }        
    }
}
