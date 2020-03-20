using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MedReviewer.Filters;
using Okta.Sdk;
using Okta.Sdk.Configuration;

namespace MedReviewer.Controllers
{
    [CustomActionFilter]
    public class HomeController : Controller
    {        
        //[Authorize]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}