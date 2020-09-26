using Dominus.DataModel;
using System;
using System.Web.UI;

namespace Dominus.WebApp
{
    public partial class Site : MasterPage
    {
        protected static bool UsuarioConectado = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] is Usuario usuario)
            {
                UsuarioConectado = true;
                lblNomeUsuario.Text = usuario.Nome;
            }
            else
            {
                UsuarioConectado = false;
            }
        }
    }
}