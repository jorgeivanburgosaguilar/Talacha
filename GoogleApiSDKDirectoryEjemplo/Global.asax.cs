using System;
using System.Web;
using DevExpress.Web;

namespace GoogleApiSDKDirectoryEjemplo
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = HttpContext.Current.Server.GetLastError();
            if (string.IsNullOrWhiteSpace(exception?.Message))
                return;

            ASPxWebControl.SetCallbackErrorMessage(exception.Message);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}