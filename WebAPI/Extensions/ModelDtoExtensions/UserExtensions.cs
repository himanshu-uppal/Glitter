using Glitter.DataAccess.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.Business.Extensions.ModelDtoExtensions
{
    public static class UserExtensions
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Key = user.Key,
                FirstName =user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = "",
                ProfileImageData = user.ProfileImageData,
                ProfileImageMimeType = user.ProfileImageMimeType,
                ContactNumber = user.ContactNumber,
                Country = user.Country,
                CreatedOn = user.CreatedOn
              

            };        

    }
    }
}
