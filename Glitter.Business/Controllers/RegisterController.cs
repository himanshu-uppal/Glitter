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

namespace Glitter.Business.Controllers
{
    public class RegisterController:ApiController
    {
        private readonly IUserManager _userManager;
        public RegisterController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public string GetRegister()
        {
            return "register";
        }

        public UserDto PostRegister([FromBody]UserRequestModel userRequestModel)
        {
            UserDto userDto = new UserDto();


           
            if (ModelState.IsValid)
            {
               

                var createUserResult = _userManager.CreateUser(
                   userRequestModel.FirstName, userRequestModel.Email,userRequestModel.Password);

                if(createUserResult != null)
                {
                    userDto =  createUserResult.Entity.ToUserDto();
                }        
                    
                    
                



            }

            return userDto;



            

        }
    }
}
