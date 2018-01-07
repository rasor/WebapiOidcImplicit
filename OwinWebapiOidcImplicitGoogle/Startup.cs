using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(OwinWebapiOidcImplicitGoogle.Startup))]

namespace OwinWebapiOidcImplicitGoogle
{
    /// <summary>
    /// https://www.syncfusion.com/resources/techportal/details/ebooks/owin
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            // Cors is needed for implicit flow
            // http://benfoster.io/blog/aspnet-webapi-cors
            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);

            //app.Run(context => context.Response.WriteAsync("Hello World!"));
        }
    }
}
