using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MedReviewer.Core.Operation;
using MedReviewer.Filters;
using Okta.Sdk;
using Okta.Sdk.Configuration;

namespace MedReviewer.Controllers
{
    [CustomActionFilter]
    public class HomeController : Controller
    {
        private readonly AccountOperation _accountOperation;

        public HomeController()
        {
            _accountOperation = new AccountOperation();
        }

        [Authorize]
        public ActionResult HomePage()
        {
            try
            {
                var user = _accountOperation.CreateUser();
                return View();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}