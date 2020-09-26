using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar o formulário de login. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        // Evento de click no botão de login:
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Valida se os campos de login e senha estão preenchidos:
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
                // Valida se o login e senha fornecidos pelo usuário:
                // O método de validação retorna o usuário ou null se as credenciais forem inválidas:
                Usuario usuario = UsuarioManager.ValidarUsuario(txtLogin.Text.Trim(), txtSenha.Text);

                if (usuario == null)
                {
                    // Alerta o usuário que as credenciais estão inválidas:
                    MessageBox.Show("O login ou a senha estão inválidos. Revise os seus dados de acesso.", "Tentativa de login inválida!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (usuario.PerfilAdministrador != UsuarioManager.PERFIL_ADMINISTRADOR)
                {
                    // Alerta o usuário que ele não possui perfil de administrador e não pode acessar o sistema:
                    MessageBox.Show("O login fornecido não possui permissão de administrador", "Usuário sem permissão!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Realiza o login do usuário:
                LoginInfo.Login(usuario);

                // Limpa o campo de senha do form e esconde esse formulário:
                txtSenha.Text = String.Empty;
                Hide();

                // Carrega e exibe o formulário principal para o usuário já validado:
                FormPrincipal form = new FormPrincipal();
                form.Show();

                // Adiciona ao form principal o evnto de fechar o form de login se ele estiver escondido:
                form.Closed += (s, args) => { if (!Visible) Close(); };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar validar o login. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento de click no link de recuperação de senha:
        private void LinkRecuperarSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Exibe o form de recuperação de senha como um diálogo para o usuário:
                FormRecuperarSenha form = new FormRecuperarSenha(txtLogin.Text);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir o formulário de recuperação de senha. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento de click no link de realizar cadastro no sistema:
        private void LinkCadastrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Verifica se o arquivo de configuração possui a url do site do Dominus:
                String urlDominus = ConfigurationManager.AppSettings["UrlSiteDominus"];
                if (!String.IsNullOrWhiteSpace(urlDominus))
                {
                    // Inicia um processo no navegador e direciona o usuário para a página de cadastro no Dominus:
                    ProcessStartInfo sInfo = new ProcessStartInfo(urlDominus + "/Cadastro");
                    Process.Start(sInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir página de cadastro no navegador. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento de click no botão de sair da aplicação (o botão está invisível no form):
        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Evento de fechamento do formulário principal:
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Verifica se o form está visível ao usuário e valida o encerramento:
            if (Visible)
            {
                e.Cancel = MessageBox.Show("Deseja realmente sair do sistema?", "Encerrar Sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            }
        }
    }
}
