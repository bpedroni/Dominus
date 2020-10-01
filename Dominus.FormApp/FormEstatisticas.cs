using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormEstatisticas : Form
    {
        private static Periodo periodo;
        private static GrupoTransacoes grupoTransacoes;
        private static List<Item> chartItems;

        public FormEstatisticas()
        {
            InitializeComponent();

            cboModeloAnalise.Items.Add(new ComboboxItem { Value = TipoAnalise.ChartUsuarios, Text = "Usuários cadastrados no sistema" });
            cboModeloAnalise.Items.Add(new ComboboxItem { Value = TipoAnalise.ChartCategorias, Text = "Categorias utilizadas no sistema" });
        }

        private void FormEstatisticas_Shown(object sender, EventArgs e)
        {
            periodo = Periodo.Mes;
            grupoTransacoes = GrupoTransacoes.Categoria;
            cboModeloAnalise.SelectedIndex = 0;
        }

        public void GerarDados()
        {
            ComboboxItem comboboxItem = (ComboboxItem)cboModeloAnalise.SelectedItem;
            if (chartItems != null)
            {
                chartItems.Clear();
            }

            switch (comboboxItem.Value)
            {
                case TipoAnalise.ChartUsuarios:
                    chartItems = EstatisticaManager.GetAnaliseUsuarios(dataInicial.Value, dataFinal.Value, periodo);
                    break;
                case TipoAnalise.ChartCategorias:
                    chartItems = EstatisticaManager.GetAnaliseCategorias(dataInicial.Value, dataFinal.Value, grupoTransacoes);
                    break;
                default:
                    break;
            }
            chartAnalise.Series[0].Points.Clear();
            gridAnalise.DataSource = chartItems;

            foreach (Item item in chartItems)
            {
                var point = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                point.SetValueXY(item.Categoria, item.Valor);
                point.ToolTip = string.Format("{0}: {1}", item.Categoria, item.Valor);
                chartAnalise.Series[0].Points.Add(point);
            }

            chartAnalise.Titles[0].Text = "# " + comboboxItem.Text;
        }

        private void CboModeloAnalise_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem comboboxItem = (ComboboxItem)cboModeloAnalise.SelectedItem;
            panelGrupoUsuario.Visible = comboboxItem.Value == TipoAnalise.ChartUsuarios;
            panelGrupoCategoria.Visible = comboboxItem.Value == TipoAnalise.ChartCategorias;

            GerarDados();
        }

        private void DataInicial_ValueChanged(object sender, EventArgs e)
        {
            GerarDados();
        }

        private void DataFinal_ValueChanged(object sender, EventArgs e)
        {
            GerarDados();
        }

        private void RdoBtnDia_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnDia.Checked)
            {
                periodo = Periodo.Dia;
                GerarDados();
            }
        }

        private void RdoBtnMes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnMes.Checked)
            {
                periodo = Periodo.Mes;
                GerarDados();
            }
        }

        private void RdoBtnAno_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnAno.Checked)
            {
                periodo = Periodo.Ano;
                GerarDados();
            }
        }

        private void RdoBtnCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnCategoria.Checked)
            {
                grupoTransacoes = GrupoTransacoes.Categoria;
                GerarDados();
            }
        }

        private void RdoBtnFluxo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnFluxo.Checked)
            {
                grupoTransacoes = GrupoTransacoes.TipoFluxo;
                GerarDados();
            }
        }

        private void RdoBtnGraficoColuna_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnGraficoColuna.Checked)
            {
                chartAnalise.Legends[0].Enabled = false;
                chartAnalise.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
        }

        private void RdoBtnGraficoBarra_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnGraficoBarra.Checked)
            {
                chartAnalise.Legends[0].Enabled = false;
                chartAnalise.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            }
        }

        private void RdoBtnGraficoPizza_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnGraficoPizza.Checked)
            {
                chartAnalise.Legends[0].Enabled = true;
                chartAnalise.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
        }

        private void RdoBtnGraficoArea_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBtnGraficoArea.Checked)
            {
                chartAnalise.Legends[0].Enabled = false;
                chartAnalise.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            }
        }
    }

    public enum TipoAnalise
    {
        ChartUsuarios,
        ChartCategorias
    }

    public class ComboboxItem
    {
        public TipoAnalise Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
