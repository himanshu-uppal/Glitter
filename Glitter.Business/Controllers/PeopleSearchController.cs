using Business.Abstract;
using Glitter.Business.Extensions.ModelDtoExtensions;
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
        public HttpResponseMessage GetPeopleSearched(string key)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userManager.SearchPeople(key).Select(sp=> sp.ToUserDto()));
        }
    }
}
