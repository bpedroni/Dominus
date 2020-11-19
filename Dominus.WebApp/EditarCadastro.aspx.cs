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
                Usuario = null;
                Response.Redirect("Login", true);
            }
        }

        protected void BtnEditarCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpa a mensagem de alerta, caso haja algum texto:
                lblMsg.Text = String.Empty;

                Usuario usuario = new Usuario
                {
                    IdUsuario = Usuario.IdUsuario,
                    Nome = txtNome.Value.Trim(),
                    Login = txtLogin.Value.Trim(),
                    Email = Usuario.Email,
                    Senha = Codificador.Criptografar(txtSenha.Value)
                };

                if (usuario.Senha != Usuario.Senha)
                {
                    lblMsg.Text = "A senha digitada não corresponde à senha cadastrada.";
                    txtSenha.Focus();
                    return;
                }
                if (chkAlterarSenha.Checked)
                {
                    if (!txtVerificarSenha.Value.Equals(txtNovaSenha.Value))
                    {
                        lblMsg.Text = "A nova senha digitada está diferente do campo de validação.";
                        txtNovaSenha.Focus();
                        return;
                    }
                    usuario.Senha = Codificador.Criptografar(txtNovaSenha.Value);
                }

                UsuarioManager.EditUsuario(usuario);
                Usuario = UsuarioManager.GetUsuarioById(usuario.IdUsuario);
                Sessao.IniciarSessao(Usuario);
                Response.Redirect("Resumo", true);
            }
            catch (Exception ex)
            {
                switch (ex.GetType().Name)
                {
                    case "UsuarioNomeException":
                        txtNome.Focus();
                        break;
                    case "UsuarioLoginException":
                        txtLogin.Focus();
                        break;
                    case "UsuarioSenhaException":
                        txtSenha.Focus();
                        break;
                    case "UsuarioEmailException":
                    default:
                        throw ex;
                }
                lblMsg.Text = ex.Message;
                chkAlterarSenha.Checked = false;
            }
        }
    }
}