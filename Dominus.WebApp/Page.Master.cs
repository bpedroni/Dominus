using Dominus.DataModel;
using System;
using System.Web.UI;

namespace Dominus.WebApp
{
    public partial class Page : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioLogado() && Session["Usuario"] is Usuario usuario)
            {
                lblNomeUsuario.Text = usuario.Nome;
            }
        }

        protected bool UsuarioLogado()
        {
            return Session["Usuario"] != null;
        }
    }
}