using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class TweetDto
    {       
        public Guid Key { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public UserDto User { get; set; }
        public IEnumerable<TweetReactionDto> TweetReactions { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public IEnumerable<string> TweetHashtags { get; set; }
        public IEnumerable<string> TweetImages { get; set; }
        public IEnumerable<TweetReactionCountDto> TweetReactionsCount { get; set; }
    }
}
