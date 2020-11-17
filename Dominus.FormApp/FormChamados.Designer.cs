namespace Dominus.FormApp
{
    partial class FormChamados
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelChamadosAbertos = new System.Windows.Forms.Label();
            this.gridChamados = new System.Windows.Forms.DataGridView();
            this.ChamadoIdChamado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoMensagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoDataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoRespondido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoIdUsuarioSuporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoMensagemResposta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoDataResposta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoValidado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ChamadoIdChamadoAssociado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoChamadoPrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoChamadoAssociado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChamadoUsuarioSuporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExibirChamado = new FontAwesome.Sharp.IconButton();
            this.btnResponderChamado = new FontAwesome.Sharp.IconButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridChamados)).BeginInit();
            this.SuspendLayout();
            // 
            // labelChamadosAbertos
            // 
            this.labelChamadosAbertos.AutoSize = true;
            this.labelChamadosAbertos.Location = new System.Drawing.Point(12, 15);
            this.labelChamadosAbertos.Name = "labelChamadosAbertos";
            this.labelChamadosAbertos.Size = new System.Drawing.Size(139, 18);
            this.labelChamadosAbertos.TabIndex = 0;
            this.labelChamadosAbertos.Text = "Chamados abertos:";
            // 
            // gridChamados
            // 
            this.gridChamados.AllowUserToAddRows = false;
            this.gridChamados.AllowUserToDeleteRows = false;
            this.gridChamados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridChamados.BackgroundColor = System.Drawing.Color.White;
            this.gridChamados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridChamados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.gridChamados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChamados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridChamados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChamados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChamadoIdChamado,
            this.ChamadoIdUsuario,
            this.ChamadoTitulo,
            this.ChamadoMensagem,
            this.ChamadoDataCriacao,
            this.ChamadoData,
            this.ChamadoRespondido,
            this.ChamadoIdUsuarioSuporte,
            this.ChamadoMensagemResposta,
            this.ChamadoDataResposta,
            this.ChamadoValidado,
            this.ChamadoIdChamadoAssociado,
            this.ChamadoChamadoPrincipal,
            this.ChamadoChamadoAssociado,
            this.ChamadoUsuario,
            this.ChamadoUsuarioSuporte});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridChamados.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridChamados.EnableHeadersVisualStyles = false;
            this.gridChamados.GridColor = System.Drawing.Color.DarkGoldenrod;
            this.gridChamados.Location = new System.Drawing.Point(12, 86);
            this.gridChamados.MultiSelect = false;
            this.gridChamados.Name = "gridChamados";
            this.gridChamados.RowHeadersVisible = false;
            this.gridChamados.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridChamados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChamados.Size = new System.Drawing.Size(510, 213);
            this.gridChamados.TabIndex = 3;
            this.gridChamados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridChamados_CellDoubleClick);
            this.gridChamados.SelectionChanged += new System.EventHandler(this.GridChamados_SelectionChanged);
            // 
            // ChamadoIdChamado
            // 
            this.ChamadoIdChamado.DataPropertyName = "IdChamado";
            this.ChamadoIdChamado.HeaderText = "IdChamado";
            this.ChamadoIdChamado.Name = "ChamadoIdChamado";
            this.ChamadoIdChamado.ReadOnly = true;
            this.ChamadoIdChamado.Visible = false;
            // 
            // ChamadoIdUsuario
            // 
            this.ChamadoIdUsuario.DataPropertyName = "IdUsuario";
            this.ChamadoIdUsuario.HeaderText = "IdUsuario";
            this.ChamadoIdUsuario.Name = "ChamadoIdUsuario";
            this.ChamadoIdUsuario.ReadOnly = true;
            this.ChamadoIdUsuario.Visible = false;
            // 
            // ChamadoTitulo
            // 
            this.ChamadoTitulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChamadoTitulo.DataPropertyName = "Titulo";
            this.ChamadoTitulo.HeaderText = "Título";
            this.ChamadoTitulo.Name = "ChamadoTitulo";
            this.ChamadoTitulo.ReadOnly = true;
            // 
            // ChamadoMensagem
            // 
            this.ChamadoMensagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ChamadoMensagem.DataPropertyName = "Mensagem";
            this.ChamadoMensagem.HeaderText = "Mensagem";
            this.ChamadoMensagem.Name = "ChamadoMensagem";
            this.ChamadoMensagem.ReadOnly = true;
            this.ChamadoMensagem.Visible = false;
            // 
            // ChamadoDataCriacao
            // 
            this.ChamadoDataCriacao.DataPropertyName = "DataCriacao";
            this.ChamadoDataCriacao.HeaderText = "DataCriacao";
            this.ChamadoDataCriacao.Name = "ChamadoDataCriacao";
            this.ChamadoDataCriacao.ReadOnly = true;
            this.ChamadoDataCriacao.Visible = false;
            // 
            // ChamadoData
            // 
            this.ChamadoData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ChamadoData.HeaderText = "Data Criação";
            this.ChamadoData.Name = "ChamadoData";
            this.ChamadoData.ReadOnly = true;
            this.ChamadoData.Width = 120;
            // 
            // ChamadoRespondido
            // 
            this.ChamadoRespondido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ChamadoRespondido.HeaderText = "Respondido";
            this.ChamadoRespondido.Name = "ChamadoRespondido";
            this.ChamadoRespondido.ReadOnly = true;
            this.ChamadoRespondido.Width = 113;
            // 
            // ChamadoIdUsuarioSuporte
            // 
            this.ChamadoIdUsuarioSuporte.DataPropertyName = "IdUsuarioSuporte";
            this.ChamadoIdUsuarioSuporte.HeaderText = "IdUsuarioSuporte";
            this.ChamadoIdUsuarioSuporte.Name = "ChamadoIdUsuarioSuporte";
            this.ChamadoIdUsuarioSuporte.ReadOnly = true;
            this.ChamadoIdUsuarioSuporte.Visible = false;
            // 
            // ChamadoMensagemResposta
            // 
            this.ChamadoMensagemResposta.DataPropertyName = "MensagemResposta";
            this.ChamadoMensagemResposta.HeaderText = "MensagemResposta";
            this.ChamadoMensagemResposta.Name = "ChamadoMensagemResposta";
            this.ChamadoMensagemResposta.ReadOnly = true;
            this.ChamadoMensagemResposta.Visible = false;
            // 
            // ChamadoDataResposta
            // 
            this.ChamadoDataResposta.DataPropertyName = "DataResposta";
            this.ChamadoDataResposta.HeaderText = "DataResposta";
            this.ChamadoDataResposta.Name = "ChamadoDataResposta";
            this.ChamadoDataResposta.ReadOnly = true;
            this.ChamadoDataResposta.Visible = false;
            // 
            // ChamadoValidado
            // 
            this.ChamadoValidado.DataPropertyName = "Validado";
            this.ChamadoValidado.FalseValue = "0";
            this.ChamadoValidado.HeaderText = "Validado";
            this.ChamadoValidado.Name = "ChamadoValidado";
            this.ChamadoValidado.ReadOnly = true;
            this.ChamadoValidado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChamadoValidado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ChamadoValidado.TrueValue = "1";
            this.ChamadoValidado.Visible = false;
            // 
            // ChamadoIdChamadoAssociado
            // 
            this.ChamadoIdChamadoAssociado.DataPropertyName = "IdChamadoAssociado";
            this.ChamadoIdChamadoAssociado.HeaderText = "IdChamadoAssociado";
            this.ChamadoIdChamadoAssociado.Name = "ChamadoIdChamadoAssociado";
            this.ChamadoIdChamadoAssociado.ReadOnly = true;
            this.ChamadoIdChamadoAssociado.Visible = false;
            // 
            // ChamadoChamadoPrincipal
            // 
            this.ChamadoChamadoPrincipal.DataPropertyName = "ChamadoPrincipal";
            this.ChamadoChamadoPrincipal.HeaderText = "ChamadoPrincipal";
            this.ChamadoChamadoPrincipal.Name = "ChamadoChamadoPrincipal";
            this.ChamadoChamadoPrincipal.ReadOnly = true;
            this.ChamadoChamadoPrincipal.Visible = false;
            // 
            // ChamadoChamadoAssociado
            // 
            this.ChamadoChamadoAssociado.DataPropertyName = "ChamadoAssociado";
            this.ChamadoChamadoAssociado.HeaderText = "ChamadoAssociado";
            this.ChamadoChamadoAssociado.Name = "ChamadoChamadoAssociado";
            this.ChamadoChamadoAssociado.ReadOnly = true;
            this.ChamadoChamadoAssociado.Visible = false;
            // 
            // ChamadoUsuario
            // 
            this.ChamadoUsuario.DataPropertyName = "Usuario";
            this.ChamadoUsuario.HeaderText = "Usuario";
            this.ChamadoUsuario.Name = "ChamadoUsuario";
            this.ChamadoUsuario.ReadOnly = true;
            this.ChamadoUsuario.Visible = false;
            // 
            // ChamadoUsuarioSuporte
            // 
            this.ChamadoUsuarioSuporte.DataPropertyName = "UsuarioSuporte";
            this.ChamadoUsuarioSuporte.HeaderText = "UsuarioSuporte";
            this.ChamadoUsuarioSuporte.Name = "ChamadoUsuarioSuporte";
            this.ChamadoUsuarioSuporte.ReadOnly = true;
            this.ChamadoUsuarioSuporte.Visible = false;
            // 
            // btnExibirChamado
            // 
            this.btnExibirChamado.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExibirChamado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExibirChamado.FlatAppearance.BorderSize = 0;
            this.btnExibirChamado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnExibirChamado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnExibirChamado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExibirChamado.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnExibirChamado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExibirChamado.ForeColor = System.Drawing.Color.White;
            this.btnExibirChamado.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnExibirChamado.IconColor = System.Drawing.Color.White;
            this.btnExibirChamado.IconSize = 24;
            this.btnExibirChamado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExibirChamado.Location = new System.Drawing.Point(15, 50);
            this.btnExibirChamado.Name = "btnExibirChamado";
            this.btnExibirChamado.Rotation = 0D;
            this.btnExibirChamado.Size = new System.Drawing.Size(170, 30);
            this.btnExibirChamado.TabIndex = 1;
            this.btnExibirChamado.Text = "Exibir Mensagem";
            this.btnExibirChamado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExibirChamado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExibirChamado.UseVisualStyleBackColor = false;
            this.btnExibirChamado.EnabledChanged += new System.EventHandler(this.BtnExibirChamado_EnabledChanged);
            this.btnExibirChamado.Click += new System.EventHandler(this.BtnExibirChamado_Click);
            // 
            // btnResponderChamado
            // 
            this.btnResponderChamado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResponderChamado.BackColor = System.Drawing.Color.SteelBlue;
            this.btnResponderChamado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResponderChamado.FlatAppearance.BorderSize = 0;
            this.btnResponderChamado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnResponderChamado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnResponderChamado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResponderChamado.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnResponderChamado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResponderChamado.ForeColor = System.Drawing.Color.White;
            this.btnResponderChamado.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpen;
            this.btnResponderChamado.IconColor = System.Drawing.Color.White;
            this.btnResponderChamado.IconSize = 24;
            this.btnResponderChamado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResponderChamado.Location = new System.Drawing.Point(322, 50);
            this.btnResponderChamado.Name = "btnResponderChamado";
            this.btnResponderChamado.Rotation = 0D;
            this.btnResponderChamado.Size = new System.Drawing.Size(200, 30);
            this.btnResponderChamado.TabIndex = 2;
            this.btnResponderChamado.Text = "Responder Chamado";
            this.btnResponderChamado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResponderChamado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResponderChamado.UseVisualStyleBackColor = false;
            this.btnResponderChamado.EnabledChanged += new System.EventHandler(this.BtnResponderChamado_EnabledChanged);
            this.btnResponderChamado.Click += new System.EventHandler(this.BtnResponderChamado_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // FormChamados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.gridChamados);
            this.Controls.Add(this.btnResponderChamado);
            this.Controls.Add(this.btnExibirChamado);
            this.Controls.Add(this.labelChamadosAbertos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormChamados";
            this.Text = "Chamados";
            this.Shown += new System.EventHandler(this.FormChamados_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridChamados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChamadosAbertos;
        private System.Windows.Forms.DataGridView gridChamados;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoIdChamado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoMensagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoDataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoRespondido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoIdUsuarioSuporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoMensagemResposta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoDataResposta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChamadoValidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoIdChamadoAssociado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoChamadoPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoChamadoAssociado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChamadoUsuarioSuporte;
        private FontAwesome.Sharp.IconButton btnExibirChamado;
        private FontAwesome.Sharp.IconButton btnResponderChamado;
        private System.Windows.Forms.Timer timer;
    }
}