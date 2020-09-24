using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormRecuperarSenha : Form
    {
        public FormRecuperarSenha(String email)
        {
            InitializeComponent();

            if (!String.IsNullOrWhiteSpace(email) && UsuarioManager.ValidarEmail(email))
            {
                txtEmail.Text = email;
            }
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
                if (!UsuarioManager.ValidarEmail(txtEmail.Text))
                {
                    MessageBox.Show("Digite um endereço de e-mail válido.", "E-mail inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                Usuario usuario = UsuarioManager.GetUsuarioByEmail(txtEmail.Text);
                if (usuario == null)
                {
                    MessageBox.Show("O e-mail digitado não possui cadastro no sistema.", "E-mail não encontrado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                UsuarioManager.EnviarSenhaPorEmail(usuario);
                MessageBox.Show("E-mail de recuperação da senha enviado com sucesso.", "E-mail enviado com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao tentar enviar senha por e-mail. Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
