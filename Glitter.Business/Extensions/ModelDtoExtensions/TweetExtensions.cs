using Glitter.DataAccess.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.Business.Extensions.ModelDtoExtensions
{
    public static class TweetExtensions
    {
        public static TweetDto ToTweetDto(this Tweet tweet)
        {
            return new TweetDto
            {
                Key = tweet.Key,
                Message = tweet.Message,
                CreatedOn = tweet.CreatedOn,
                LastUpdatedOn = tweet.LastUpdatedOn,
                User = tweet.User.ToUserDto(),
                TweetReactions = tweet.TweetReactions.Select(tr=>tr.ToTweetReactionDto()),
                Comments = tweet.Comments.Select(c=>c.ToCommentDto()),
                TweetHashtags = tweet.TweetHashtags.Select(th=>th.ToTweetHashtagDto()),
                TweetImages = tweet.TweetImages.Select(ti=>ti.ToTweetImageDto()),
                TweetReactionsCount = tweet.GetTweetReactionCounts()
            };
        }

        public static IEnumerable<TweetReactionCountDto> GetTweetReactionCounts(this Tweet tweet)
        {
            var tweetReactionCounts = new List<TweetReactionCountDto>();
            int reactionCount;
            var reactions = tweet.TweetReactions.Select(tr => tr.Reaction).Distinct();
            foreach(var reaction in reactions)
            {
                reactionCount = tweet.TweetReactions.Where(tw => tw.Reaction == reaction).Count();
                tweetReactionCounts.Add(new TweetReactionCountDto
                {
                    Reaction = reaction.ToReactionDto(),
                    ReactionCount = reactionCount
                });

            }
            return tweetReactionCounts;
        }
    }
}
