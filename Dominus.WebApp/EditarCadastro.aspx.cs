using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;

namespace Dominus.WebApp
{
    public partial class EditarCadastro : System.Web.UI.Page
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
                txtNome.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtLogin.Value) || txtLogin.Value.Trim().Length > 15)
            {
                txtLogin.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtSenha.Value) || txtSenha.Value.Trim().Length > 20)
            {
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
                Usuario = (Usuario)Session["Usuario"];
                throw ex;
            }
        }
    }
}