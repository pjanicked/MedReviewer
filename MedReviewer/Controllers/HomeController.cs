using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Okta.Sdk;
using Okta.Sdk.Configuration;

namespace MedReviewer.Controllers
{
    public class HomeController : Controller
    {        
        [Authorize]
        public ActionResult HomePage()
        {
            //var client = new OktaClient(new OktaClientConfiguration
            //{
            //    OktaDomain = "https://{{yourOktaDomain}}",
            //    Token = "{{yourApiToken}}"
            //});

            var a = HttpContext.GetOwinContext().Authentication.User;
            return View();
        }
    }
}