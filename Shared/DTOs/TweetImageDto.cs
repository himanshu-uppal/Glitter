using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class TweetImageDto:IDto
    {
        public Guid Key { get; set; }
        public string ImagePath { get; set; }
        public TweetDto Tweet { get; set; }
    }
}
