using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormGerenciarCadastro : Form
    {
        private Usuario Usuario;

        public FormGerenciarCadastro(Usuario usuario)
        {
            try
            {
                InitializeComponent();

                Usuario = usuario;
                txtNome.Text = Usuario.Nome;
                txtLogin.Text = Usuario.Login;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir o formulário de usuário. Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o seu nome.", "O nome de usuário é obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Preencha o seu login.", "O login de usuário é obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtSenha.Text) || Codificador.Criptografar(txtSenha.Text) != Usuario.Senha)
            {
                MessageBox.Show("A senha digitada não corresponde à senha cadastrada.", "O senha fornecida não confere!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
                return;
            }

            try
            {
                if (txtLogin.Text != Usuario.Login && UsuarioManager.GetUsuarioByLogin(txtLogin.Text) != null)
                {
                    MessageBox.Show("O novo login digitado já pertence a outro usuário no sistema.", "Alteração de login inválida!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLogin.Focus();
                    return;
                }
                if (chkBoxAlterarSenha.Checked)
                {
                    if (txtNovaSenha.Text != txtConfirmarSenha.Text)
                    {
                        MessageBox.Show("A nova senha digitada está diferente do campo de validação.", "As senhas digitadas não conferem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNovaSenha.Focus();
                        return;
                    }
                    Usuario.Senha = Codificador.Criptografar(txtNovaSenha.Text);
                }

                Usuario.Nome = txtNome.Text;
                Usuario.Login = txtLogin.Text;

                UsuarioManager.EditUsuario(Usuario);
                LoginInfo.Usuario = Usuario;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao atualizar cadastro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ChkBoxAlterarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxAlterarSenha.Checked)
            {
                Height = 320;
                lblNovaSenha.Visible = true;
                txtNovaSenha.Visible = true;
                lblConfirmarSenha.Visible = true;
                txtConfirmarSenha.Visible = true;
            }
            else
            {
                lblNovaSenha.Visible = false;
                txtNovaSenha.Visible = false;
                lblConfirmarSenha.Visible = false;
                txtConfirmarSenha.Visible = false;
                Height = 260;
            }
        }
    }
}
