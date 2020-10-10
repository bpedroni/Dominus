using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormMensagensChamado : Form
    {
        private static Chamado Chamado;

        public FormMensagensChamado(Chamado chamado)
        {
            InitializeComponent();
            Chamado = chamado;
            if (Chamado != null)
            {
                lblTituloMensagem.Text = Chamado.Titulo;
                btnResponderChamado.Visible = Chamado.IdUsuarioSuporte == null;

                ExibirMensagem(Chamado);
            }
        }

        private void ExibirMensagem(Chamado chamado)
        {
            if (chamado.IdChamadoAssociado != null)
            {
                Chamado chamadoAssociado = ChamadoManager.GetChamadoById((Guid)chamado.IdChamadoAssociado);
                ExibirMensagem(chamadoAssociado);
            }

            Usuario usuario = ChamadoManager.GetUsuario(chamado);
            AdicionarMensagem(chamado.Mensagem, usuario.Nome, chamado.DataCriacao);

            Usuario usuarioSuporte = ChamadoManager.GetUsuarioSuporte(chamado);
            if (usuarioSuporte != null)
            {
                AdicionarMensagem(chamado.MensagemResposta, usuarioSuporte.Nome, (DateTime)chamado.DataResposta);
            }
        }

        private void AdicionarMensagem(String mensagem, String usuario, DateTime data)
        {
            Label lbl = new Label();
            lbl.Dock = DockStyle.Bottom;
            lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold); ;
            lbl.Height = 25;
            lbl.Padding = new Padding(10, 5, 0, 0);
            lbl.Text = "  - " + usuario + data.ToString(" (dd/MM/yyyy HH:mm:ss):");
            pnlMensagens.Controls.Add(lbl);

            TextBox txt = new TextBox();
            txt.Dock = DockStyle.Bottom;
            txt.ReadOnly = true;
            txt.Multiline = true;
            txt.TabStop = false;
            txt.Height = 100;
            txt.Text = mensagem;
            pnlMensagens.Controls.Add(txt);
            txt.Height = 25 + (txt.GetPositionFromCharIndex(txt.Text.Length - 1).Y - txt.GetPositionFromCharIndex(0).Y);

            Height = Math.Min(Height + lbl.Height + txt.Height, 800);
            CenterToScreen();
        }

        private void BtnResponderChamado_Click(object sender, EventArgs e)
        {
            FormResponderChamado form = new FormResponderChamado(Chamado);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Chamado = ChamadoManager.GetChamadoById(Chamado.IdChamado);

                Usuario usuarioSuporte = ChamadoManager.GetUsuarioSuporte(Chamado);
                if (usuarioSuporte != null)
                {
                    AdicionarMensagem(Chamado.MensagemResposta, usuarioSuporte.Nome, (DateTime)Chamado.DataResposta);
                }
                btnResponderChamado.Visible = Chamado.IdUsuarioSuporte == null;

                btnOk.DialogResult = DialogResult.OK;
                MessageBox.Show("A resposta do chamado foi gravada com sucesso.", "Chamado atualizado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
