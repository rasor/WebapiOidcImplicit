using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(OwinWebapiOidcImplicitGoogle.Startup))]

namespace OwinWebapiOidcImplicitGoogle
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            // http://appetere.com/post/getting-started-with-openid-connect 
            app.SetDefaultSignInAsAuthenticationType("External Bearer");

            var notifications = new OpenIdConnectAuthenticationNotifications()
            {
                RedirectToIdentityProvider = (context) =>
                {
                    Debug.WriteLine("*** RedirectToIdentityProvider");
                    return Task.FromResult(0);
                },
                MessageReceived = (context) =>
                {
                    Debug.WriteLine("*** MessageReceived");
                    return Task.FromResult(0);
                },
                SecurityTokenReceived = (context) =>
                {
                    Debug.WriteLine("*** SecurityTokenReceived");
                    return Task.FromResult(0);
                },
                SecurityTokenValidated = (context) =>
                {
                    Debug.WriteLine("*** SecurityTokenValidated");
                    return Task.FromResult(0);
                },
                AuthorizationCodeReceived = (context) =>
                {
                    Debug.WriteLine("*** AuthorizationCodeReceived");
                    return Task.FromResult(0);
                },
                AuthenticationFailed = (context) =>
                {
                    Debug.WriteLine("*** AuthenticationFailed");
                    return Task.FromResult(0);
                },
            };

            // https://www.microsoftpressstore.com/articles/article.aspx?p=2473126&seqNum=2 
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                // For debugging - remove for production
                Notifications = notifications,

                ClientId = "347457883359-64didimqg2m9ci0o007lng94uf01pkqv.apps.googleusercontent.com", // rasor's public
                ClientSecret = "1kKy4GKzHisovEt6eoX34ZTW",
                // https://accounts.google.com/.well-known/openid-configuration
                Authority = "https://accounts.google.com",
                RedirectUri = "https://localhost/Client/",

                // "id_token" just returns the ID token.
                // "id_token token" also returns the ID token and the access token
                ResponseType = "id_token token",
                // ResponseMode = "fragment",
                Scope = "openid email profile",
                
                // CallbackPath = new PathString("/openid"),

                // This rest server is not supposed to do the login for the client - only to verify bearer token
                // Don't redirect outgoing 401 to login
                AuthenticationMode = AuthenticationMode.Passive
            });
        }
    }
}
