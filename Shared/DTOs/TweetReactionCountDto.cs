using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class TweetReactionCountDto:IDto
    {
        public Guid Key { get; set; }
        public  ReactionDto Reaction { get; set; }
        public int ReactionCount { get; set; }
    }
}
