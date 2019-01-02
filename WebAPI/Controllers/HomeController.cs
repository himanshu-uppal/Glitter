using Business.Abstract;
using Glitter.Business.CustomActionFilters;
using Glitter.Business.Extensions.ModelDtoExtensions;
using Glitter.Business.Providers;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Glitter.Business.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }

}
