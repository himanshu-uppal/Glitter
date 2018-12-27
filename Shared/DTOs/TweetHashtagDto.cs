using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class TweetHashtagDto:IDto
    {
        public Guid Key { get; set; }
        public  HashtagDto Hashtag { get; set; }
    }
}
