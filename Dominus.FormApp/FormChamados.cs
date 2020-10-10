using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormChamados : Form
    {
        public FormChamados()
        {
            InitializeComponent();
        }

        private void FormChamados_Shown(object sender, EventArgs e)
        {
            CarregarGridChamados();
            btnExibirChamado.Enabled = gridChamados.SelectedRows.Count > 0;
            btnResponderChamado.Enabled = gridChamados.SelectedRows.Count > 0 &&
                gridChamados.SelectedRows[0].Cells["ChamadoRespondido"].Value?.ToString() == "Não";
        }

        private void CarregarGridChamados()
        {
            List<Chamado> chamados = ChamadoManager.GetChamadosAbertos();
            gridChamados.DataSource = chamados.OrderByDescending(x => x.DataCriacao).ToList();

            foreach (DataGridViewRow row in gridChamados.Rows)
            {
                try
                {
                    // Verifica se o chamado já foi respondido:
                    DataGridViewTextBoxCell suporte = (DataGridViewTextBoxCell)row.Cells["ChamadoIdUsuarioSuporte"];
                    row.Cells["ChamadoRespondido"].Value = !String.IsNullOrWhiteSpace(suporte.Value?.ToString()) ? "Sim" : "Não";
                    // Exibe a data de criação do chamado em um formato mais amigável:
                    DataGridViewTextBoxCell dataCell = (DataGridViewTextBoxCell)row.Cells["ChamadoDataCriacao"];
                    row.Cells["ChamadoData"].Value = Convert.ToDateTime(dataCell.Value?.ToString()).ToString("dd/MM/yyyy");
                }
                catch (Exception) { }
            }
        }

        private void GridChamados_SelectionChanged(object sender, EventArgs e)
        {
            btnResponderChamado.Enabled = gridChamados.SelectedRows.Count > 0 &&
                gridChamados.SelectedRows[0].Cells["ChamadoRespondido"].Value?.ToString() == "Não";
        }

        private void BtnExibirChamado_Click(object sender, EventArgs e)
        {
            if (btnResponderChamado.Enabled = gridChamados.SelectedRows.Count > 0)
            {
                Chamado chamado = (Chamado)gridChamados.SelectedRows[0].DataBoundItem;
                ExibirMensagensChamado(chamado);
            }
        }

        private void BtnResponderChamado_Click(object sender, EventArgs e)
        {
            if (btnResponderChamado.Enabled = gridChamados.SelectedRows.Count > 0)
            {
                Chamado chamado = (Chamado)gridChamados.SelectedRows[0].DataBoundItem;
                FormResponderChamado form = new FormResponderChamado(chamado);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CarregarGridChamados();
                    MessageBox.Show("A resposta do chamado foi gravada com sucesso.", "Chamado atualizado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnExibirChamado_EnabledChanged(object sender, EventArgs e)
        {
            btnExibirChamado.BackColor = btnExibirChamado.Enabled ? Color.SteelBlue : Color.LightSteelBlue;
        }

        private void BtnResponderChamado_EnabledChanged(object sender, EventArgs e)
        {
            btnResponderChamado.BackColor = btnResponderChamado.Enabled ? Color.SteelBlue : Color.LightSteelBlue;
        }

        private void GridChamados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Chamado chamado = (Chamado)gridChamados.Rows[e.RowIndex].DataBoundItem;
                ExibirMensagensChamado(chamado);
            }
        }

        private void ExibirMensagensChamado(Chamado chamado)
        {
            FormMensagensChamado form = new FormMensagensChamado(chamado);
            if (form.ShowDialog() == DialogResult.OK)
            {
                CarregarGridChamados();
            }
        }
    }
}
