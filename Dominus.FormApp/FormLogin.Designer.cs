namespace Dominus.FormApp
{
    partial class FormLogin
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
            System.Windows.Forms.PictureBox pictureLogo;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panelLogin = new System.Windows.Forms.Panel();
            this.iconSenha = new FontAwesome.Sharp.IconPictureBox();
            this.iconLogin = new FontAwesome.Sharp.IconPictureBox();
            this.btnLogin = new FontAwesome.Sharp.IconButton();
            this.linkCadastrar = new System.Windows.Forms.LinkLabel();
            this.labelCadastrar = new System.Windows.Forms.Label();
            this.linkRecuperarSenha = new System.Windows.Forms.LinkLabel();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.labelSenha = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            pictureLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureLogo)).BeginInit();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSenha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureLogo
            // 
            pictureLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            pictureLogo.BackColor = System.Drawing.Color.Transparent;
            pictureLogo.Image = global::Dominus.FormApp.Properties.Resources.logo_160x120;
            pictureLogo.Location = new System.Drawing.Point(69, 13);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new System.Drawing.Size(160, 120);
            pictureLogo.TabIndex = 8;
            pictureLogo.TabStop = false;
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.White;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.iconSenha);
            this.panelLogin.Controls.Add(this.iconLogin);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.linkCadastrar);
            this.panelLogin.Controls.Add(this.labelCadastrar);
            this.panelLogin.Controls.Add(this.linkRecuperarSenha);
            this.panelLogin.Controls.Add(this.txtSenha);
            this.panelLogin.Controls.Add(this.labelSenha);
            this.panelLogin.Controls.Add(this.txtLogin);
            this.panelLogin.Controls.Add(this.labelLogin);
            this.panelLogin.Controls.Add(pictureLogo);
            this.panelLogin.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.panelLogin.Location = new System.Drawing.Point(142, 30);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(300, 400);
            this.panelLogin.TabIndex = 0;
            // 
            // iconSenha
            // 
            this.iconSenha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconSenha.BackColor = System.Drawing.Color.White;
            this.iconSenha.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.iconSenha.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconSenha.IconColor = System.Drawing.SystemColors.HotTrack;
            this.iconSenha.IconSize = 24;
            this.iconSenha.Location = new System.Drawing.Point(19, 240);
            this.iconSenha.Name = "iconSenha";
            this.iconSenha.Size = new System.Drawing.Size(24, 24);
            this.iconSenha.TabIndex = 10;
            this.iconSenha.TabStop = false;
            // 
            // iconLogin
            // 
            this.iconLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconLogin.BackColor = System.Drawing.Color.White;
            this.iconLogin.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.iconLogin.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconLogin.IconColor = System.Drawing.SystemColors.HotTrack;
            this.iconLogin.IconSize = 24;
            this.iconLogin.Location = new System.Drawing.Point(19, 177);
            this.iconLogin.Name = "iconLogin";
            this.iconLogin.Size = new System.Drawing.Size(24, 24);
            this.iconLogin.TabIndex = 9;
            this.iconLogin.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.LightGray;
            this.btnLogin.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.btnLogin.IconColor = System.Drawing.Color.White;
            this.btnLogin.IconSize = 32;
            this.btnLogin.Location = new System.Drawing.Point(49, 285);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Rotation = 0D;
            this.btnLogin.Size = new System.Drawing.Size(230, 40);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = " Login";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // linkCadastrar
            // 
            this.linkCadastrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkCadastrar.AutoSize = true;
            this.linkCadastrar.LinkColor = System.Drawing.Color.DarkViolet;
            this.linkCadastrar.Location = new System.Drawing.Point(147, 361);
            this.linkCadastrar.Name = "linkCadastrar";
            this.linkCadastrar.Size = new System.Drawing.Size(89, 18);
            this.linkCadastrar.TabIndex = 8;
            this.linkCadastrar.TabStop = true;
            this.linkCadastrar.Text = "Cadastre-se";
            this.linkCadastrar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkCadastrar_LinkClicked);
            // 
            // labelCadastrar
            // 
            this.labelCadastrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCadastrar.AutoSize = true;
            this.labelCadastrar.Location = new System.Drawing.Point(16, 361);
            this.labelCadastrar.Name = "labelCadastrar";
            this.labelCadastrar.Size = new System.Drawing.Size(133, 18);
            this.labelCadastrar.TabIndex = 7;
            this.labelCadastrar.Text = "Não possui conta?";
            // 
            // linkRecuperarSenha
            // 
            this.linkRecuperarSenha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkRecuperarSenha.AutoSize = true;
            this.linkRecuperarSenha.LinkColor = System.Drawing.Color.DarkViolet;
            this.linkRecuperarSenha.Location = new System.Drawing.Point(158, 328);
            this.linkRecuperarSenha.Name = "linkRecuperarSenha";
            this.linkRecuperarSenha.Size = new System.Drawing.Size(121, 18);
            this.linkRecuperarSenha.TabIndex = 6;
            this.linkRecuperarSenha.TabStop = true;
            this.linkRecuperarSenha.Text = "Recuperar senha";
            this.linkRecuperarSenha.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkRecuperarSenha_LinkClicked);
            // 
            // txtSenha
            // 
            this.txtSenha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSenha.Location = new System.Drawing.Point(49, 240);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(230, 24);
            this.txtSenha.TabIndex = 4;
            // 
            // labelSenha
            // 
            this.labelSenha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSenha.AutoSize = true;
            this.labelSenha.Location = new System.Drawing.Point(46, 219);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(129, 18);
            this.labelSenha.TabIndex = 3;
            this.labelSenha.Text = "Digite a sua senha";
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtLogin.Location = new System.Drawing.Point(49, 177);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(230, 24);
            this.txtLogin.TabIndex = 2;
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(46, 156);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(186, 18);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Digite o seu e-mail ou login";
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Location = new System.Drawing.Point(562, 12);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(0, 0);
            this.btnSair.TabIndex = 9;
            this.btnSair.TabStop = false;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CancelButton = this.btnSair;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.btnSair);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dominus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(pictureLogo)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSenha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.LinkLabel linkCadastrar;
        private System.Windows.Forms.Label labelCadastrar;
        private System.Windows.Forms.LinkLabel linkRecuperarSenha;
        private System.Windows.Forms.Button btnSair;
        private FontAwesome.Sharp.IconButton btnLogin;
        private FontAwesome.Sharp.IconPictureBox iconSenha;
        private FontAwesome.Sharp.IconPictureBox iconLogin;
    }
}