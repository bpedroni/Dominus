using Dominus.DataModel;
using System;
using System.Web.UI;

namespace Dominus.WebApp
{
    public partial class Planejamento : Page
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
                Usuario = null;
                Response.Redirect("Login?ReturnUrl=Planejamento", true);
            }
        }
    }
}