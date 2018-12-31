using Business.Abstract;
using Glitter.Business.Extensions.ModelDtoExtensions;
using Shared.DTOs;
using Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Glitter.Business.Extensions.RequestModelExtensions;
using System.Net;
using System.Net.Http;


namespace Glitter.Business.Controllers
{
    

    public class RegisterController:ApiController
    {
       
        private readonly IUserManager _userManager;
        public RegisterController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public string GetRegister()
        {
            return "himanshu";
        }

      
        [HttpPost]       
        public HttpResponseMessage PostRegister([FromBody]UserRequestModel userRequestModel)
        {
                   
            if (ModelState.IsValid)
            {             

                var createUserResult = _userManager.CreateUser(userRequestModel.ToUser(),userRequestModel.Password);

                if(createUserResult.Entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, createUserResult.Entity.ToUserDto());
                   
                }
                return Request.CreateResponse(HttpStatusCode.Conflict);



            }
           
            return Request.CreateResponse(HttpStatusCode.BadRequest);


            
        }
    }
}
