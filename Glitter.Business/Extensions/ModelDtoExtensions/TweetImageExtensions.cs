﻿using Glitter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.Business.Extensions.ModelDtoExtensions
{
    public static class TweetImageExtensions
    {
        public static string ToTweetImageDto(this TweetImage tweetImage)
        {
            return tweetImage.ImagePath;
        }
    }
}
