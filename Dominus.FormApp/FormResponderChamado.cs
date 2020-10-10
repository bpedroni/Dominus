using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Drawing;
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
            // Valida se o campo de resposta est preenchido:
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
