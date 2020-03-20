using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedReviewer.Core.Helpers;

namespace MedReviewer.Filters
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextBase ctx = filterContext.HttpContext;
            var rd = ctx.Request.RequestContext.RouteData;

            string currentController = rd.GetRequiredString("controller").ToLower();
            string currentAction = rd.GetRequiredString("action").ToLower();

            if(currentController == "review" && (currentAction == "addreview" || currentAction == "editreview"))
            {
                var userSession = ctx.Session;
                var token = filterContext.HttpContext.Request.Headers;
                if(token["cookie"] == null) 
                {
                    //--- CORS error ---//
                    filterContext.Result = new RedirectResult("/Account/Login");
                    //filterContext.Result = new RedirectResult("http://localhost:8080/authorization-code/callback");
                }
            }
            
            
            var currentUser = HttpContext.Current.GetOwinContext().Authentication.User;
            if (currentUser.Claims.ToList().Count > 0)
            {
                var UserId = currentUser.Claims.Where(a => a.Type == "aud").FirstOrDefault().Value;
                var UserName = currentUser.Claims.Where(a => a.Type == "name").FirstOrDefault().Value;

                filterContext.Controller.ViewBag.UserInfo = new { userId = UserId, userName = UserName };
                HelperClass.UserSession.OktaUserId = UserId;
                HelperClass.UserSession.UserName = UserName;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}