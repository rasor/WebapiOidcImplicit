﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OwinWebapiOidcImplicitGoogle
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // moved to OWIN, so also auth will return JSON - startup.cs
            //config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
