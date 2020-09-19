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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.panelLateral = new System.Windows.Forms.Panel();
            this.bordaBotao = new System.Windows.Forms.Panel();
            this.btnEstatisticas = new FontAwesome.Sharp.IconButton();
            this.btnChamados = new FontAwesome.Sharp.IconButton();
            this.btnCategorias = new FontAwesome.Sharp.IconButton();
            this.btnPerfisUsuario = new FontAwesome.Sharp.IconButton();
            this.panelTopo = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblPanelAtivo = new System.Windows.Forms.Label();
            this.iconPanelAtivo = new FontAwesome.Sharp.IconPictureBox();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.menuUsuario = new System.Windows.Forms.MenuStrip();
            this.menuItemUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogoff = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSair = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBorda = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelLateral.SuspendLayout();
            this.panelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPanelAtivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.menuUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panelLateral.Controls.Add(this.bordaBotao);
            this.panelLateral.Controls.Add(this.btnEstatisticas);
            this.panelLateral.Controls.Add(this.btnChamados);
            this.panelLateral.Controls.Add(this.btnCategorias);
            this.panelLateral.Controls.Add(this.btnPerfisUsuario);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 60);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(200, 501);
            this.panelLateral.TabIndex = 0;
            // 
            // bordaBotao
            // 
            this.bordaBotao.BackColor = System.Drawing.Color.Orange;
            this.bordaBotao.Location = new System.Drawing.Point(0, 0);
            this.bordaBotao.Name = "bordaBotao";
            this.bordaBotao.Size = new System.Drawing.Size(10, 50);
            this.bordaBotao.TabIndex = 5;
            // 
            // btnEstatisticas
            // 
            this.btnEstatisticas.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEstatisticas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstatisticas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEstatisticas.FlatAppearance.BorderSize = 0;
            this.btnEstatisticas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnEstatisticas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEstatisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstatisticas.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnEstatisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstatisticas.ForeColor = System.Drawing.Color.LightGray;
            this.btnEstatisticas.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnEstatisticas.IconColor = System.Drawing.Color.White;
            this.btnEstatisticas.IconSize = 32;
            this.btnEstatisticas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstatisticas.Location = new System.Drawing.Point(0, 150);
            this.btnEstatisticas.Name = "btnEstatisticas";
            this.btnEstatisticas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEstatisticas.Rotation = 0D;
            this.btnEstatisticas.Size = new System.Drawing.Size(200, 50);
            this.btnEstatisticas.TabIndex = 4;
            this.btnEstatisticas.Text = "Estatísticas";
            this.btnEstatisticas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstatisticas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEstatisticas.UseVisualStyleBackColor = false;
            this.btnEstatisticas.Click += new System.EventHandler(this.BtnEstatisticas_Click);
            // 
            // btnChamados
            // 
            this.btnChamados.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnChamados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChamados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChamados.FlatAppearance.BorderSize = 0;
            this.btnChamados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnChamados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnChamados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChamados.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnChamados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChamados.ForeColor = System.Drawing.Color.LightGray;
            this.btnChamados.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            this.btnChamados.IconColor = System.Drawing.Color.White;
            this.btnChamados.IconSize = 32;
            this.btnChamados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamados.Location = new System.Drawing.Point(0, 100);
            this.btnChamados.Name = "btnChamados";
            this.btnChamados.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnChamados.Rotation = 0D;
            this.btnChamados.Size = new System.Drawing.Size(200, 50);
            this.btnChamados.TabIndex = 3;
            this.btnChamados.Text = "Chamados";
            this.btnChamados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChamados.UseVisualStyleBackColor = false;
            this.btnChamados.Click += new System.EventHandler(this.BtnChamados_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnCategorias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.ForeColor = System.Drawing.Color.LightGray;
            this.btnCategorias.IconChar = FontAwesome.Sharp.IconChar.MoneyBillWave;
            this.btnCategorias.IconColor = System.Drawing.Color.White;
            this.btnCategorias.IconSize = 32;
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Location = new System.Drawing.Point(0, 50);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCategorias.Rotation = 0D;
            this.btnCategorias.Size = new System.Drawing.Size(200, 50);
            this.btnCategorias.TabIndex = 2;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.BtnCategorias_Click);
            // 
            // btnPerfisUsuario
            // 
            this.btnPerfisUsuario.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPerfisUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPerfisUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPerfisUsuario.FlatAppearance.BorderSize = 0;
            this.btnPerfisUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnPerfisUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPerfisUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerfisUsuario.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPerfisUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerfisUsuario.ForeColor = System.Drawing.Color.LightGray;
            this.btnPerfisUsuario.IconChar = FontAwesome.Sharp.IconChar.UserCog;
            this.btnPerfisUsuario.IconColor = System.Drawing.Color.White;
            this.btnPerfisUsuario.IconSize = 32;
            this.btnPerfisUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPerfisUsuario.Location = new System.Drawing.Point(0, 0);
            this.btnPerfisUsuario.Name = "btnPerfisUsuario";
            this.btnPerfisUsuario.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPerfisUsuario.Rotation = 0D;
            this.btnPerfisUsuario.Size = new System.Drawing.Size(200, 50);
            this.btnPerfisUsuario.TabIndex = 1;
            this.btnPerfisUsuario.Text = "Perfis de Usuário";
            this.btnPerfisUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPerfisUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPerfisUsuario.UseVisualStyleBackColor = false;
            this.btnPerfisUsuario.Click += new System.EventHandler(this.BtnPerfisUsuario_Click);
            // 
            // panelTopo
            // 
            this.panelTopo.BackColor = System.Drawing.Color.White;
            this.panelTopo.Controls.Add(this.btnSair);
            this.panelTopo.Controls.Add(this.lblPanelAtivo);
            this.panelTopo.Controls.Add(this.iconPanelAtivo);
            this.panelTopo.Controls.Add(this.pictureLogo);
            this.panelTopo.Controls.Add(this.menuUsuario);
            this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopo.Location = new System.Drawing.Point(0, 0);
            this.panelTopo.Name = "panelTopo";
            this.panelTopo.Size = new System.Drawing.Size(984, 60);
            this.panelTopo.TabIndex = 1;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Location = new System.Drawing.Point(978, 6);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(0, 0);
            this.btnSair.TabIndex = 10;
            this.btnSair.TabStop = false;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // lblPanelAtivo
            // 
            this.lblPanelAtivo.AutoSize = true;
            this.lblPanelAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanelAtivo.ForeColor = System.Drawing.Color.Gray;
            this.lblPanelAtivo.Location = new System.Drawing.Point(264, 25);
            this.lblPanelAtivo.Name = "lblPanelAtivo";
            this.lblPanelAtivo.Size = new System.Drawing.Size(134, 24);
            this.lblPanelAtivo.TabIndex = 2;
            this.lblPanelAtivo.Text = "Página Inicial";
            this.lblPanelAtivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPanelAtivo
            // 
            this.iconPanelAtivo.BackColor = System.Drawing.Color.White;
            this.iconPanelAtivo.ForeColor = System.Drawing.Color.Gray;
            this.iconPanelAtivo.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconPanelAtivo.IconColor = System.Drawing.Color.Gray;
            this.iconPanelAtivo.Location = new System.Drawing.Point(226, 21);
            this.iconPanelAtivo.Name = "iconPanelAtivo";
            this.iconPanelAtivo.Size = new System.Drawing.Size(32, 32);
            this.iconPanelAtivo.TabIndex = 1;
            this.iconPanelAtivo.TabStop = false;
            // 
            // pictureLogo
            // 
            this.pictureLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureLogo.Image = global::Dominus.FormApp.Properties.Resources.logo_200x60;
            this.pictureLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(200, 60);
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            // 
            // menuUsuario
            // 
            this.menuUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuUsuario.Dock = System.Windows.Forms.DockStyle.None;
            this.menuUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuUsuario.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuUsuario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUsuario});
            this.menuUsuario.Location = new System.Drawing.Point(895, 10);
            this.menuUsuario.Name = "menuUsuario";
            this.menuUsuario.Padding = new System.Windows.Forms.Padding(0);
            this.menuUsuario.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuUsuario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuUsuario.Size = new System.Drawing.Size(80, 34);
            this.menuUsuario.TabIndex = 3;
            this.menuUsuario.Text = "menuUsuario";
            // 
            // menuItemUsuario
            // 
            this.menuItemUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCadastro,
            this.menuItemLogoff,
            this.menuItemSair});
            this.menuItemUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuItemUsuario.ForeColor = System.Drawing.Color.MidnightBlue;
            this.menuItemUsuario.Name = "menuItemUsuario";
            this.menuItemUsuario.Padding = new System.Windows.Forms.Padding(5);
            this.menuItemUsuario.Size = new System.Drawing.Size(78, 34);
            this.menuItemUsuario.Text = "Usuário";
            // 
            // menuItemCadastro
            // 
            this.menuItemCadastro.BackColor = System.Drawing.Color.White;
            this.menuItemCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuItemCadastro.ForeColor = System.Drawing.Color.MidnightBlue;
            this.menuItemCadastro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuItemCadastro.Name = "menuItemCadastro";
            this.menuItemCadastro.Size = new System.Drawing.Size(180, 22);
            this.menuItemCadastro.Text = "Editar Cadastro";
            this.menuItemCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuItemCadastro.Click += new System.EventHandler(this.MenuItemCadastro_Click);
            // 
            // menuItemLogoff
            // 
            this.menuItemLogoff.BackColor = System.Drawing.Color.White;
            this.menuItemLogoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuItemLogoff.ForeColor = System.Drawing.Color.MidnightBlue;
            this.menuItemLogoff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuItemLogoff.Name = "menuItemLogoff";
            this.menuItemLogoff.Size = new System.Drawing.Size(180, 22);
            this.menuItemLogoff.Text = "Fazer Logoff";
            this.menuItemLogoff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuItemLogoff.Click += new System.EventHandler(this.MenuItemLogoff_Click);
            // 
            // menuItemSair
            // 
            this.menuItemSair.BackColor = System.Drawing.Color.White;
            this.menuItemSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuItemSair.ForeColor = System.Drawing.Color.MidnightBlue;
            this.menuItemSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuItemSair.Name = "menuItemSair";
            this.menuItemSair.Size = new System.Drawing.Size(180, 22);
            this.menuItemSair.Text = "Sair";
            this.menuItemSair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuItemSair.Click += new System.EventHandler(this.MenuItemSair_Click);
            // 
            // panelBorda
            // 
            this.panelBorda.BackColor = System.Drawing.Color.Orange;
            this.panelBorda.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBorda.Location = new System.Drawing.Point(200, 60);
            this.panelBorda.Name = "panelBorda";
            this.panelBorda.Size = new System.Drawing.Size(784, 10);
            this.panelBorda.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(200, 70);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(784, 491);
            this.panelDesktop.TabIndex = 3;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSair;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelBorda);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.panelTopo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(785, 500);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dominus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.panelLateral.ResumeLayout(false);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPanelAtivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.menuUsuario.ResumeLayout(false);
            this.menuUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Panel panelTopo;
        private System.Windows.Forms.PictureBox pictureLogo;
        private FontAwesome.Sharp.IconButton btnPerfisUsuario;
        private FontAwesome.Sharp.IconButton btnCategorias;
        private FontAwesome.Sharp.IconButton btnEstatisticas;
        private FontAwesome.Sharp.IconButton btnChamados;
        private System.Windows.Forms.Label lblPanelAtivo;
        private FontAwesome.Sharp.IconPictureBox iconPanelAtivo;
        private System.Windows.Forms.Panel panelBorda;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel bordaBotao;
        private System.Windows.Forms.MenuStrip menuUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuItemUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuItemCadastro;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogoff;
        private System.Windows.Forms.ToolStripMenuItem menuItemSair;
        private System.Windows.Forms.Button btnSair;
    }
}