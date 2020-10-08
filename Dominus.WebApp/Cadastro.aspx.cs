using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Web.UI.WebControls;

namespace Dominus.WebApp
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Response.Redirect("Logoff?ReturnUrl=Cadastro", true);
            }
            txtNome.Focus();
        }

        protected void TermosUso_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = chkTermosUso.Checked;
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            // Limpa a mensagem de alerta, caso haja algum texto:
            lblMsg.Text = String.Empty;

            // Valida se os campos estão preenchidos:
            if (String.IsNullOrWhiteSpace(txtNome.Value))
            {
                txtNome.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtLogin.Value))
            {
                txtLogin.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtEmail.Value) || !UsuarioManager.ValidarEmail(txtEmail.Value))
            {
                txtEmail.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtSenha.Value))
            {
                txtSenha.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtVerificarSenha.Value) || !txtVerificarSenha.Value.Equals(txtSenha.Value))
            {
                lblMsg.Text = "As senhas não conferem!";
                txtSenha.Focus();
                return;
            }
            if (!chkTermosUso.Checked)
            {
                return;
            }

            try
            {
                Usuario usuario = UsuarioManager.GetUsuarioByEmail(txtEmail.Value);
                if (usuario != null)
                {
                    txtEmail.Focus();
                    lblMsg.Text = "O e-mail fornecido já possui cadastro no sistema. Utilize um outro e-mail ou recupere sua senha.";
                    return;
                }
                usuario = UsuarioManager.GetUsuarioByLogin(txtLogin.Value);
                if (usuario != null)
                {
                    txtLogin.Focus();
                    lblMsg.Text = "O sistema já possui o login digitado. Escolha um outro nome.";
                    return;
                }
                if (!UsuarioManager.ValidarSenha(txtSenha.Value))
                {
                    lblMsg.Text = "A senha fornecida não atende à política de senhas do Dominus";
                    txtSenha.Focus();
                    return;
                }

                UsuarioManager.AddUsuario(new Usuario()
                {
                    Nome = txtNome.Value,
                    Login = txtLogin.Value,
                    Email = txtEmail.Value,
                    Senha = Codificador.Criptografar(txtSenha.Value)
                });

                usuario = UsuarioManager.GetUsuarioByLogin(txtLogin.Value);
                Sessao.IniciarSessao(usuario);

                Response.Redirect("Resumo", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}