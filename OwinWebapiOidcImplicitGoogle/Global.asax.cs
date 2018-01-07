using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace OwinWebapiOidcImplicitGoogle
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //replaced by app.UseWebApi
            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
