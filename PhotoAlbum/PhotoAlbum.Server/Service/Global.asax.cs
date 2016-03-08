using System;
using System.Web;

namespace Service
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AutoMapperConfig.RegisterMappings();
            AutofacConfig.RegisterDependencys();
        }
    }
}