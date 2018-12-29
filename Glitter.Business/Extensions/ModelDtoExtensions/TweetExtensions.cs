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
            IEnumerable<TweetReactionDto> tweetReactionDtos = null;
            IEnumerable<CommentDto> commentDtos = null;
            IEnumerable<string> tweetHashtagDtos = null;
            IEnumerable<string> tweetImagesDtos = null;

            if (tweet.TweetReactions != null)
            {
                tweetReactionDtos = tweet.TweetReactions.Select(tr => tr.ToTweetReactionDto());
            }
            if (tweet.Comments != null)
            {
                commentDtos = tweet.Comments.Select(c => c.ToCommentDto());
            }
            if (tweet.TweetHashtags !=null)
            {
                tweetHashtagDtos = tweet.TweetHashtags.Select(th => th.ToTweetHashtagDto());
            }
            if (tweet.TweetImages !=null)
            {
                tweetImagesDtos = tweet.TweetImages.Select(ti => ti.ToTweetImageDto());
            }
            return new TweetDto
            {
                Key = tweet.Key,
                Message = tweet.Message,
                CreatedOn = tweet.CreatedOn,
                LastUpdatedOn = tweet.LastUpdatedOn,
                User = tweet.User.ToUserDto(),
                TweetReactions = tweetReactionDtos,
                Comments = commentDtos,
                TweetHashtags = tweetHashtagDtos,
                TweetImages = tweetImagesDtos,
                TweetReactionsCount = tweet.GetTweetReactionCounts()
            };
        }

        public static IEnumerable<TweetReactionCountDto> GetTweetReactionCounts(this Tweet tweet)
        {
            var tweetReactionCounts = new List<TweetReactionCountDto>();
            int reactionCount;
            if(tweet.TweetReactions != null)
            {
                var reactions = tweet.TweetReactions.Select(tr => tr.Reaction).Distinct();
                foreach (var reaction in reactions)
                {
                    reactionCount = tweet.TweetReactions.Where(tw => tw.Reaction == reaction).Count();
                    tweetReactionCounts.Add(new TweetReactionCountDto
                    {
                        Reaction = reaction.ToReactionDto(),
                        ReactionCount = reactionCount
                    });

                }

            }            
            return tweetReactionCounts;
        }
    }
}
