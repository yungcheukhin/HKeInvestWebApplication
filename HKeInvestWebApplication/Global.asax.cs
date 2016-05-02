using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;

namespace HKeInvestWebApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Thread mythread = new Thread(PeriodicTask);
            mythread.IsBackground = true;
            mythread.Start();
        }
        private void PeriodicTask()
        {
            do
            {
                // Place the method call for the periodic task here.
                //if price in external table reach the value set in alert table, send email
                //add a attribute "lastsent" to indicate if today had sent
                Thread.Sleep(10000);
            } while (true);
        }
    }
}