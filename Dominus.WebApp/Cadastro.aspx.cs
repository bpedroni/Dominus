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
                Sessao.EncerrarSessao();
            }
            if (!IsPostBack)
            {
                txtNome.Focus();
            }
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
            if (String.IsNullOrWhiteSpace(txtNome.Value) || txtNome.Value.Trim().Length > 100)
            {
                lblMsg.Text = "O nome deve ser preenchido com até 100 caracteres.";
                txtNome.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtLogin.Value) || txtLogin.Value.Trim().Length > 15)
            {
                lblMsg.Text = "O login deve ser preenchido com até 15 caracteres.";
                txtLogin.Focus();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtLogin.Value.Trim(), @"^[a-zA-Z0-9_]+$"))
            {
                lblMsg.Text = "O login deve conter apenas letras, números ou '_'(sublinhado).";
                txtLogin.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtEmail.Value) || txtEmail.Value.Trim().Length > 100 || !UsuarioManager.ValidarEmail(txtEmail.Value))
            {
                lblMsg.Text = "O e-mail deve ser preenchido com até 100 caracteres.";
                txtEmail.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtSenha.Value))
            {
                lblMsg.Text = "A senha deve ser preenchida.";
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
                Usuario usuario = UsuarioManager.GetUsuarioByEmail(txtEmail.Value.Trim());
                if (usuario != null)
                {
                    lblMsg.Text = "O e-mail fornecido já possui cadastro no sistema. Utilize um outro e-mail ou recupere sua senha.";
                    txtEmail.Focus();
                    return;
                }
                usuario = UsuarioManager.GetUsuarioByLogin(txtLogin.Value.Trim());
                if (usuario != null)
                {
                    lblMsg.Text = "O sistema já possui o login digitado. Escolha um outro nome.";
                    txtLogin.Focus();
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
                    Nome = txtNome.Value.Trim(),
                    Login = txtLogin.Value.Trim(),
                    Email = txtEmail.Value.Trim(),
                    Senha = Codificador.Criptografar(txtSenha.Value)
                });

                usuario = UsuarioManager.GetUsuarioByLogin(txtLogin.Value.Trim());
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