using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Web.UI;

namespace Dominus.WebApp
{
    public partial class Contato : Page
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
                    txtNome.Disabled = true;
                    txtEmail.Value = Usuario.Email;
                    txtEmail.Disabled = true;
                    txtAssunto.Focus();
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    txtNome.Focus();
                }
            }
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            // Limpa a mensagem de alerta, caso haja algum texto:
            lblMsg.Text = String.Empty;
            lblMsg.CssClass = "text-danger";

            // Valida se os campos estão preenchidos:
            if (String.IsNullOrWhiteSpace(txtNome.Value) || txtNome.Value.Trim().Length > 100)
            {
                lblMsg.Text = "O nome deve ser preenchido (até 100 caracteres).";
                txtNome.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtEmail.Value) || txtEmail.Value.Trim().Length > 100 || !UsuarioManager.ValidarEmail(txtEmail.Value))
            {
                lblMsg.Text = "O e-mail deve ser preenchido (até 100 caracteres).";
                txtEmail.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtAssunto.Value) || txtAssunto.Value.Trim().Length > 50)
            {
                lblMsg.Text = "O nome deve ser preenchido (até 50 caracteres).";
                txtAssunto.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtMensagem.Value) || txtMensagem.Value.Trim().Length > 1000)
            {
                lblMsg.Text = "O nome deve ser preenchido (até 1000 caracteres).";
                txtMensagem.Focus();
                return;
            }

            try
            {
                // Envia a mensagem de contato para a conta de e-mail do administrador do sistema:
                if (Usuario != null)
                {
                    ChamadoManager.EnviarMensagemContato(Usuario.Nome, Usuario.Email, txtAssunto.Value, txtMensagem.Value);

                    // Adiciona um chamado, caso o usuário esteja logado:
                    Chamado chamado = new Chamado
                    {
                        IdUsuario = Usuario.IdUsuario,
                        Titulo = txtAssunto.Value,
                        Mensagem = txtMensagem.Value,
                        MensagemResposta = "Olá, " + Usuario.Nome + "!"
                    };
                    ChamadoManager.AddChamado(chamado);
                }
                else
                {
                    ChamadoManager.EnviarMensagemContato(txtNome.Value, txtEmail.Value, txtAssunto.Value, txtMensagem.Value);
                }

                lblMsg.Text = "Sua mensagem foi enviada com sucesso.";
                lblMsg.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}