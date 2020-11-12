using Dominus.DataModel;
using System;
using System.Web.UI;

namespace Dominus.WebApp
{
    public partial class Relatorios : Page
    {
        protected static Usuario Usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario = (Usuario)Session["Usuario"];
            }
            else
            {
                Response.Redirect("Login?ReturnUrl=Relatorios", true);
            }
        }
    }
}