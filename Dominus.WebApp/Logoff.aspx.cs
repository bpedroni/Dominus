using System;

namespace Dominus.WebApp
{
    public partial class Logoff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sessao.EncerrarSessao();
            string strRedirect = Request["ReturnUrl"] ?? "/";
            Response.Redirect(strRedirect, true);
        }
    }
}