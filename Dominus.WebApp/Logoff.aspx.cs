using System;
using System.Web.UI;

namespace Dominus.WebApp
{
    public partial class Logoff : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sessao.EncerrarSessao();
            string strRedirect = Request["ReturnUrl"] ?? "/";
            Response.Redirect(strRedirect, true);
        }
    }
}