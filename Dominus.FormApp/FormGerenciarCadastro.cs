using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormGerenciarCadastro : Form
    {
        private static Usuario Usuario;

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
                MessageBox.Show("Erro ao abrir o formulário de usuário. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    IdUsuario = Usuario.IdUsuario,
                    Nome = txtNome.Text.Trim(),
                    Login = txtLogin.Text.Trim(),
                    Email = Usuario.Email,
                    Senha = Codificador.Criptografar(txtSenha.Text)
                };

                if (usuario.Senha != Usuario.Senha)
                {
                    MessageBox.Show("A senha digitada não corresponde à senha cadastrada.", "Revise o preenchimento da senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSenha.Focus();
                    return;
                }
                if (chkBoxAlterarSenha.Checked)
                {
                    if (!txtConfirmarSenha.Text.Equals(txtNovaSenha.Text))
                    {
                        MessageBox.Show("A nova senha digitada está diferente do campo de validação.", "As senhas digitadas não conferem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNovaSenha.Focus();
                        return;
                    }
                    usuario.Senha = Codificador.Criptografar(txtNovaSenha.Text);
                }

                UsuarioManager.EditUsuario(usuario);
                LoginInfo.Usuario = UsuarioManager.GetUsuarioById(usuario.IdUsuario);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                switch (ex.GetType().Name)
                {
                    case "UsuarioNomeException":
                        MessageBox.Show(ex.Message, "Revise o preenchimento do nome", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNome.Focus();
                        break;
                    case "UsuarioLoginException":
                        MessageBox.Show(ex.Message, "Revise o preenchimento do login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Focus();
                        break;
                    case "UsuarioSenhaException":
                        MessageBox.Show(ex.Message, "Revise o preenchimento da senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (chkBoxAlterarSenha.Checked)
                        {
                            txtNovaSenha.Focus();
                        }
                        else
                        {
                            txtSenha.Focus();
                        }
                        break;
                    default:
                        MessageBox.Show("Erro ao atualizar cadastro. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
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

        private void TxtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('_') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
