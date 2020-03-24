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
                //var UserId = currentUser.Claims.Where(a => a.Type == "aud").FirstOrDefault().Value;
                var UserId = currentUser.Claims.Where(a => a.Type == "sub").FirstOrDefault().Value; //sub is unique
                var UserName = currentUser.Claims.Where(a => a.Type == "name").FirstOrDefault().Value;
                var UserEmail = currentUser.Claims.Where(a => a.Type == "email").FirstOrDefault().Value;

                filterContext.Controller.ViewBag.UserInfo = new { userId = UserId, userName = UserName, userEmail = UserEmail };
                HelperClass.UserSession.OktaUserId = UserId;
                HelperClass.UserSession.UserName = UserName;
                HelperClass.UserSession.UserEmail = UserEmail;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}