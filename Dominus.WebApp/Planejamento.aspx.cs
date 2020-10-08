using Dominus.DataModel;
using System;

namespace Dominus.WebApp
{
    public partial class Planejamento : System.Web.UI.Page
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
                Response.Redirect("Login?ReturnUrl=Planejamento", true);
            }
        }
    }
}