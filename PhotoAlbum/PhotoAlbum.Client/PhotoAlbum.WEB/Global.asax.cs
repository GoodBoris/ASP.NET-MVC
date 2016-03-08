using System;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PhotoAlbum.WEB
{
    public class MvcApplication : HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Notify developer for uncaught errors by email
            var exception = Server.GetLastError();
            if (exception == null)
                return;
            var mail = new MailMessage { From = new MailAddress("automated@album.com") };
            mail.To.Add(new MailAddress("billarionov@themsteam.com"));
            mail.Subject = "Site Error at " + DateTime.Now;
            mail.Body = "Error Description: " + exception.Message;
            var server = new SmtpClient { Host = "mail" };
            server.Send(mail);
            //Server.ClearError();
        }
    }
}