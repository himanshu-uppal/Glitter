using Business.Abstract;
using Glitter.Business.CustomActionFilters;
using Glitter.Business.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Glitter.Business.Controllers
{

    public class ReactionController:ApiController
    {
        private readonly ITweetManager _tweetManager;
        private readonly IUserManager _userManager;
        private readonly IReactionManager _reactionManager;
        public ReactionController(ITweetManager tweetManager, IReactionManager reactionManager, IUserManager userManager)
        {
            _tweetManager = tweetManager;
            _reactionManager = reactionManager;
            _userManager = userManager;
        }

        [UserAuthenticationFilter]
        [HttpPost]
        public HttpResponseMessage PostReaction(string tweetKey, string reactionKey)
        {
            var userToken = HttpContext.Current.User.Identity.Name;
            var userEmail = TokenManager.GetEmailFromToken(userToken);
            var user = _userManager.GetUserByEmail(userEmail);
            if (user != null)
            {
                Guid guidTweetKey = new Guid(tweetKey);
                Guid guidReactionkey = new Guid(reactionKey);

                var tweet = _tweetManager.GetTweet(guidTweetKey);
                if (tweet == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                var reaction = _reactionManager.GetReaction(guidReactionkey);
                if(reaction == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                if (_reactionManager.AddReaction(user, tweet, reaction))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
            

        }

        [UserAuthenticationFilter]
        [HttpDelete]
        public HttpResponseMessage DeleteReaction(string tweetKey, string reactionKey)
        {
            var userToken = HttpContext.Current.User.Identity.Name;
            var userEmail = TokenManager.GetEmailFromToken(userToken);
            var user = _userManager.GetUserByEmail(userEmail);
            if (user != null)
            {
                Guid guidTweetKey = new Guid(tweetKey);
                Guid guidReactionkey = new Guid(reactionKey);

                var tweet = _tweetManager.GetTweet(guidTweetKey);
                if (tweet == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                var reaction = _reactionManager.GetReaction(guidReactionkey);
                if (reaction == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                if (_reactionManager.RemoveReaction(user, tweet, reaction))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);


        }
    }
}
