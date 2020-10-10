using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;

namespace Dominus.WebApp
{
    public partial class RecuperarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Sessao.EncerrarSessao();
            }
            if (!IsPostBack)
            {
                txtEmail.Focus();
            }
        }

        protected void BtnRecuperarSenha_Click(object sender, EventArgs e)
        {
            // Limpa a mensagem de alerta, caso haja algum texto:
            lblMsg.Text = String.Empty;

            try
            {
                if (!String.IsNullOrWhiteSpace(txtEmail.Value) || txtEmail.Value.Trim().Length > 100 || !UsuarioManager.ValidarEmail(txtEmail.Value))
                {
                    lblMsg.CssClass = "text-danger";
                    lblMsg.Text = "Endereço de e-mail inválido!";
                    return;
                }
                Usuario usuario = UsuarioManager.GetUsuarioByEmail(txtEmail.Value.Trim());
                if (usuario == null)
                {
                    lblMsg.CssClass = "text-danger";
                    lblMsg.Text = "E-mail não cadastrado no sistema!";
                    return;
                }

                lblMsg.CssClass = "text-success";
                lblMsg.Text = "E-mail de recuperação enviado com sucesso!";
                UsuarioManager.EnviarSenhaPorEmail(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}