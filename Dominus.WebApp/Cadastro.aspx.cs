using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dominus.WebApp
{
    public partial class Cadastro : Page
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
            try
            {
                // Limpa a mensagem de alerta, caso haja algum texto:
                lblMsg.Text = String.Empty;

                if (!chkTermosUso.Checked)
                {
                    lblMsg.Text = "É necessário aceitar os termos de uso!";
                    return;
                }
                Usuario usuario = new Usuario()
                {
                    Nome = txtNome.Value.Trim(),
                    Login = txtLogin.Value.Trim(),
                    Email = txtEmail.Value.Trim(),
                    Senha = Codificador.Criptografar(txtSenha.Value)
                };
                UsuarioManager.AddUsuario(usuario);
                usuario = UsuarioManager.GetUsuarioByLogin(txtLogin.Value.Trim());
                Sessao.IniciarSessao(usuario);

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
                    case "UsuarioEmailException":
                        txtEmail.Focus();
                        break;
                    case "UsuarioSenhaException":
                        txtSenha.Focus();
                        break;
                    default:
                        throw ex;
                }
                lblMsg.Text = ex.Message;
            }
        }
    }
}