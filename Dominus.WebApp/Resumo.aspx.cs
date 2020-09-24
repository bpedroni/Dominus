using System;

namespace Dominus.WebApp
{
    public partial class Resumo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login?ReturnUrl=Resumo", true);
            }
        }
    }
}