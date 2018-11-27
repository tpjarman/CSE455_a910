using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CSE445_A9A10
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {//Code that runs on application startup
            Application["SessionCounter"] = 0;
            //AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Session_Start(object sender, EventArgs e)
        {
            int count = (int)Application["SessionCounter"];
            count++;
            Application["SessionCounter"] = count;
        }
        void Application_End(object sender, EventArgs e)
        {//Code that runs on application shutdown
        }

        void Application_Error(object sender, EventArgs e)
        {//Code that runs when an unhandled error occurs
        }
    }
}