﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http.Cors;

namespace WebAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                   "ReactionHttpRoute",
                   "api/tweet/{tweetKey}/{controller}/{reactionKey}",
                   defaults: new { controller = "Reaction" });



            routes.MapHttpRoute(
                "DefaultHttpRoute",
                "api/{controller}/{key}",
                defaults: new { key = RouteParameter.Optional });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{key}",
                defaults: new { controller = "Home", action = "Index", key = RouteParameter.Optional }
            );
        }
    }
}
