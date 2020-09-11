namespace Dominus.FormApp
{
    partial class FormGerenciarCategoria
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
            this.labelNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.labelFluxo = new System.Windows.Forms.Label();
            this.rdoBtnReceita = new System.Windows.Forms.RadioButton();
            this.rdoBtnDespesa = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIcone = new System.Windows.Forms.TextBox();
            this.btnEncontrarIcone = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.openFileDialogIcone = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(60, 25);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(53, 18);
            this.labelNome.TabIndex = 1;
            this.labelNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(124, 22);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(290, 24);
            this.txtNome.TabIndex = 2;
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(33, 60);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(80, 18);
            this.labelDescricao.TabIndex = 3;
            this.labelDescricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(124, 57);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(290, 24);
            this.txtDescricao.TabIndex = 4;
            // 
            // labelFluxo
            // 
            this.labelFluxo.AutoSize = true;
            this.labelFluxo.Location = new System.Drawing.Point(12, 95);
            this.labelFluxo.Name = "labelFluxo";
            this.labelFluxo.Size = new System.Drawing.Size(101, 18);
            this.labelFluxo.TabIndex = 5;
            this.labelFluxo.Text = "Tipo de Fluxo:";
            // 
            // rdoBtnReceita
            // 
            this.rdoBtnReceita.AutoSize = true;
            this.rdoBtnReceita.Location = new System.Drawing.Point(172, 93);
            this.rdoBtnReceita.Name = "rdoBtnReceita";
            this.rdoBtnReceita.Size = new System.Drawing.Size(76, 22);
            this.rdoBtnReceita.TabIndex = 6;
            this.rdoBtnReceita.TabStop = true;
            this.rdoBtnReceita.Text = "Receita";
            this.rdoBtnReceita.UseVisualStyleBackColor = true;
            // 
            // rdoBtnDespesa
            // 
            this.rdoBtnDespesa.AutoSize = true;
            this.rdoBtnDespesa.Location = new System.Drawing.Point(286, 93);
            this.rdoBtnDespesa.Name = "rdoBtnDespesa";
            this.rdoBtnDespesa.Size = new System.Drawing.Size(85, 22);
            this.rdoBtnDespesa.TabIndex = 7;
            this.rdoBtnDespesa.TabStop = true;
            this.rdoBtnDespesa.Text = "Despesa";
            this.rdoBtnDespesa.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ícone:";
            // 
            // txtIcone
            // 
            this.txtIcone.AllowDrop = true;
            this.txtIcone.Location = new System.Drawing.Point(124, 126);
            this.txtIcone.Name = "txtIcone";
            this.txtIcone.ReadOnly = true;
            this.txtIcone.Size = new System.Drawing.Size(247, 24);
            this.txtIcone.TabIndex = 9;
            this.txtIcone.TabStop = false;
            this.txtIcone.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtIcone_DragDrop);
            this.txtIcone.DragOver += new System.Windows.Forms.DragEventHandler(this.TxtIcone_DragOver);
            // 
            // btnEncontrarIcone
            // 
            this.btnEncontrarIcone.Location = new System.Drawing.Point(377, 127);
            this.btnEncontrarIcone.Name = "btnEncontrarIcone";
            this.btnEncontrarIcone.Size = new System.Drawing.Size(37, 23);
            this.btnEncontrarIcone.TabIndex = 10;
            this.btnEncontrarIcone.Text = "...";
            this.btnEncontrarIcone.UseVisualStyleBackColor = true;
            this.btnEncontrarIcone.Click += new System.EventHandler(this.BtnEncontrarIcone_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(198, 166);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 35);
            this.btnSalvar.TabIndex = 11;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(314, 166);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // openFileDialogIcone
            // 
            this.openFileDialogIcone.Filter = "Image files (*.png) | *.png";
            this.openFileDialogIcone.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialogIcone_FileOk);
            // 
            // FormGerenciarCategoria
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(434, 213);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnEncontrarIcone);
            this.Controls.Add(this.txtIcone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoBtnDespesa);
            this.Controls.Add(this.rdoBtnReceita);
            this.Controls.Add(this.labelFluxo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.labelDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.labelNome);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGerenciarCategoria";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label labelFluxo;
        private System.Windows.Forms.RadioButton rdoBtnReceita;
        private System.Windows.Forms.RadioButton rdoBtnDespesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIcone;
        private System.Windows.Forms.Button btnEncontrarIcone;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.OpenFileDialog openFileDialogIcone;
    }
}