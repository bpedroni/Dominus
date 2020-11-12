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
            InitializeComponent();
            Chamado = chamado;
            if (Chamado != null)
            {
                lblTituloMensagem.Text = Chamado.Titulo;

                Usuario usuario = ChamadoManager.GetUsuario(Chamado);
                lblUsuario.Text = "  - " + usuario.Nome + ":";

                txtMensagem.Text = Chamado.Mensagem;
                txtMensagem.Height += txtMensagem.GetPositionFromCharIndex(txtMensagem.Text.Length - 1).Y + 3 + txtMensagem.Font.Height - txtMensagem.ClientSize.Height;

                int correcao = txtMensagem.Height - 20;

                lblResposta.Location = new Point(15, 92 + correcao);

                txtResposta.Location = new Point(17, 114 + correcao);
                txtResposta.Height -= correcao;
            }
        }

        private void BtnEnviar_Click(object sender, System.EventArgs e)
        {
            // Valida se o campo de resposta está preenchido:
            if (String.IsNullOrWhiteSpace(txtResposta.Text))
            {
                MessageBox.Show("A resposta não pode ser nula.", "A resposta é obrigatória!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResposta.Focus();
                return;
            }

            try
            {
                Chamado.MensagemResposta = txtResposta.Text;
                Chamado.IdUsuarioSuporte = LoginInfo.Usuario.IdUsuario;
                Chamado.DataResposta = DateTime.Now;

                ChamadoManager.EditChamado(Chamado);

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
                MessageBox.Show("Erro ao enviar resposta. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
