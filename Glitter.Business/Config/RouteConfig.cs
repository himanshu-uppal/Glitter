using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;

namespace Glitter.Business.Config
{
    public class RouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            var routes = config.Routes;
            routes.MapHttpRoute(
                    "ReactionHttpRoute",
                    "api/tweet/{tweetKey}/{controller}/{reactionKey}",
                    defaults: new {controller = "Reaction" });

            routes.MapHttpRoute(
                    "DefaultHttpRoute",
                    "api/{controller}/{key}",
                    defaults: new {  key = RouteParameter.Optional });
            // constraints: new { key = new GuidRouteConstraint() });

            routes.MapHttpRoute(
                    "Default",
                    "api/{controller}/{key}",
                    defaults: new { key = RouteParameter.Optional });
        }
    }
}
