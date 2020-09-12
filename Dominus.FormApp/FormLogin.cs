using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            try
            {
                ConnectionManager.TestaConexao();
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao iniciar a aplicação!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Preencha o seu e-mail ou o seu login para efetuar o acesso.", "O login é obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preencha a sua senha para efetuar o acesso.", "A senha é obrigatória!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
                return;
            }

            try
            {
                Usuario usuario = UsuarioManager.ValidarUsuario(txtLogin.Text.Trim(), txtSenha.Text);

                if (usuario == null)
                {
                    MessageBox.Show("O login ou a senha estão inválidos. Revise os seus dados de acesso.", "Tentativa de login inválida!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (usuario.PerfilAdministrador != UsuarioManager.PERFIL_ADMINISTRADOR)
                {
                    MessageBox.Show("O login fornecido não possui permissão de administrador", "Usuário sem permissão!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoginInfo.Login(usuario);

                Hide();
                txtSenha.Text = String.Empty;
                FormPrincipal form = new FormPrincipal();
                form.Closed += (s, args) => { if (!Visible) Close(); };
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao tentar validar o login. Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkRecuperarSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Form form = new FormRecuperarSenha(txtLogin.Text);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir o formulário de recuperação de senha. Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkCadastrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("FALTA IMPLEMENTAR! Aqui abrirá o navegador na página de cadastro do Dominus.");
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Visible)
            {
                e.Cancel = MessageBox.Show("Deseja realmente sair do sistema?", "Encerrar Sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            }
        }
    }
}
