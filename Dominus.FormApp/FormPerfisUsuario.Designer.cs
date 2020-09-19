using FontAwesome.Sharp;

namespace Dominus.FormApp
{
    partial class FormPerfisUsuario
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
            this.txtFiltroUsuario = new System.Windows.Forms.TextBox();
            this.labelFiltroUsuario = new System.Windows.Forms.Label();
            this.btnFiltrarUsuario = new FontAwesome.Sharp.IconButton();
            this.btnAtualizarPerfis = new FontAwesome.Sharp.IconButton();
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
            this.UsuarioSalvar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridPerfisUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFiltroUsuario
            // 
            this.txtFiltroUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFiltroUsuario.Location = new System.Drawing.Point(120, 12);
            this.txtFiltroUsuario.Name = "txtFiltroUsuario";
            this.txtFiltroUsuario.Size = new System.Drawing.Size(200, 24);
            this.txtFiltroUsuario.TabIndex = 1;
            this.txtFiltroUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFiltroUsuario_KeyDown);
            // 
            // labelFiltroUsuario
            // 
            this.labelFiltroUsuario.AutoSize = true;
            this.labelFiltroUsuario.Location = new System.Drawing.Point(12, 15);
            this.labelFiltroUsuario.Name = "labelFiltroUsuario";
            this.labelFiltroUsuario.Size = new System.Drawing.Size(102, 18);
            this.labelFiltroUsuario.TabIndex = 0;
            this.labelFiltroUsuario.Text = "Filtrar usuário:";
            // 
            // btnFiltrarUsuario
            // 
            this.btnFiltrarUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFiltrarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrarUsuario.FlatAppearance.BorderSize = 0;
            this.btnFiltrarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnFiltrarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFiltrarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrarUsuario.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnFiltrarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnFiltrarUsuario.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnFiltrarUsuario.IconColor = System.Drawing.Color.White;
            this.btnFiltrarUsuario.IconSize = 20;
            this.btnFiltrarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrarUsuario.Location = new System.Drawing.Point(326, 12);
            this.btnFiltrarUsuario.Name = "btnFiltrarUsuario";
            this.btnFiltrarUsuario.Rotation = 0D;
            this.btnFiltrarUsuario.Size = new System.Drawing.Size(85, 25);
            this.btnFiltrarUsuario.TabIndex = 2;
            this.btnFiltrarUsuario.Text = "Filtrar";
            this.btnFiltrarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrarUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrarUsuario.UseVisualStyleBackColor = false;
            this.btnFiltrarUsuario.Click += new System.EventHandler(this.BtnFiltrarUsuario_Click);
            // 
            // btnAtualizarPerfis
            // 
            this.btnAtualizarPerfis.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAtualizarPerfis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizarPerfis.FlatAppearance.BorderSize = 0;
            this.btnAtualizarPerfis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAtualizarPerfis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAtualizarPerfis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizarPerfis.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnAtualizarPerfis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarPerfis.ForeColor = System.Drawing.Color.White;
            this.btnAtualizarPerfis.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnAtualizarPerfis.IconColor = System.Drawing.Color.White;
            this.btnAtualizarPerfis.IconSize = 24;
            this.btnAtualizarPerfis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualizarPerfis.Location = new System.Drawing.Point(15, 50);
            this.btnAtualizarPerfis.Name = "btnAtualizarPerfis";
            this.btnAtualizarPerfis.Rotation = 0D;
            this.btnAtualizarPerfis.Size = new System.Drawing.Size(155, 30);
            this.btnAtualizarPerfis.TabIndex = 3;
            this.btnAtualizarPerfis.Text = "Atualizar Perfis";
            this.btnAtualizarPerfis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualizarPerfis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAtualizarPerfis.UseVisualStyleBackColor = false;
            this.btnAtualizarPerfis.Click += new System.EventHandler(this.BtnAtualizarPerfis_Click);
            // 
            // gridPerfisUsuario
            // 
            this.gridPerfisUsuario.AllowUserToAddRows = false;
            this.gridPerfisUsuario.AllowUserToDeleteRows = false;
            this.gridPerfisUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPerfisUsuario.BackgroundColor = System.Drawing.Color.White;
            this.gridPerfisUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPerfisUsuario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.gridPerfisUsuario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPerfisUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.UsuarioSalvar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPerfisUsuario.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridPerfisUsuario.EnableHeadersVisualStyles = false;
            this.gridPerfisUsuario.GridColor = System.Drawing.Color.DarkGoldenrod;
            this.gridPerfisUsuario.Location = new System.Drawing.Point(12, 86);
            this.gridPerfisUsuario.MultiSelect = false;
            this.gridPerfisUsuario.Name = "gridPerfisUsuario";
            this.gridPerfisUsuario.RowHeadersVisible = false;
            this.gridPerfisUsuario.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPerfisUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPerfisUsuario.Size = new System.Drawing.Size(510, 213);
            this.gridPerfisUsuario.TabIndex = 4;
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
            this.UsuarioLogin.Width = 69;
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
            this.UsuarioPerfilAdministrador.Width = 124;
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
            // UsuarioSalvar
            // 
            this.UsuarioSalvar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UsuarioSalvar.HeaderText = "Salvar";
            this.UsuarioSalvar.Name = "UsuarioSalvar";
            this.UsuarioSalvar.ToolTipText = "Salvar perfil de usuário";
            this.UsuarioSalvar.Width = 55;
            // 
            // FormPerfisUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.gridPerfisUsuario);
            this.Controls.Add(this.btnAtualizarPerfis);
            this.Controls.Add(this.btnFiltrarUsuario);
            this.Controls.Add(this.txtFiltroUsuario);
            this.Controls.Add(this.labelFiltroUsuario);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPerfisUsuario";
            this.Text = "Perfis de Usuário";
            this.Load += new System.EventHandler(this.FormPerfisUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPerfisUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFiltroUsuario;
        private System.Windows.Forms.Label labelFiltroUsuario;
        private FontAwesome.Sharp.IconButton btnFiltrarUsuario;
        private FontAwesome.Sharp.IconButton btnAtualizarPerfis;
        private System.Windows.Forms.DataGridView gridPerfisUsuario;
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
        private System.Windows.Forms.DataGridViewImageColumn UsuarioSalvar;
    }
}