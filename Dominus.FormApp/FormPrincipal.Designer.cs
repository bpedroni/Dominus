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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPerfisUsuario = new System.Windows.Forms.TabPage();
            this.gridPerfisUsuario = new System.Windows.Forms.DataGridView();
            this.UsuarioIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioSenha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioPerfilAdministrador = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UsuarioDataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioDataExclusao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioAtivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UsuarioTransacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioPlanejamentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRelatorios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioChamados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioChamadosAtendidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario_Salvar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAtualizarPerfis = new System.Windows.Forms.Button();
            this.tabCategorias = new System.Windows.Forms.TabPage();
            this.btnExcluirCategoria = new System.Windows.Forms.Button();
            this.btnEditarCategoria = new System.Windows.Forms.Button();
            this.btnAdicionarCategoria = new System.Windows.Forms.Button();
            this.gridCategorias = new System.Windows.Forms.DataGridView();
            this.CategoriaIdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaTipoFluxo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaIcone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaDataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaDataExclusao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaAtivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CategoriaPlanejamentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaTransacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPerfisUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPerfisUsuario)).BeginInit();
            this.tabCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategorias)).BeginInit();
            this.panelMenu.SuspendLayout();
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
            this.UsuarioIdUsuario,
            this.UsuarioNome,
            this.UsuarioLogin,
            this.UsuarioEmail,
            this.UsuarioSenha,
            this.UsuarioPerfilAdministrador,
            this.UsuarioDataCriacao,
            this.UsuarioDataExclusao,
            this.UsuarioAtivo,
            this.UsuarioTransacoes,
            this.UsuarioPlanejamentos,
            this.UsuarioRelatorios,
            this.UsuarioChamados,
            this.UsuarioChamadosAtendidos,
            this.Usuario_Salvar});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPerfisUsuario.DefaultCellStyle = dataGridViewCellStyle7;
            this.gridPerfisUsuario.EnableHeadersVisualStyles = false;
            this.gridPerfisUsuario.Location = new System.Drawing.Point(20, 75);
            this.gridPerfisUsuario.MultiSelect = false;
            this.gridPerfisUsuario.Name = "gridPerfisUsuario";
            this.gridPerfisUsuario.RowHeadersVisible = false;
            this.gridPerfisUsuario.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPerfisUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPerfisUsuario.Size = new System.Drawing.Size(707, 340);
            this.gridPerfisUsuario.TabIndex = 6;
            this.gridPerfisUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPerfisUsuario_CellContentClick);
            // 
            // UsuarioIdUsuario
            // 
            this.UsuarioIdUsuario.DataPropertyName = "IdUsuario";
            this.UsuarioIdUsuario.HeaderText = "IdUsuario";
            this.UsuarioIdUsuario.Name = "UsuarioIdUsuario";
            this.UsuarioIdUsuario.ReadOnly = true;
            this.UsuarioIdUsuario.Visible = false;
            // 
            // UsuarioNome
            // 
            this.UsuarioNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UsuarioNome.DataPropertyName = "Nome";
            this.UsuarioNome.HeaderText = "Nome";
            this.UsuarioNome.Name = "UsuarioNome";
            this.UsuarioNome.ReadOnly = true;
            // 
            // UsuarioLogin
            // 
            this.UsuarioLogin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UsuarioLogin.DataPropertyName = "Login";
            this.UsuarioLogin.HeaderText = "Login";
            this.UsuarioLogin.Name = "UsuarioLogin";
            this.UsuarioLogin.ReadOnly = true;
            this.UsuarioLogin.Width = 68;
            // 
            // UsuarioEmail
            // 
            this.UsuarioEmail.DataPropertyName = "Email";
            this.UsuarioEmail.HeaderText = "Email";
            this.UsuarioEmail.Name = "UsuarioEmail";
            this.UsuarioEmail.ReadOnly = true;
            this.UsuarioEmail.Visible = false;
            // 
            // UsuarioSenha
            // 
            this.UsuarioSenha.DataPropertyName = "Senha";
            this.UsuarioSenha.HeaderText = "Senha";
            this.UsuarioSenha.Name = "UsuarioSenha";
            this.UsuarioSenha.ReadOnly = true;
            this.UsuarioSenha.Visible = false;
            // 
            // UsuarioPerfilAdministrador
            // 
            this.UsuarioPerfilAdministrador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UsuarioPerfilAdministrador.DataPropertyName = "PerfilAdministrador";
            this.UsuarioPerfilAdministrador.FalseValue = "0";
            this.UsuarioPerfilAdministrador.HeaderText = "Administrador";
            this.UsuarioPerfilAdministrador.Name = "UsuarioPerfilAdministrador";
            this.UsuarioPerfilAdministrador.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UsuarioPerfilAdministrador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.UsuarioPerfilAdministrador.TrueValue = "1";
            this.UsuarioPerfilAdministrador.Width = 123;
            // 
            // UsuarioDataCriacao
            // 
            this.UsuarioDataCriacao.DataPropertyName = "DataCriacao";
            this.UsuarioDataCriacao.HeaderText = "DataCriacao";
            this.UsuarioDataCriacao.Name = "UsuarioDataCriacao";
            this.UsuarioDataCriacao.ReadOnly = true;
            this.UsuarioDataCriacao.Visible = false;
            // 
            // UsuarioDataExclusao
            // 
            this.UsuarioDataExclusao.DataPropertyName = "DataExclusao";
            this.UsuarioDataExclusao.HeaderText = "DataExclusao";
            this.UsuarioDataExclusao.Name = "UsuarioDataExclusao";
            this.UsuarioDataExclusao.ReadOnly = true;
            this.UsuarioDataExclusao.Visible = false;
            // 
            // UsuarioAtivo
            // 
            this.UsuarioAtivo.DataPropertyName = "Ativo";
            this.UsuarioAtivo.FalseValue = "0";
            this.UsuarioAtivo.HeaderText = "Ativo";
            this.UsuarioAtivo.Name = "UsuarioAtivo";
            this.UsuarioAtivo.ReadOnly = true;
            this.UsuarioAtivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UsuarioAtivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.UsuarioAtivo.TrueValue = "1";
            this.UsuarioAtivo.Visible = false;
            // 
            // UsuarioTransacoes
            // 
            this.UsuarioTransacoes.DataPropertyName = "Transacoes";
            this.UsuarioTransacoes.HeaderText = "Transacoes";
            this.UsuarioTransacoes.Name = "UsuarioTransacoes";
            this.UsuarioTransacoes.ReadOnly = true;
            this.UsuarioTransacoes.Visible = false;
            // 
            // UsuarioPlanejamentos
            // 
            this.UsuarioPlanejamentos.DataPropertyName = "Planejamentos";
            this.UsuarioPlanejamentos.HeaderText = "Planejamentos";
            this.UsuarioPlanejamentos.Name = "UsuarioPlanejamentos";
            this.UsuarioPlanejamentos.ReadOnly = true;
            this.UsuarioPlanejamentos.Visible = false;
            // 
            // UsuarioRelatorios
            // 
            this.UsuarioRelatorios.DataPropertyName = "Relatorios";
            this.UsuarioRelatorios.HeaderText = "Relatorios";
            this.UsuarioRelatorios.Name = "UsuarioRelatorios";
            this.UsuarioRelatorios.ReadOnly = true;
            this.UsuarioRelatorios.Visible = false;
            // 
            // UsuarioChamados
            // 
            this.UsuarioChamados.DataPropertyName = "Chamados";
            this.UsuarioChamados.HeaderText = "Chamados";
            this.UsuarioChamados.Name = "UsuarioChamados";
            this.UsuarioChamados.ReadOnly = true;
            this.UsuarioChamados.Visible = false;
            // 
            // UsuarioChamadosAtendidos
            // 
            this.UsuarioChamadosAtendidos.DataPropertyName = "ChamadosAtendidos";
            this.UsuarioChamadosAtendidos.HeaderText = "ChamadosAtendidos";
            this.UsuarioChamadosAtendidos.Name = "UsuarioChamadosAtendidos";
            this.UsuarioChamadosAtendidos.ReadOnly = true;
            this.UsuarioChamadosAtendidos.Visible = false;
            // 
            // Usuario_Salvar
            // 
            this.Usuario_Salvar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Usuario_Salvar.HeaderText = "Atualizar";
            this.Usuario_Salvar.Name = "Usuario_Salvar";
            this.Usuario_Salvar.Text = "Salvar";
            this.Usuario_Salvar.ToolTipText = "Salvar perfil de usuário";
            this.Usuario_Salvar.UseColumnTextForButtonValue = true;
            this.Usuario_Salvar.Width = 69;
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
            this.gridCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoriaIdCategoria,
            this.CategoriaNome,
            this.CategoriaDescricao,
            this.CategoriaTipoFluxo,
            this.CategoriaIcone,
            this.CategoriaDataCriacao,
            this.CategoriaDataExclusao,
            this.CategoriaAtivo,
            this.CategoriaPlanejamentos,
            this.CategoriaTransacoes});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCategorias.DefaultCellStyle = dataGridViewCellStyle8;
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
            this.CategoriaNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CategoriaNome.DataPropertyName = "Nome";
            this.CategoriaNome.HeaderText = "Nome";
            this.CategoriaNome.Name = "CategoriaNome";
            this.CategoriaNome.ReadOnly = true;
            this.CategoriaNome.Width = 74;
            // 
            // CategoriaDescricao
            // 
            this.CategoriaDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CategoriaDescricao.DataPropertyName = "Descricao";
            this.CategoriaDescricao.HeaderText = "Descrição";
            this.CategoriaDescricao.Name = "CategoriaDescricao";
            this.CategoriaDescricao.ReadOnly = true;
            // 
            // CategoriaTipoFluxo
            // 
            this.CategoriaTipoFluxo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CategoriaTipoFluxo.DataPropertyName = "TipoFluxo";
            this.CategoriaTipoFluxo.HeaderText = "Tipo de Fluxo";
            this.CategoriaTipoFluxo.Name = "CategoriaTipoFluxo";
            this.CategoriaTipoFluxo.ReadOnly = true;
            this.CategoriaTipoFluxo.Width = 122;
            // 
            // CategoriaIcone
            // 
            this.CategoriaIcone.DataPropertyName = "Icone";
            this.CategoriaIcone.HeaderText = "Icone";
            this.CategoriaIcone.Name = "CategoriaIcone";
            this.CategoriaIcone.ReadOnly = true;
            this.CategoriaIcone.Visible = false;
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
            this.CategoriaAtivo.TrueValue = "1";
            this.CategoriaAtivo.Visible = false;
            // 
            // CategoriaPlanejamentos
            // 
            this.CategoriaPlanejamentos.DataPropertyName = "Planejamentos";
            this.CategoriaPlanejamentos.HeaderText = "Planejamentos";
            this.CategoriaPlanejamentos.Name = "CategoriaPlanejamentos";
            this.CategoriaPlanejamentos.ReadOnly = true;
            this.CategoriaPlanejamentos.Visible = false;
            // 
            // CategoriaTransacoes
            // 
            this.CategoriaTransacoes.DataPropertyName = "Transacoes";
            this.CategoriaTransacoes.HeaderText = "Transacoes";
            this.CategoriaTransacoes.Name = "CategoriaTransacoes";
            this.CategoriaTransacoes.ReadOnly = true;
            this.CategoriaTransacoes.Visible = false;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Location = new System.Drawing.Point(0, 130);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(300, 40);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Location = new System.Drawing.Point(0, 0);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(300, 50);
            this.btnUsuario.TabIndex = 2;
            this.btnUsuario.Text = "Usuário";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.BtnUsuario_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnCadastro);
            this.panelMenu.Controls.Add(this.btnUsuario);
            this.panelMenu.Controls.Add(this.btnSair);
            this.panelMenu.Location = new System.Drawing.Point(468, 12);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(300, 50);
            this.panelMenu.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(0, 90);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(300, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnCadastro
            // 
            this.btnCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastro.Location = new System.Drawing.Point(0, 50);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(300, 40);
            this.btnCadastro.TabIndex = 3;
            this.btnCadastro.Text = "Editar cadastro";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.BtnCadastro_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSair;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelMenu);
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
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPerfisUsuario;
        private System.Windows.Forms.TabPage tabCategorias;
        private System.Windows.Forms.Button btnAtualizarPerfis;
        private System.Windows.Forms.DataGridView gridPerfisUsuario;
        private System.Windows.Forms.DataGridView gridCategorias;
        private System.Windows.Forms.Button btnExcluirCategoria;
        private System.Windows.Forms.Button btnEditarCategoria;
        private System.Windows.Forms.Button btnAdicionarCategoria;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioSenha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UsuarioPerfilAdministrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioDataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioDataExclusao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UsuarioAtivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioTransacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioPlanejamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRelatorios;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioChamados;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioChamadosAtendidos;
        private System.Windows.Forms.DataGridViewButtonColumn Usuario_Salvar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaIdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaTipoFluxo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaIcone;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaDataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaDataExclusao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CategoriaAtivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaPlanejamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaTransacoes;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnLogout;
    }
}