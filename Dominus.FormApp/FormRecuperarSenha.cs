using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormRecuperarSenha : Form
    {
        public FormRecuperarSenha()
        {
            InitializeComponent();
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Digite o seu e-mail para receber a sua senha de acesso ao sistema.", "O e-mail é obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            try
            {
                // Verifica se o e-mail digitado é válido:
                new System.Net.Mail.MailAddress(txtEmail.Text);
                Usuario usuario = UsuarioManager.GetUsuarioByEmail(txtEmail.Text);
                if (usuario == null)
                {
                    MessageBox.Show("O e-mail digitado não possui cadastro no sistema.", "E-mail não encontrado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                MessageBox.Show("FALTA IMPLEMENTAR!!!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Digite um endereço de e-mail válido.", "E-mail inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
