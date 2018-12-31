using Glitter.DataAccess.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.Business.Extensions.ModelDtoExtensions
{
    public static class TweetReactionExtensions
    {
        public static TweetReactionDto ToTweetReactionDto(this TweetReaction tweetReaction)
        {
            return new TweetReactionDto
            {
                User = tweetReaction.User.ToUserDto(),
                Reaction = tweetReaction.Reaction.ToReactionDto()
            };           

    }
    }
}
