using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Web.UI;

namespace Dominus.WebApp
{
    public partial class RecuperarSenha : Page
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
            lblMsg.CssClass = "text-danger";

            try
            {
                if (String.IsNullOrWhiteSpace(txtEmail.Value) || txtEmail.Value.Trim().Length > 100 || !UsuarioManager.ValidarEmail(txtEmail.Value))
                {
                    lblMsg.Text = "Endereço de e-mail inválido!";
                    return;
                }
                Usuario usuario = UsuarioManager.GetUsuarioByEmail(txtEmail.Value.Trim());
                if (usuario == null)
                {
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