using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Web.UI;

namespace Dominus.WebApp
{
    public partial class EditarCadastro : Page
    {
        protected static Usuario Usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario = (Usuario)Session["Usuario"];
                if (!IsPostBack)
                {
                    txtNome.Value = Usuario.Nome;
                    txtLogin.Value = Usuario.Login;
                }
            }
            else
            {
                Response.Redirect("Login", true);
            }
        }

        protected void BtnEditarCadastro_Click(object sender, EventArgs e)
        {
            // Limpa a mensagem de alerta, caso haja algum texto:
            lblMsg.Text = String.Empty;

            // Valida se os campos estão preenchidos:
            if (String.IsNullOrWhiteSpace(txtNome.Value) || txtNome.Value.Trim().Length > 100)
            {
                lblMsg.Text = "O nome deve ser preenchido (até 100 caracteres).";
                txtNome.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtLogin.Value) || txtLogin.Value.Trim().Length < 4 || txtLogin.Value.Trim().Length > 15)
            {
                lblMsg.Text = "O login deve ser preenchido (de 4 até 15 caracteres).";
                txtLogin.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtSenha.Value) || txtSenha.Value.Trim().Length < 8 || txtSenha.Value.Trim().Length > 20)
            {
                lblMsg.Text = "A senha deve ser preenchida (de 8 até 20 caracteres).";
                txtSenha.Focus();
                return;
            }
            if (chkAlterarSenha.Checked && (String.IsNullOrWhiteSpace(txtVerificarSenha.Value) || !txtVerificarSenha.Value.Equals(txtNovaSenha.Value)))
            {
                lblMsg.Text = "As senhas não conferem!";
                txtSenha.Focus();
                return;
            }
            try
            {
                if (UsuarioManager.ValidarUsuario(Usuario.Login, txtSenha.Value) == null)
                {
                    lblMsg.Text = "A senha digitada está incorreta.";
                    txtSenha.Focus();
                    return;
                }
                if (Usuario.Login != txtLogin.Value.Trim() && UsuarioManager.GetUsuarioByLogin(txtLogin.Value.Trim()) != null)
                {
                    txtLogin.Focus();
                    lblMsg.Text = "O sistema já possui o login digitado. Escolha um outro nome.";
                    return;
                }
                if (chkAlterarSenha.Checked)
                {
                    if (!UsuarioManager.ValidarSenha(txtNovaSenha.Value))
                    {
                        lblMsg.Text = "A nova senha fornecida não atende à política de senhas do Dominus";
                        txtNovaSenha.Focus();
                        return;
                    }
                    Usuario.Senha = Codificador.Criptografar(txtNovaSenha.Value);
                }
                Usuario.Nome = txtNome.Value.Trim();
                Usuario.Login = txtLogin.Value.Trim();
                UsuarioManager.EditUsuario(Usuario);

                Usuario = UsuarioManager.GetUsuarioByEmail(Usuario.Email);
                Sessao.IniciarSessao(Usuario);

                Response.Redirect("Resumo", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}