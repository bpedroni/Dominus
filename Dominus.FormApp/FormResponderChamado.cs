using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormResponderChamado : Form
    {
        private Chamado Chamado;

        public FormResponderChamado(Chamado chamado)
        {
            try
            {
                Chamado = chamado;
                if (Chamado != null)
                {
                    InitializeComponent();

                    lblTituloMensagem.Text = Chamado.Titulo;
                    lblUsuario.Text = "  - " + ChamadoManager.GetUsuario(Chamado).Nome + ":";
                    txtMensagem.Text = Chamado.Mensagem;
                    txtMensagem.Height += txtMensagem.GetPositionFromCharIndex(txtMensagem.Text.Length - 1).Y + 3 + txtMensagem.Font.Height - txtMensagem.ClientSize.Height;
                    txtResposta.Text = Chamado.MensagemResposta;

                    int correcao = txtMensagem.Height - 20;
                    lblResposta.Location = new Point(15, 92 + correcao);
                    txtResposta.Location = new Point(17, 114 + correcao);
                    txtResposta.Height -= correcao;
                }
                else
                {
                    MessageBox.Show("Nenhum chamado foi encontrado para ser respondido.", "Chamado não encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir o formulário de chamado. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEnviar_Click(object sender, System.EventArgs e)
        {
            // Valida se o campo de resposta está preenchido:
            if (String.IsNullOrWhiteSpace(txtResposta.Text.Replace(Chamado.MensagemResposta, String.Empty)))
            {
                MessageBox.Show("A resposta não pode ser nula.", "A resposta é obrigatória!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResposta.Focus();
                return;
            }
            try
            {
                Chamado.IdUsuarioSuporte = LoginInfo.Usuario.IdUsuario;
                Chamado.MensagemResposta = txtResposta.Text.Trim();

                ChamadoManager.EditRespostaChamado(Chamado);

                // Envia a mensagem de resposta ao e-mail do usuário que abriu o chamado:
                String msg = String.Format(
                    txtResposta.Text + Environment.NewLine + Environment.NewLine +
                    "****************************************************************************************************" + Environment.NewLine +
                    "Acesse o site do dominus e gerencie este retorno, enviando uma nova mensagem ou deixando o seu OK." + Environment.NewLine + Environment.NewLine +
                    "Resposta enviada ao contato realizado em " + Chamado.DataCriacao.ToString(@"dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR")) + Environment.NewLine +
                    "Mensagem enviada: " + Environment.NewLine + Chamado.Mensagem + Environment.NewLine +
                    "****************************************************************************************************" + Environment.NewLine + Environment.NewLine +
                    "Este é um envio automático de e-mail. Não é necessário respondê-lo"
                );
                Usuario usuario = UsuarioManager.GetUsuarioById(Chamado.IdUsuario);
                ChamadoManager.EnviarEmail(usuario.Email, "Retorno Dominus: " + Chamado.Titulo, msg);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                switch (ex.GetType().Name)
                {
                    case "ChamadoUsuarioException":
                        MessageBox.Show(ex.Message, "Erro ao encontrar o usuário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "ChamadoTituloException":
                        MessageBox.Show(ex.Message, "Erro ao encontrar o título da mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "ChamadoMensagemException":
                        MessageBox.Show(ex.Message, "Revise o preenchimento da resposta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtResposta.Focus();
                        break;
                    default:
                        MessageBox.Show("Erro ao enviar resposta. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void BtnCancelar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
