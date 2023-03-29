using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace final_web_app
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /*void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.Current.Session["userName"] = User.Identity.Name;
                HttpContext.Current.Session["sessionStart"] = DateTime.UtcNow;
            }
            else
            {
                return;
            }
        }*/

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            // Get the exception object.
            Exception exc = Server.GetLastError();


            string lastErrorTypeName = exc.GetType().ToString();
            string lastErrorMessage = exc.Message;
            string lastErrorStackTrace = exc.StackTrace;

            Debug.WriteLine(lastErrorTypeName);
            Debug.WriteLine(lastErrorMessage);
            Debug.WriteLine(lastErrorStackTrace);


            // Handle HTTP errors
            if (exc.GetType() == typeof(HttpException))
            {
                // The Complete Error Handling Example generates
                // some errors using URLs with “NoCatch” in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                    return;

                //Redirect HTTP errors to HttpError page
                Server.Transfer("~/HttpErrorPage.aspx");
            }
            else
            {

                //Server.Transfer("~/ErrorPages/Oops.aspx");
                Server.Transfer("~/Oops.aspx");
            }

            // Clear the error from the server
            Server.ClearError();
        }
    }
}