using Business.Abstract;
using Glitter.Business.Providers;
using Glitter.DataAccess.Entities;
using Glitter.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Glitter.Business.CustomActionFilters
{
    public class UserAuthenticationFilter : AuthorizationFilterAttribute
    {
        
        /// <summary>
        /// read requested header and validated
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = FetchFromHeader(actionContext);

            if (token != null)
            {
                string email = TokenManager.GetEmailFromToken(token);
                var _userManager = (IUserManager)actionContext.Request.GetDependencyScope().GetService(typeof(IUserManager));
                if (email != null)
                {
                    User user = _userManager.GetUserByEmail(email);
                    if (user != null)
                    {
                         HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(token), null);
                                           }

                }               
                else
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    return;
                }
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return;
            }
            base.OnAuthorization(actionContext);
        }

        /// <summary>
        /// retrive header detail from the request 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        private string FetchFromHeader(HttpActionContext actionContext)
        {
            string requestToken = null;

            var authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null && !string.IsNullOrEmpty(authRequest.Scheme))
                requestToken = authRequest.Scheme;

            return requestToken;
        }
    }
}
