using System;
using System.Web.Security;

namespace Dominus.WebApp
{
    public partial class Logoff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            string strRedirect = Request["ReturnUrl"] ?? "/";
            Response.Redirect(strRedirect, true);
        }
    }
}