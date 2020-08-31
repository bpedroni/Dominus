namespace Dominus.FormApp
{
    partial class FormPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPerfisUsuario = new System.Windows.Forms.TabPage();
            this.gridPerfisUsuario = new System.Windows.Forms.DataGridView();
            this.IdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Senha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerfilAdministrador = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Planejamentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Relatorios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario_Salvar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAtualizarPerfis = new System.Windows.Forms.Button();
            this.tabCategorias = new System.Windows.Forms.TabPage();
            this.btnExcluirCategoria = new System.Windows.Forms.Button();
            this.btnEditarCategoria = new System.Windows.Forms.Button();
            this.btnAdicionarCategoria = new System.Windows.Forms.Button();
            this.gridCategorias = new System.Windows.Forms.DataGridView();
            this.IdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoFluxo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Icone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanejamentosCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransacoesCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPerfisUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPerfisUsuario)).BeginInit();
            this.tabCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPerfisUsuario);
            this.tabControl.Controls.Add(this.tabCategorias);
            this.tabControl.Location = new System.Drawing.Point(13, 81);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(759, 468);
            this.tabControl.TabIndex = 0;
            // 
            // tabPerfisUsuario
            // 
            this.tabPerfisUsuario.Controls.Add(this.gridPerfisUsuario);
            this.tabPerfisUsuario.Controls.Add(this.btnAtualizarPerfis);
            this.tabPerfisUsuario.Location = new System.Drawing.Point(4, 27);
            this.tabPerfisUsuario.Name = "tabPerfisUsuario";
            this.tabPerfisUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPerfisUsuario.Size = new System.Drawing.Size(751, 437);
            this.tabPerfisUsuario.TabIndex = 0;
            this.tabPerfisUsuario.Text = "Perfil de Usuário";
            this.tabPerfisUsuario.UseVisualStyleBackColor = true;
            // 
            // gridPerfisUsuario
            // 
            this.gridPerfisUsuario.AllowUserToAddRows = false;
            this.gridPerfisUsuario.AllowUserToDeleteRows = false;
            this.gridPerfisUsuario.BackgroundColor = System.Drawing.Color.White;
            this.gridPerfisUsuario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridPerfisUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPerfisUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUsuario,
            this.Nome,
            this.Login,
            this.Email,
            this.Senha,
            this.PerfilAdministrador,
            this.Planejamentos,
            this.Relatorios,
            this.Transacoes,
            this.Usuario_Salvar});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPerfisUsuario.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridPerfisUsuario.EnableHeadersVisualStyles = false;
            this.gridPerfisUsuario.Location = new System.Drawing.Point(20, 75);
            this.gridPerfisUsuario.MultiSelect = false;
            this.gridPerfisUsuario.Name = "gridPerfisUsuario";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPerfisUsuario.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridPerfisUsuario.RowHeadersVisible = false;
            this.gridPerfisUsuario.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPerfisUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPerfisUsuario.Size = new System.Drawing.Size(707, 340);
            this.gridPerfisUsuario.TabIndex = 6;
            this.gridPerfisUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPerfisUsuario_CellContentClick);
            // 
            // IdUsuario
            // 
            this.IdUsuario.DataPropertyName = "IdUsuario";
            this.IdUsuario.HeaderText = "IdUsuario";
            this.IdUsuario.Name = "IdUsuario";
            this.IdUsuario.ReadOnly = true;
            this.IdUsuario.Visible = false;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Login
            // 
            this.Login.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Login.DataPropertyName = "Login";
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            this.Login.Width = 77;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Visible = false;
            // 
            // Senha
            // 
            this.Senha.DataPropertyName = "Senha";
            this.Senha.HeaderText = "Senha";
            this.Senha.Name = "Senha";
            this.Senha.ReadOnly = true;
            this.Senha.Visible = false;
            // 
            // PerfilAdministrador
            // 
            this.PerfilAdministrador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PerfilAdministrador.DataPropertyName = "PerfilAdministrador";
            this.PerfilAdministrador.FalseValue = "0";
            this.PerfilAdministrador.HeaderText = "Administrador";
            this.PerfilAdministrador.Name = "PerfilAdministrador";
            this.PerfilAdministrador.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PerfilAdministrador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PerfilAdministrador.TrueValue = "1";
            this.PerfilAdministrador.Width = 144;
            // 
            // Planejamentos
            // 
            this.Planejamentos.DataPropertyName = "Planejamentos";
            this.Planejamentos.HeaderText = "Planejamentos";
            this.Planejamentos.Name = "Planejamentos";
            this.Planejamentos.ReadOnly = true;
            this.Planejamentos.Visible = false;
            // 
            // Relatorios
            // 
            this.Relatorios.DataPropertyName = "Relatorios";
            this.Relatorios.HeaderText = "Relatorios";
            this.Relatorios.Name = "Relatorios";
            this.Relatorios.ReadOnly = true;
            this.Relatorios.Visible = false;
            // 
            // Transacoes
            // 
            this.Transacoes.DataPropertyName = "Transacoes";
            this.Transacoes.HeaderText = "Transacoes";
            this.Transacoes.Name = "Transacoes";
            this.Transacoes.ReadOnly = true;
            this.Transacoes.Visible = false;
            // 
            // Usuario_Salvar
            // 
            this.Usuario_Salvar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Usuario_Salvar.HeaderText = "Atualizar";
            this.Usuario_Salvar.Name = "Usuario_Salvar";
            this.Usuario_Salvar.Text = "Salvar";
            this.Usuario_Salvar.ToolTipText = "Salvar perfil de usuário";
            this.Usuario_Salvar.UseColumnTextForButtonValue = true;
            this.Usuario_Salvar.Width = 85;
            // 
            // btnAtualizarPerfis
            // 
            this.btnAtualizarPerfis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizarPerfis.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAtualizarPerfis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAtualizarPerfis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtualizarPerfis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarPerfis.ForeColor = System.Drawing.Color.White;
            this.btnAtualizarPerfis.Location = new System.Drawing.Point(20, 20);
            this.btnAtualizarPerfis.Name = "btnAtualizarPerfis";
            this.btnAtualizarPerfis.Size = new System.Drawing.Size(260, 35);
            this.btnAtualizarPerfis.TabIndex = 5;
            this.btnAtualizarPerfis.Text = "Atualizar Perfis";
            this.btnAtualizarPerfis.UseVisualStyleBackColor = false;
            this.btnAtualizarPerfis.Click += new System.EventHandler(this.BtnAtualizarPerfis_Click);
            // 
            // tabCategorias
            // 
            this.tabCategorias.Controls.Add(this.btnExcluirCategoria);
            this.tabCategorias.Controls.Add(this.btnEditarCategoria);
            this.tabCategorias.Controls.Add(this.btnAdicionarCategoria);
            this.tabCategorias.Controls.Add(this.gridCategorias);
            this.tabCategorias.Location = new System.Drawing.Point(4, 27);
            this.tabCategorias.Name = "tabCategorias";
            this.tabCategorias.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategorias.Size = new System.Drawing.Size(751, 437);
            this.tabCategorias.TabIndex = 1;
            this.tabCategorias.Text = "Categorias";
            this.tabCategorias.UseVisualStyleBackColor = true;
            // 
            // btnExcluirCategoria
            // 
            this.btnExcluirCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluirCategoria.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExcluirCategoria.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExcluirCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcluirCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirCategoria.ForeColor = System.Drawing.Color.White;
            this.btnExcluirCategoria.Location = new System.Drawing.Point(412, 20);
            this.btnExcluirCategoria.Name = "btnExcluirCategoria";
            this.btnExcluirCategoria.Size = new System.Drawing.Size(180, 35);
            this.btnExcluirCategoria.TabIndex = 10;
            this.btnExcluirCategoria.Text = "Excluir";
            this.btnExcluirCategoria.UseVisualStyleBackColor = false;
            this.btnExcluirCategoria.Click += new System.EventHandler(this.BtnExcluirCategoria_Click);
            // 
            // btnEditarCategoria
            // 
            this.btnEditarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarCategoria.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEditarCategoria.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEditarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCategoria.ForeColor = System.Drawing.Color.White;
            this.btnEditarCategoria.Location = new System.Drawing.Point(216, 20);
            this.btnEditarCategoria.Name = "btnEditarCategoria";
            this.btnEditarCategoria.Size = new System.Drawing.Size(180, 35);
            this.btnEditarCategoria.TabIndex = 9;
            this.btnEditarCategoria.Text = "Editar";
            this.btnEditarCategoria.UseVisualStyleBackColor = false;
            this.btnEditarCategoria.Click += new System.EventHandler(this.BtnEditarCategoria_Click);
            // 
            // btnAdicionarCategoria
            // 
            this.btnAdicionarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarCategoria.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdicionarCategoria.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAdicionarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionarCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarCategoria.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarCategoria.Location = new System.Drawing.Point(20, 20);
            this.btnAdicionarCategoria.Name = "btnAdicionarCategoria";
            this.btnAdicionarCategoria.Size = new System.Drawing.Size(180, 35);
            this.btnAdicionarCategoria.TabIndex = 8;
            this.btnAdicionarCategoria.Text = "Adicionar";
            this.btnAdicionarCategoria.UseVisualStyleBackColor = false;
            this.btnAdicionarCategoria.Click += new System.EventHandler(this.BtnAdicionarCategoria_Click);
            // 
            // gridCategorias
            // 
            this.gridCategorias.AllowUserToAddRows = false;
            this.gridCategorias.AllowUserToDeleteRows = false;
            this.gridCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCategorias.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCategoria,
            this.NomeCategoria,
            this.Descricao,
            this.TipoFluxo,
            this.Icone,
            this.PlanejamentosCategoria,
            this.TransacoesCategoria});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCategorias.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridCategorias.EnableHeadersVisualStyles = false;
            this.gridCategorias.Location = new System.Drawing.Point(20, 75);
            this.gridCategorias.MultiSelect = false;
            this.gridCategorias.Name = "gridCategorias";
            this.gridCategorias.RowHeadersVisible = false;
            this.gridCategorias.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCategorias.Size = new System.Drawing.Size(707, 340);
            this.gridCategorias.TabIndex = 7;
            this.gridCategorias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCategorias_CellDoubleClick);
            // 
            // IdCategoria
            // 
            this.IdCategoria.DataPropertyName = "IdCategoria";
            this.IdCategoria.HeaderText = "IdCategoria";
            this.IdCategoria.Name = "IdCategoria";
            this.IdCategoria.ReadOnly = true;
            this.IdCategoria.Visible = false;
            // 
            // NomeCategoria
            // 
            this.NomeCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NomeCategoria.DataPropertyName = "Nome";
            this.NomeCategoria.HeaderText = "Nome";
            this.NomeCategoria.Name = "NomeCategoria";
            this.NomeCategoria.ReadOnly = true;
            this.NomeCategoria.Width = 80;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // TipoFluxo
            // 
            this.TipoFluxo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TipoFluxo.DataPropertyName = "TipoFluxo";
            this.TipoFluxo.HeaderText = "Tipo de Fluxo";
            this.TipoFluxo.Name = "TipoFluxo";
            this.TipoFluxo.ReadOnly = true;
            this.TipoFluxo.Width = 141;
            // 
            // Icone
            // 
            this.Icone.DataPropertyName = "Icone";
            this.Icone.HeaderText = "Icone";
            this.Icone.Name = "Icone";
            this.Icone.ReadOnly = true;
            this.Icone.Visible = false;
            // 
            // PlanejamentosCategoria
            // 
            this.PlanejamentosCategoria.DataPropertyName = "Planejamentos";
            this.PlanejamentosCategoria.HeaderText = "Planejamentos";
            this.PlanejamentosCategoria.Name = "PlanejamentosCategoria";
            this.PlanejamentosCategoria.ReadOnly = true;
            this.PlanejamentosCategoria.Visible = false;
            // 
            // TransacoesCategoria
            // 
            this.TransacoesCategoria.DataPropertyName = "Transacoes";
            this.TransacoesCategoria.HeaderText = "Transacoes";
            this.TransacoesCategoria.Name = "TransacoesCategoria";
            this.TransacoesCategoria.ReadOnly = true;
            this.TransacoesCategoria.Visible = false;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Location = new System.Drawing.Point(688, 12);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(80, 40);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Location = new System.Drawing.Point(382, 12);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(300, 40);
            this.btnUsuario.TabIndex = 2;
            this.btnUsuario.Text = "Usuário";
            this.btnUsuario.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSair;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dominus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPerfisUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPerfisUsuario)).EndInit();
            this.tabCategorias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPerfisUsuario;
        private System.Windows.Forms.TabPage tabCategorias;
        private System.Windows.Forms.Button btnAtualizarPerfis;
        private System.Windows.Forms.DataGridView gridPerfisUsuario;
        private System.Windows.Forms.DataGridView gridCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Senha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PerfilAdministrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Planejamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Relatorios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transacoes;
        private System.Windows.Forms.DataGridViewButtonColumn Usuario_Salvar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoFluxo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Icone;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanejamentosCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransacoesCategoria;
        private System.Windows.Forms.Button btnExcluirCategoria;
        private System.Windows.Forms.Button btnEditarCategoria;
        private System.Windows.Forms.Button btnAdicionarCategoria;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnUsuario;
    }
}