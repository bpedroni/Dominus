namespace Dominus.FormApp
{
    partial class FormMensagensChamado
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
            this.lblTituloMensagem = new System.Windows.Forms.Label();
            this.pnlMensagens = new System.Windows.Forms.Panel();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnResponderChamado = new FontAwesome.Sharp.IconButton();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloMensagem
            // 
            this.lblTituloMensagem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloMensagem.Location = new System.Drawing.Point(0, 0);
            this.lblTituloMensagem.Name = "lblTituloMensagem";
            this.lblTituloMensagem.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.lblTituloMensagem.Size = new System.Drawing.Size(494, 40);
            this.lblTituloMensagem.TabIndex = 0;
            this.lblTituloMensagem.Text = "Título";
            // 
            // pnlMensagens
            // 
            this.pnlMensagens.AutoScroll = true;
            this.pnlMensagens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMensagens.Location = new System.Drawing.Point(0, 40);
            this.pnlMensagens.Margin = new System.Windows.Forms.Padding(20);
            this.pnlMensagens.Name = "pnlMensagens";
            this.pnlMensagens.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMensagens.Size = new System.Drawing.Size(494, 18);
            this.pnlMensagens.TabIndex = 1;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnOk);
            this.pnlBotoes.Controls.Add(this.btnResponderChamado);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 58);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(494, 53);
            this.pnlBotoes.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(381, 11);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 30);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
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
            this.btnResponderChamado.Location = new System.Drawing.Point(12, 11);
            this.btnResponderChamado.Name = "btnResponderChamado";
            this.btnResponderChamado.Rotation = 0D;
            this.btnResponderChamado.Size = new System.Drawing.Size(200, 30);
            this.btnResponderChamado.TabIndex = 3;
            this.btnResponderChamado.Text = "Responder Chamado";
            this.btnResponderChamado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResponderChamado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResponderChamado.UseVisualStyleBackColor = false;
            this.btnResponderChamado.Click += new System.EventHandler(this.BtnResponderChamado_Click);
            // 
            // FormMensagensChamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(494, 111);
            this.Controls.Add(this.pnlMensagens);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.lblTituloMensagem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 150);
            this.Name = "FormMensagensChamado";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensagens do Chamado";
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTituloMensagem;
        private System.Windows.Forms.Panel pnlMensagens;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnOk;
        private FontAwesome.Sharp.IconButton btnResponderChamado;
    }
}