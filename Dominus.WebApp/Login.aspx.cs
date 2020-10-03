using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;

namespace Dominus.WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] is Usuario)
            {
                Response.Redirect("Logoff?ReturnUrl=Login", true);
            }
            txtLogin.Focus();
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            // Limpa a mensagem de alerta, caso haja algum texto:
            lblMsg.Text = String.Empty;

            // Valida se os campos de login e senha estão preenchidos:
            if (String.IsNullOrWhiteSpace(txtLogin.Value))
            {
                txtLogin.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtSenha.Value))
            {
                txtSenha.Focus();
                return;
            }

            try
            {
                // Valida se o login e senha fornecidos pelo usuário:
                // O método de validação retorna o usuário ou null se as credenciais forem inválidas:
                Usuario usuario = UsuarioManager.ValidarUsuario(txtLogin.Value.Trim(), txtSenha.Value);

                if (usuario == null)
                {
                    // Alerta o usuário que as credenciais estão inválidas:
                    lblMsg.Text = "O login ou a senha estão inválidos.";
                    return;
                }

                Sessao.IniciarSessao(usuario);

                string strRedirect = Request["ReturnUrl"] ?? "Resumo";
                Response.Redirect(strRedirect, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}