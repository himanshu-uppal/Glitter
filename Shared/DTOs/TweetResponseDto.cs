using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class TweetResponseDto
    {
        public IEnumerable<TweetDto> Tweets { get; set; }
        public int TweetsCount { get; set; }
    }
}
