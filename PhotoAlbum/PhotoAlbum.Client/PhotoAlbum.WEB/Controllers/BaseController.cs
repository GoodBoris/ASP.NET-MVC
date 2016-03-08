using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using PhotoAlbum.WEB.HtmlHelpers.Models;

namespace PhotoAlbum.WEB.Controllers
{
    public class BaseController : Controller
    {
        //Initialize alerts globally for all application

        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message, dismissable);
        }


        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Danger, message, dismissable);
        }

        public ActionResult InitializeAlerts()
        {
            return PartialView("_Alerts");
        }
        //Adding alerts based on TempData
        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[Alert.TempDataKey] = alerts;
        }
        //Check if current user is really loged in user.
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionParameters.ContainsKey("currentUser"))
            {
                //It is clutch. 2.4 point of specification override my "/Photo/Manage/" action
                //Route config identify it like Photo is an User.
                if (filterContext.ActionParameters["currentUser"] as string == "Photo")
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Photo",
                        action = "Manage",
                        currentUser = User.Identity.Name
                    }));
                }
                else
                {
                    //Normal gloval validation user access to own profile only.
                    if (filterContext.ActionParameters["currentUser"] as string != User.Identity.Name)
                    {
                        Information("You do not have an access to another users settings");
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Photo",
                            action = "List"
                        }));
                    }
                }

            }
            base.OnActionExecuting(filterContext);
        }

        //Handle execeptions from parent controllers
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;
            // Here we can log errors
            TempData.Remove(Alert.TempDataKey);
            var exception = filterContext.Exception;
            //Get the specific error (last)
            if (exception.InnerException != null)
                while (exception.InnerException != null)
                    exception = exception.InnerException;

            //If we have an ajax request show error in modal popup otherwise in normal view
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = Json(new { success = false });
                filterContext.Result = View("_ModalError", exception.Message as object);
            }
            else
            {
                Danger("An error occured during your request");
                filterContext.Result = View("_Error", new HandleErrorInfo(exception,
                filterContext.RouteData.Values["controller"].ToString(),
                filterContext.RouteData.Values["action"].ToString()));
            }

            //Make sure that we mark the exception as handled
            filterContext.ExceptionHandled = true;
        }

        #region Helpers
        protected void AddErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        #endregion
    }
}