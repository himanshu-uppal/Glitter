using Business.Abstract;
using Glitter.Business.Providers;
using Glitter.DataAccess.Entities;
using Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace Glitter.Business.Controllers
{
    
    public class LoginController:ApiController
    {
        private readonly IUserManager _userManager;
        public LoginController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public HttpResponseMessage Login([FromBody]LoginRequestModel loginRequestModel)
        {
            User user = _userManager.GetUserByEmail(loginRequestModel.Email);
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                     "The user was not found.");
            bool credentials = _userManager.ValidateUser(loginRequestModel.Email, loginRequestModel.Password);  //change hashedPasword to password
            if (!credentials) return Request.CreateResponse(HttpStatusCode.Forbidden,
                "The username/password combination was wrong.");
            return Request.CreateResponse(HttpStatusCode.OK,
                 TokenManager.GenerateToken(user.Email));
        }        

        //[HttpGet]
        //public HttpResponseMessage GetValidate(string token, string email)
        //{
        //    bool exists = _userManager.GetUserByEmail(email) != null;
        //    if (!exists) return Request.CreateResponse(HttpStatusCode.NotFound,
        //         "The user was not found.");
        //    string tokenEmail = "";// TokenManager.ValidateToken(token);
        //    if (email.Equals(tokenEmail))
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}
    }
}
