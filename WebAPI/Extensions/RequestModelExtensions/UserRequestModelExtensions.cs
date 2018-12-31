using Glitter.DataAccess.Entities;
using Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.Business.Extensions.RequestModelExtensions
{
    public static class UserRequestModelExtensions
    {
        public static User ToUser(this UserRequestModel userRequestModel)
        {
            return new User
            {           
                FirstName = userRequestModel.FirstName,
                LastName = userRequestModel.LastName,
                Email = userRequestModel.Email,
                ProfileImageData = userRequestModel.ProfileImageData,
                ProfileImageMimeType = userRequestModel.ProfileImageMimeType,
                ContactNumber = userRequestModel.ContactNumber,
                Country  = userRequestModel.Country
            };

        }
    }
}
