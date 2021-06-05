using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using Web.UserServiceReference;

[assembly: OwinStartup(typeof(Web.App_Start.Startup))]
namespace Web.App_Start
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.CreatePerOwinContext<IUserServiceApadterForOwinContext>(CreateUserService);

                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                });
            }

            private IUserServiceApadterForOwinContext CreateUserService()
            {
                return new UserServiceApadterForOwinContext();
            }
        }
    }