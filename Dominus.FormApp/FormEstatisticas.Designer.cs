namespace Dominus.FormApp
{
    partial class FormEstatisticas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelModeloAnalise = new System.Windows.Forms.Label();
            this.cboModeloAnalise = new System.Windows.Forms.ComboBox();
            this.chartAnalise = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupAnalise = new System.Windows.Forms.GroupBox();
            this.panelGrupoUsuario = new System.Windows.Forms.Panel();
            this.rdoBtnAno = new System.Windows.Forms.RadioButton();
            this.rdoBtnMes = new System.Windows.Forms.RadioButton();
            this.rdoBtnDia = new System.Windows.Forms.RadioButton();
            this.panelGrupoCategoria = new System.Windows.Forms.Panel();
            this.rdoBtnFluxo = new System.Windows.Forms.RadioButton();
            this.rdoBtnCategoria = new System.Windows.Forms.RadioButton();
            this.labelAgrupamento = new System.Windows.Forms.Label();
            this.dataFinal = new System.Windows.Forms.DateTimePicker();
            this.labelDataFinal = new System.Windows.Forms.Label();
            this.dataInicial = new System.Windows.Forms.DateTimePicker();
            this.labelDataInicial = new System.Windows.Forms.Label();
            this.groupTipoGrafico = new System.Windows.Forms.GroupBox();
            this.rdoBtnGraficoArea = new System.Windows.Forms.RadioButton();
            this.rdoBtnGraficoPizza = new System.Windows.Forms.RadioButton();
            this.rdoBtnGraficoBarra = new System.Windows.Forms.RadioButton();
            this.rdoBtnGraficoColuna = new System.Windows.Forms.RadioButton();
            this.labelTipoGrafico = new System.Windows.Forms.Label();
            this.gridAnalise = new System.Windows.Forms.DataGridView();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnalise)).BeginInit();
            this.groupAnalise.SuspendLayout();
            this.panelGrupoUsuario.SuspendLayout();
            this.panelGrupoCategoria.SuspendLayout();
            this.groupTipoGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnalise)).BeginInit();
            this.SuspendLayout();
            // 
            // labelModeloAnalise
            // 
            this.labelModeloAnalise.AutoSize = true;
            this.labelModeloAnalise.Location = new System.Drawing.Point(12, 15);
            this.labelModeloAnalise.Name = "labelModeloAnalise";
            this.labelModeloAnalise.Size = new System.Drawing.Size(133, 18);
            this.labelModeloAnalise.TabIndex = 0;
            this.labelModeloAnalise.Text = "Modelo da Análise:";
            // 
            // cboModeloAnalise
            // 
            this.cboModeloAnalise.BackColor = System.Drawing.Color.Azure;
            this.cboModeloAnalise.DisplayMember = "Text";
            this.cboModeloAnalise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeloAnalise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModeloAnalise.FormattingEnabled = true;
            this.cboModeloAnalise.Location = new System.Drawing.Point(151, 12);
            this.cboModeloAnalise.Name = "cboModeloAnalise";
            this.cboModeloAnalise.Size = new System.Drawing.Size(302, 26);
            this.cboModeloAnalise.TabIndex = 1;
            this.cboModeloAnalise.ValueMember = "Value";
            this.cboModeloAnalise.SelectedIndexChanged += new System.EventHandler(this.CboModeloAnalise_SelectedIndexChanged);
            // 
            // chartAnalise
            // 
            this.chartAnalise.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LineColor = System.Drawing.Color.CornflowerBlue;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Title = "Escopo";
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.MidnightBlue;
            chartArea1.AxisX2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY.LineColor = System.Drawing.Color.CornflowerBlue;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.Title = "Quantidade";
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.MidnightBlue;
            chartArea1.AxisY2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.Name = "ChartAreaAnalise";
            chartArea1.ShadowColor = System.Drawing.Color.Black;
            this.chartAnalise.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "LegendAnalise";
            legend1.Title = "Legenda";
            this.chartAnalise.Legends.Add(legend1);
            this.chartAnalise.Location = new System.Drawing.Point(321, 205);
            this.chartAnalise.Name = "chartAnalise";
            series1.ChartArea = "ChartAreaAnalise";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "LegendAnalise";
            series1.Name = "SerieAnalise";
            this.chartAnalise.Series.Add(series1);
            this.chartAnalise.Size = new System.Drawing.Size(201, 94);
            this.chartAnalise.TabIndex = 18;
            this.chartAnalise.Text = "chartAnalise";
            title1.Name = "TitleAnalise";
            title1.Text = "Análise";
            this.chartAnalise.Titles.Add(title1);
            // 
            // groupAnalise
            // 
            this.groupAnalise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAnalise.BackColor = System.Drawing.Color.Transparent;
            this.groupAnalise.Controls.Add(this.panelGrupoUsuario);
            this.groupAnalise.Controls.Add(this.panelGrupoCategoria);
            this.groupAnalise.Controls.Add(this.labelAgrupamento);
            this.groupAnalise.Controls.Add(this.dataFinal);
            this.groupAnalise.Controls.Add(this.labelDataFinal);
            this.groupAnalise.Controls.Add(this.dataInicial);
            this.groupAnalise.Controls.Add(this.labelDataInicial);
            this.groupAnalise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupAnalise.Location = new System.Drawing.Point(15, 44);
            this.groupAnalise.Name = "groupAnalise";
            this.groupAnalise.Size = new System.Drawing.Size(507, 93);
            this.groupAnalise.TabIndex = 2;
            this.groupAnalise.TabStop = false;
            this.groupAnalise.Text = "Escopo da Análise";
            // 
            // panelGrupoUsuario
            // 
            this.panelGrupoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.panelGrupoUsuario.Controls.Add(this.rdoBtnAno);
            this.panelGrupoUsuario.Controls.Add(this.rdoBtnMes);
            this.panelGrupoUsuario.Controls.Add(this.rdoBtnDia);
            this.panelGrupoUsuario.Location = new System.Drawing.Point(112, 57);
            this.panelGrupoUsuario.Name = "panelGrupoUsuario";
            this.panelGrupoUsuario.Size = new System.Drawing.Size(394, 25);
            this.panelGrupoUsuario.TabIndex = 8;
            // 
            // rdoBtnAno
            // 
            this.rdoBtnAno.AutoSize = true;
            this.rdoBtnAno.Location = new System.Drawing.Point(141, 3);
            this.rdoBtnAno.Name = "rdoBtnAno";
            this.rdoBtnAno.Size = new System.Drawing.Size(52, 22);
            this.rdoBtnAno.TabIndex = 11;
            this.rdoBtnAno.Text = "Ano";
            this.rdoBtnAno.UseVisualStyleBackColor = true;
            this.rdoBtnAno.CheckedChanged += new System.EventHandler(this.RdoBtnAno_CheckedChanged);
            // 
            // rdoBtnMes
            // 
            this.rdoBtnMes.AutoSize = true;
            this.rdoBtnMes.Checked = true;
            this.rdoBtnMes.Location = new System.Drawing.Point(72, 3);
            this.rdoBtnMes.Name = "rdoBtnMes";
            this.rdoBtnMes.Size = new System.Drawing.Size(55, 22);
            this.rdoBtnMes.TabIndex = 10;
            this.rdoBtnMes.TabStop = true;
            this.rdoBtnMes.Text = "Mes";
            this.rdoBtnMes.UseVisualStyleBackColor = true;
            this.rdoBtnMes.CheckedChanged += new System.EventHandler(this.RdoBtnMes_CheckedChanged);
            // 
            // rdoBtnDia
            // 
            this.rdoBtnDia.AutoSize = true;
            this.rdoBtnDia.Location = new System.Drawing.Point(3, 3);
            this.rdoBtnDia.Name = "rdoBtnDia";
            this.rdoBtnDia.Size = new System.Drawing.Size(48, 22);
            this.rdoBtnDia.TabIndex = 9;
            this.rdoBtnDia.Text = "Dia";
            this.rdoBtnDia.UseVisualStyleBackColor = true;
            this.rdoBtnDia.CheckedChanged += new System.EventHandler(this.RdoBtnDia_CheckedChanged);
            // 
            // panelGrupoCategoria
            // 
            this.panelGrupoCategoria.BackColor = System.Drawing.Color.Transparent;
            this.panelGrupoCategoria.Controls.Add(this.rdoBtnFluxo);
            this.panelGrupoCategoria.Controls.Add(this.rdoBtnCategoria);
            this.panelGrupoCategoria.Location = new System.Drawing.Point(112, 57);
            this.panelGrupoCategoria.Name = "panelGrupoCategoria";
            this.panelGrupoCategoria.Size = new System.Drawing.Size(394, 25);
            this.panelGrupoCategoria.TabIndex = 8;
            this.panelGrupoCategoria.Visible = false;
            // 
            // rdoBtnFluxo
            // 
            this.rdoBtnFluxo.AutoSize = true;
            this.rdoBtnFluxo.Location = new System.Drawing.Point(114, 3);
            this.rdoBtnFluxo.Name = "rdoBtnFluxo";
            this.rdoBtnFluxo.Size = new System.Drawing.Size(115, 22);
            this.rdoBtnFluxo.TabIndex = 10;
            this.rdoBtnFluxo.Text = "Tipo de Fluxo";
            this.rdoBtnFluxo.UseVisualStyleBackColor = true;
            this.rdoBtnFluxo.CheckedChanged += new System.EventHandler(this.RdoBtnFluxo_CheckedChanged);
            // 
            // rdoBtnCategoria
            // 
            this.rdoBtnCategoria.AutoSize = true;
            this.rdoBtnCategoria.Checked = true;
            this.rdoBtnCategoria.Location = new System.Drawing.Point(3, 3);
            this.rdoBtnCategoria.Name = "rdoBtnCategoria";
            this.rdoBtnCategoria.Size = new System.Drawing.Size(90, 22);
            this.rdoBtnCategoria.TabIndex = 9;
            this.rdoBtnCategoria.TabStop = true;
            this.rdoBtnCategoria.Text = "Categoria";
            this.rdoBtnCategoria.UseVisualStyleBackColor = true;
            this.rdoBtnCategoria.CheckedChanged += new System.EventHandler(this.RdoBtnCategoria_CheckedChanged);
            // 
            // labelAgrupamento
            // 
            this.labelAgrupamento.AutoSize = true;
            this.labelAgrupamento.Location = new System.Drawing.Point(6, 61);
            this.labelAgrupamento.Name = "labelAgrupamento";
            this.labelAgrupamento.Size = new System.Drawing.Size(100, 18);
            this.labelAgrupamento.TabIndex = 7;
            this.labelAgrupamento.Text = "Agrupamento:";
            // 
            // dataFinal
            // 
            this.dataFinal.CustomFormat = "dd/MM/yyyy";
            this.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataFinal.Location = new System.Drawing.Point(323, 24);
            this.dataFinal.Name = "dataFinal";
            this.dataFinal.Size = new System.Drawing.Size(115, 24);
            this.dataFinal.TabIndex = 6;
            this.dataFinal.Value = System.DateTime.UtcNow.AddHours(-3);
            this.dataFinal.ValueChanged += new System.EventHandler(this.DataFinal_ValueChanged);
            // 
            // labelDataFinal
            // 
            this.labelDataFinal.AutoSize = true;
            this.labelDataFinal.Location = new System.Drawing.Point(239, 29);
            this.labelDataFinal.Name = "labelDataFinal";
            this.labelDataFinal.Size = new System.Drawing.Size(78, 18);
            this.labelDataFinal.TabIndex = 5;
            this.labelDataFinal.Text = "Data Final:";
            // 
            // dataInicial
            // 
            this.dataInicial.CustomFormat = "dd/MM/yyyy";
            this.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataInicial.Location = new System.Drawing.Point(95, 24);
            this.dataInicial.Name = "dataInicial";
            this.dataInicial.Size = new System.Drawing.Size(115, 24);
            this.dataInicial.TabIndex = 4;
            this.dataInicial.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dataInicial.ValueChanged += new System.EventHandler(this.DataInicial_ValueChanged);
            // 
            // labelDataInicial
            // 
            this.labelDataInicial.AutoSize = true;
            this.labelDataInicial.Location = new System.Drawing.Point(6, 29);
            this.labelDataInicial.Name = "labelDataInicial";
            this.labelDataInicial.Size = new System.Drawing.Size(83, 18);
            this.labelDataInicial.TabIndex = 3;
            this.labelDataInicial.Text = "Data Inicial:";
            // 
            // groupTipoGrafico
            // 
            this.groupTipoGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTipoGrafico.Controls.Add(this.rdoBtnGraficoArea);
            this.groupTipoGrafico.Controls.Add(this.rdoBtnGraficoPizza);
            this.groupTipoGrafico.Controls.Add(this.rdoBtnGraficoBarra);
            this.groupTipoGrafico.Controls.Add(this.rdoBtnGraficoColuna);
            this.groupTipoGrafico.Controls.Add(this.labelTipoGrafico);
            this.groupTipoGrafico.Location = new System.Drawing.Point(15, 144);
            this.groupTipoGrafico.Name = "groupTipoGrafico";
            this.groupTipoGrafico.Size = new System.Drawing.Size(506, 55);
            this.groupTipoGrafico.TabIndex = 12;
            this.groupTipoGrafico.TabStop = false;
            this.groupTipoGrafico.Text = "Tipo da Análise";
            // 
            // rdoBtnGraficoArea
            // 
            this.rdoBtnGraficoArea.AutoSize = true;
            this.rdoBtnGraficoArea.Location = new System.Drawing.Point(398, 23);
            this.rdoBtnGraficoArea.Name = "rdoBtnGraficoArea";
            this.rdoBtnGraficoArea.Size = new System.Drawing.Size(56, 22);
            this.rdoBtnGraficoArea.TabIndex = 17;
            this.rdoBtnGraficoArea.Text = "Área";
            this.rdoBtnGraficoArea.UseVisualStyleBackColor = true;
            this.rdoBtnGraficoArea.CheckedChanged += new System.EventHandler(this.RdoBtnGraficoArea_CheckedChanged);
            // 
            // rdoBtnGraficoPizza
            // 
            this.rdoBtnGraficoPizza.AutoSize = true;
            this.rdoBtnGraficoPizza.Location = new System.Drawing.Point(314, 23);
            this.rdoBtnGraficoPizza.Name = "rdoBtnGraficoPizza";
            this.rdoBtnGraficoPizza.Size = new System.Drawing.Size(63, 22);
            this.rdoBtnGraficoPizza.TabIndex = 16;
            this.rdoBtnGraficoPizza.Text = "Pizza";
            this.rdoBtnGraficoPizza.UseVisualStyleBackColor = true;
            this.rdoBtnGraficoPizza.CheckedChanged += new System.EventHandler(this.RdoBtnGraficoPizza_CheckedChanged);
            // 
            // rdoBtnGraficoBarra
            // 
            this.rdoBtnGraficoBarra.AutoSize = true;
            this.rdoBtnGraficoBarra.Location = new System.Drawing.Point(231, 23);
            this.rdoBtnGraficoBarra.Name = "rdoBtnGraficoBarra";
            this.rdoBtnGraficoBarra.Size = new System.Drawing.Size(62, 22);
            this.rdoBtnGraficoBarra.TabIndex = 15;
            this.rdoBtnGraficoBarra.Text = "Barra";
            this.rdoBtnGraficoBarra.UseVisualStyleBackColor = true;
            this.rdoBtnGraficoBarra.CheckedChanged += new System.EventHandler(this.RdoBtnGraficoBarra_CheckedChanged);
            // 
            // rdoBtnGraficoColuna
            // 
            this.rdoBtnGraficoColuna.AutoSize = true;
            this.rdoBtnGraficoColuna.Checked = true;
            this.rdoBtnGraficoColuna.Location = new System.Drawing.Point(137, 23);
            this.rdoBtnGraficoColuna.Name = "rdoBtnGraficoColuna";
            this.rdoBtnGraficoColuna.Size = new System.Drawing.Size(73, 22);
            this.rdoBtnGraficoColuna.TabIndex = 14;
            this.rdoBtnGraficoColuna.TabStop = true;
            this.rdoBtnGraficoColuna.Text = "Coluna";
            this.rdoBtnGraficoColuna.UseVisualStyleBackColor = true;
            this.rdoBtnGraficoColuna.CheckedChanged += new System.EventHandler(this.RdoBtnGraficoColuna_CheckedChanged);
            // 
            // labelTipoGrafico
            // 
            this.labelTipoGrafico.AutoSize = true;
            this.labelTipoGrafico.Location = new System.Drawing.Point(6, 25);
            this.labelTipoGrafico.Name = "labelTipoGrafico";
            this.labelTipoGrafico.Size = new System.Drawing.Size(110, 18);
            this.labelTipoGrafico.TabIndex = 13;
            this.labelTipoGrafico.Text = "Tipo de gráfico:";
            // 
            // gridAnalise
            // 
            this.gridAnalise.AllowUserToAddRows = false;
            this.gridAnalise.AllowUserToDeleteRows = false;
            this.gridAnalise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridAnalise.BackgroundColor = System.Drawing.Color.White;
            this.gridAnalise.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridAnalise.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.gridAnalise.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAnalise.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAnalise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAnalise.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Categoria,
            this.Valor});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAnalise.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridAnalise.EnableHeadersVisualStyles = false;
            this.gridAnalise.GridColor = System.Drawing.Color.DarkGoldenrod;
            this.gridAnalise.Location = new System.Drawing.Point(15, 205);
            this.gridAnalise.Name = "gridAnalise";
            this.gridAnalise.RowHeadersVisible = false;
            this.gridAnalise.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAnalise.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridAnalise.Size = new System.Drawing.Size(300, 94);
            this.gridAnalise.TabIndex = 18;
            // 
            // Categoria
            // 
            this.Categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.HeaderText = "Nome";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Quantidade";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Valor.Width = 108;
            // 
            // FormEstatisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.chartAnalise);
            this.Controls.Add(this.gridAnalise);
            this.Controls.Add(this.groupTipoGrafico);
            this.Controls.Add(this.cboModeloAnalise);
            this.Controls.Add(this.labelModeloAnalise);
            this.Controls.Add(this.groupAnalise);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEstatisticas";
            this.Text = "Estatísticas";
            this.Shown += new System.EventHandler(this.FormEstatisticas_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.chartAnalise)).EndInit();
            this.groupAnalise.ResumeLayout(false);
            this.groupAnalise.PerformLayout();
            this.panelGrupoUsuario.ResumeLayout(false);
            this.panelGrupoUsuario.PerformLayout();
            this.panelGrupoCategoria.ResumeLayout(false);
            this.panelGrupoCategoria.PerformLayout();
            this.groupTipoGrafico.ResumeLayout(false);
            this.groupTipoGrafico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnalise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelModeloAnalise;
        private System.Windows.Forms.ComboBox cboModeloAnalise;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnalise;
        private System.Windows.Forms.GroupBox groupAnalise;
        private System.Windows.Forms.Label labelDataInicial;
        private System.Windows.Forms.DateTimePicker dataInicial;
        private System.Windows.Forms.Label labelDataFinal;
        private System.Windows.Forms.DateTimePicker dataFinal;
        private System.Windows.Forms.RadioButton rdoBtnAno;
        private System.Windows.Forms.RadioButton rdoBtnMes;
        private System.Windows.Forms.RadioButton rdoBtnDia;
        private System.Windows.Forms.Label labelAgrupamento;
        private System.Windows.Forms.RadioButton rdoBtnFluxo;
        private System.Windows.Forms.RadioButton rdoBtnCategoria;
        private System.Windows.Forms.Panel panelGrupoUsuario;
        private System.Windows.Forms.Panel panelGrupoCategoria;
        private System.Windows.Forms.GroupBox groupTipoGrafico;
        private System.Windows.Forms.RadioButton rdoBtnGraficoArea;
        private System.Windows.Forms.RadioButton rdoBtnGraficoPizza;
        private System.Windows.Forms.RadioButton rdoBtnGraficoBarra;
        private System.Windows.Forms.RadioButton rdoBtnGraficoColuna;
        private System.Windows.Forms.Label labelTipoGrafico;
        private System.Windows.Forms.DataGridView gridAnalise;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
    }
}