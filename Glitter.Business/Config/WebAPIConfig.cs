using Glitter.Business.Formatting;
using Glitter.Business.MessageHandlers;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Validation;
using System.Web.Http.Validation.Providers;

namespace Glitter.Business.Config
{
    public class WebAPIConfig
    {
        public static void Configure(HttpConfiguration config)
        {

            // Web API configuration and services  
            // Configure Web API to use only bearer token authentication.  
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            //Formatters
            var jqueryFormatter = config.Formatters.FirstOrDefault(
            x => x.GetType() ==
            typeof(JQueryMvcFormUrlEncodedFormatter));
            config.Formatters.Remove(
            config.Formatters.FormUrlEncodedFormatter);
            config.Formatters.Remove(jqueryFormatter);
            foreach (var formatter in config.Formatters)
            {
                formatter.RequiredMemberSelector =
                new SuppressedRequiredMemberSelector();
            }
            //Default Services
            config.Services.Replace(
            typeof(IContentNegotiator),
            new DefaultContentNegotiator(
            excludeMatchOnTypeOnly: true));

            // Message Handlers
            //config.MessageHandlers.Add(
            //new RequireHttpsMessageHandler());

            config.Services.RemoveAll(
            typeof(ModelValidatorProvider),
               validator => !(validator
            is DataAnnotationsModelValidatorProvider));

 //           config.ParameterBindingRules.Insert(0,
 //descriptor => typeof(IRequestCommand)
 //.IsAssignableFrom(
 //descriptor.ParameterType)
 //? new FromUriAttribute()
 //.GetBinding(descriptor) : null);
        }
    }
}
