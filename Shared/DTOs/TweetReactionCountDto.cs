using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class TweetReactionCountDto
    {    
        public  ReactionDto Reaction { get; set; }
        public int ReactionCount { get; set; }
    }
}
