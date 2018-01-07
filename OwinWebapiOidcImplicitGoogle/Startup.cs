using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(OwinWebapiOidcImplicitGoogle.Startup))]

namespace OwinWebapiOidcImplicitGoogle
{
    /// <summary>
    /// Used by the OWIN module
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

            var config = new HttpConfiguration();
            ConfigureJsonResponse(config);
            app.UseWebApi(config);

            //app.Run(context => context.Response.WriteAsync("Hello World!"));
        }

        /// <summary>
        /// return response as JSON https://gist.github.com/robzhu/804171e2b90cc2a2958f
        /// </summary>
        /// <param name="config"></param>
        private static void ConfigureJsonResponse(HttpConfiguration config)
        {
            var defaultSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter>
                        {
                            new StringEnumConverter{ CamelCaseText = true },
                        }
            };

            JsonConvert.DefaultSettings = () => { return defaultSettings; };

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings = defaultSettings;
        }
    }
}
