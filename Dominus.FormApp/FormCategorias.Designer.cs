using FontAwesome.Sharp;

namespace Dominus.FormApp
{
    partial class FormCategorias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFiltroCategoria = new System.Windows.Forms.TextBox();
            this.labelFiltroCategoria = new System.Windows.Forms.Label();
            this.btnAdicionarCategoria = new FontAwesome.Sharp.IconButton();
            this.btnFiltrarCategoria = new FontAwesome.Sharp.IconButton();
            this.gridCategorias = new System.Windows.Forms.DataGridView();
            this.CategoriaIdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaTipoFluxo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaSenha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaDataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaDataExclusao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaAtivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CategoriaTransacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaPlanejamentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.CategoriaExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFiltroCategoria
            // 
            this.txtFiltroCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFiltroCategoria.Location = new System.Drawing.Point(132, 12);
            this.txtFiltroCategoria.Name = "txtFiltroCategoria";
            this.txtFiltroCategoria.Size = new System.Drawing.Size(200, 24);
            this.txtFiltroCategoria.TabIndex = 1;
            this.txtFiltroCategoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFiltroCategoria_KeyDown);
            // 
            // labelFiltroCategoria
            // 
            this.labelFiltroCategoria.AutoSize = true;
            this.labelFiltroCategoria.Location = new System.Drawing.Point(12, 15);
            this.labelFiltroCategoria.Name = "labelFiltroCategoria";
            this.labelFiltroCategoria.Size = new System.Drawing.Size(114, 18);
            this.labelFiltroCategoria.TabIndex = 0;
            this.labelFiltroCategoria.Text = "Filtrar categoria:";
            // 
            // btnAdicionarCategoria
            // 
            this.btnAdicionarCategoria.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdicionarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarCategoria.FlatAppearance.BorderSize = 0;
            this.btnAdicionarCategoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdicionarCategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdicionarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarCategoria.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnAdicionarCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarCategoria.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarCategoria.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAdicionarCategoria.IconColor = System.Drawing.Color.White;
            this.btnAdicionarCategoria.IconSize = 24;
            this.btnAdicionarCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarCategoria.Location = new System.Drawing.Point(15, 50);
            this.btnAdicionarCategoria.Name = "btnAdicionarCategoria";
            this.btnAdicionarCategoria.Rotation = 0D;
            this.btnAdicionarCategoria.Size = new System.Drawing.Size(190, 30);
            this.btnAdicionarCategoria.TabIndex = 3;
            this.btnAdicionarCategoria.Text = "Adicionar Categoria";
            this.btnAdicionarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdicionarCategoria.UseVisualStyleBackColor = false;
            this.btnAdicionarCategoria.Click += new System.EventHandler(this.BtnAdicionarCategoria_Click);
            // 
            // btnFiltrarCategoria
            // 
            this.btnFiltrarCategoria.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFiltrarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrarCategoria.FlatAppearance.BorderSize = 0;
            this.btnFiltrarCategoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnFiltrarCategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFiltrarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrarCategoria.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnFiltrarCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarCategoria.ForeColor = System.Drawing.Color.White;
            this.btnFiltrarCategoria.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnFiltrarCategoria.IconColor = System.Drawing.Color.White;
            this.btnFiltrarCategoria.IconSize = 20;
            this.btnFiltrarCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrarCategoria.Location = new System.Drawing.Point(338, 12);
            this.btnFiltrarCategoria.Name = "btnFiltrarCategoria";
            this.btnFiltrarCategoria.Rotation = 0D;
            this.btnFiltrarCategoria.Size = new System.Drawing.Size(85, 25);
            this.btnFiltrarCategoria.TabIndex = 2;
            this.btnFiltrarCategoria.Text = "Filtrar";
            this.btnFiltrarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrarCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrarCategoria.UseVisualStyleBackColor = false;
            this.btnFiltrarCategoria.Click += new System.EventHandler(this.BtnFiltrarCategoria_Click);
            // 
            // gridCategorias
            // 
            this.gridCategorias.AllowUserToAddRows = false;
            this.gridCategorias.AllowUserToDeleteRows = false;
            this.gridCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCategorias.BackgroundColor = System.Drawing.Color.White;
            this.gridCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCategorias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.gridCategorias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoriaIdCategoria,
            this.CategoriaNome,
            this.CategoriaDescricao,
            this.CategoriaTipoFluxo,
            this.CategoriaSenha,
            this.CategoriaDataCriacao,
            this.CategoriaDataExclusao,
            this.CategoriaAtivo,
            this.CategoriaTransacoes,
            this.CategoriaPlanejamentos,
            this.CategoriaEditar,
            this.CategoriaExcluir});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCategorias.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridCategorias.EnableHeadersVisualStyles = false;
            this.gridCategorias.GridColor = System.Drawing.Color.DarkGoldenrod;
            this.gridCategorias.Location = new System.Drawing.Point(12, 86);
            this.gridCategorias.MultiSelect = false;
            this.gridCategorias.Name = "gridCategorias";
            this.gridCategorias.RowHeadersVisible = false;
            this.gridCategorias.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCategorias.Size = new System.Drawing.Size(510, 213);
            this.gridCategorias.TabIndex = 4;
            this.gridCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCategorias_CellContentClick);
            this.gridCategorias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCategorias_CellDoubleClick);
            // 
            // CategoriaIdCategoria
            // 
            this.CategoriaIdCategoria.DataPropertyName = "IdCategoria";
            this.CategoriaIdCategoria.HeaderText = "IdCategoria";
            this.CategoriaIdCategoria.Name = "CategoriaIdCategoria";
            this.CategoriaIdCategoria.ReadOnly = true;
            this.CategoriaIdCategoria.Visible = false;
            // 
            // CategoriaNome
            // 
            this.CategoriaNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CategoriaNome.DataPropertyName = "Nome";
            this.CategoriaNome.HeaderText = "Nome";
            this.CategoriaNome.Name = "CategoriaNome";
            this.CategoriaNome.ReadOnly = true;
            // 
            // CategoriaDescricao
            // 
            this.CategoriaDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CategoriaDescricao.DataPropertyName = "Descricao";
            this.CategoriaDescricao.HeaderText = "Descrição";
            this.CategoriaDescricao.Name = "CategoriaDescricao";
            this.CategoriaDescricao.ReadOnly = true;
            this.CategoriaDescricao.Visible = false;
            // 
            // CategoriaTipoFluxo
            // 
            this.CategoriaTipoFluxo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CategoriaTipoFluxo.DataPropertyName = "TipoFluxo";
            this.CategoriaTipoFluxo.HeaderText = "Tipo Fluxo";
            this.CategoriaTipoFluxo.Name = "CategoriaTipoFluxo";
            this.CategoriaTipoFluxo.ReadOnly = true;
            this.CategoriaTipoFluxo.Width = 102;
            // 
            // CategoriaSenha
            // 
            this.CategoriaSenha.DataPropertyName = "Icone";
            this.CategoriaSenha.HeaderText = "Ícone";
            this.CategoriaSenha.Name = "CategoriaSenha";
            this.CategoriaSenha.ReadOnly = true;
            this.CategoriaSenha.Visible = false;
            // 
            // CategoriaDataCriacao
            // 
            this.CategoriaDataCriacao.DataPropertyName = "DataCriacao";
            this.CategoriaDataCriacao.HeaderText = "DataCriacao";
            this.CategoriaDataCriacao.Name = "CategoriaDataCriacao";
            this.CategoriaDataCriacao.ReadOnly = true;
            this.CategoriaDataCriacao.Visible = false;
            // 
            // CategoriaDataExclusao
            // 
            this.CategoriaDataExclusao.DataPropertyName = "DataExclusao";
            this.CategoriaDataExclusao.HeaderText = "DataExclusao";
            this.CategoriaDataExclusao.Name = "CategoriaDataExclusao";
            this.CategoriaDataExclusao.ReadOnly = true;
            this.CategoriaDataExclusao.Visible = false;
            // 
            // CategoriaAtivo
            // 
            this.CategoriaAtivo.DataPropertyName = "Ativo";
            this.CategoriaAtivo.FalseValue = "0";
            this.CategoriaAtivo.HeaderText = "Ativo";
            this.CategoriaAtivo.Name = "CategoriaAtivo";
            this.CategoriaAtivo.ReadOnly = true;
            this.CategoriaAtivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CategoriaAtivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CategoriaAtivo.TrueValue = "1";
            this.CategoriaAtivo.Visible = false;
            // 
            // CategoriaTransacoes
            // 
            this.CategoriaTransacoes.DataPropertyName = "Transacoes";
            this.CategoriaTransacoes.HeaderText = "Transacoes";
            this.CategoriaTransacoes.Name = "CategoriaTransacoes";
            this.CategoriaTransacoes.ReadOnly = true;
            this.CategoriaTransacoes.Visible = false;
            // 
            // CategoriaPlanejamentos
            // 
            this.CategoriaPlanejamentos.DataPropertyName = "Planejamentos";
            this.CategoriaPlanejamentos.HeaderText = "Planejamentos";
            this.CategoriaPlanejamentos.Name = "CategoriaPlanejamentos";
            this.CategoriaPlanejamentos.ReadOnly = true;
            this.CategoriaPlanejamentos.Visible = false;
            // 
            // CategoriaEditar
            // 
            this.CategoriaEditar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CategoriaEditar.HeaderText = "Editar";
            this.CategoriaEditar.Name = "CategoriaEditar";
            this.CategoriaEditar.ToolTipText = "Editar categoria";
            this.CategoriaEditar.Width = 52;
            // 
            // CategoriaExcluir
            // 
            this.CategoriaExcluir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CategoriaExcluir.HeaderText = "Excluir";
            this.CategoriaExcluir.Name = "CategoriaExcluir";
            this.CategoriaExcluir.ToolTipText = "Excluir categoria";
            this.CategoriaExcluir.Width = 58;
            // 
            // FormCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.gridCategorias);
            this.Controls.Add(this.btnAdicionarCategoria);
            this.Controls.Add(this.btnFiltrarCategoria);
            this.Controls.Add(this.txtFiltroCategoria);
            this.Controls.Add(this.labelFiltroCategoria);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCategorias";
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.FormCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnFiltrarCategoria;
        private System.Windows.Forms.TextBox txtFiltroCategoria;
        private System.Windows.Forms.Label labelFiltroCategoria;
        private FontAwesome.Sharp.IconButton btnAdicionarCategoria;
        private System.Windows.Forms.DataGridView gridCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaIdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaTipoFluxo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaSenha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaDataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaDataExclusao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CategoriaAtivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaTransacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaPlanejamentos;
        private System.Windows.Forms.DataGridViewImageColumn CategoriaEditar;
        private System.Windows.Forms.DataGridViewImageColumn CategoriaExcluir;
    }
}