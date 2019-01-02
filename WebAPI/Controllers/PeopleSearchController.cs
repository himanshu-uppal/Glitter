using Business.Abstract;
using Glitter.Business.Extensions.ModelDtoExtensions;
using Shared.DTOs;
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

    

    public class PeopleSearchController:ApiController
    {
        private readonly IUserManager _userManager;
        public PeopleSearchController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("api/peoplesearch/{key}")]
        public HttpResponseMessage GetPeopleSearched(string key)
        {
            var people = _userManager.SearchPeople(key).Select(sp => sp.ToUserDto());
            PeopleSearchResponseDto peopleDto = new PeopleSearchResponseDto
            {
                People = people,
                PeopleCount = people.Count()
            };
            return Request.CreateResponse(HttpStatusCode.OK, peopleDto);
         
        }
    }
}
