using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormPrincipal : Form
    {
        // Formulário dos perfis de usuário:
        private static FormPerfisUsuario formPerfisUsuario;
        // Formulário das categorias:
        private static FormCategorias formCategorias;
        // Formulário dos chamados:
        private static FormChamados formChamados;
        // Formulário das estatísticas:
        private static FormEstatisticas formEstatisticas;
        // Formulário de controle usado para a identificação do form na tela pricipal:
        private static Form formAtivo;
        // Botão de controle usado para a identificação do botão no menu que está ativo:
        private static IconButton btnAtivo;

        public FormPrincipal()
        {
            try
            {
                InitializeComponent();

                // Instanciamento dos formulários utilizados no form principal:
                formPerfisUsuario = new FormPerfisUsuario();
                formCategorias = new FormCategorias();
                formChamados = new FormChamados();
                formEstatisticas = new FormEstatisticas();

                // Carregamento do form de perfis de usuário na tela através do evento de click de botão no menu:
                BtnPerfisUsuario_Click(btnPerfisUsuario, new EventArgs());

                // Carregamento das informações do usuário no menu superior à direita:
                menuItemUsuario.Image = IconChar.UserCircle.ToBitmap(32, Color.MidnightBlue);
                menuItemUsuario.Text = LoginInfo.Usuario?.Nome;

                // Carregamento das imagens utilizadas nos botões do menu lateral:
                menuItemCadastro.Image = IconChar.Tasks.ToBitmap(32, Color.MidnightBlue);
                menuItemLogoff.Image = IconChar.SignOutAlt.ToBitmap(32, Color.MidnightBlue);
                menuItemSair.Image = IconChar.TimesCircle.ToBitmap(32, Color.MidnightBlue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao iniciar o formulário principal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        // Método usado para ativar o botão correspondente ao formulário carregado na tela:
        private void AtivarBotao(IconButton botao)
        {
            // Verifica se existe algum botão ativo e altera o estado para desativar o botão (a ativação e desativação ocorre alterando a cor do fundo):
            if (btnAtivo != null)
            {
                btnAtivo.BackColor = Color.MidnightBlue;
            }
            // Verifica se foi enviado um botão:
            if (botao != null)
            {
                // Altera o status do botão para ativo através da alteração do background e da posição da barra lateral do botão ativo:
                botao.BackColor = Color.RoyalBlue;
                bordaBotao.Location = new Point(0, botao.Location.Y);

                // Atualiza as informações do painel ativado presentes na parte superior do form:
                iconPanelAtivo.IconChar = botao.IconChar;
                lblPanelAtivo.Text = botao.Text;

                // Atualiza o botão ativado na tela:
                btnAtivo = botao;
            }
        }

        // Método usado para mostrar o formulário carregado na tela:
        private void AbrirFormulario(Form form)
        {
            // Verifica se existe algum form ativo na tela e o esconde:
            if (formAtivo != null)
            {
                formAtivo.Hide();
            }

            // Atualiza a propriedade TopLevel para falso, possibilitando o carregamento do form no panelDesktop:
            form.TopLevel = false;

            // Remove as bordas do form e preenche todo o espaço destinado ao formulário:
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Adiciona o form ao painel principal e define neste painel quais os dados que foram adicionados:
            panelDesktop.Controls.Add(form);
            panelDesktop.Tag = form;

            // Torna o form visível no formulário principal:
            form.BringToFront();
            form.Show();

            // Atualiza a informação do formulário visível na tela:
            formAtivo = form;
        }

        // Evento de click no botão de perfis de usuário:
        private void BtnPerfisUsuario_Click(object sender, EventArgs e)
        {
            // Valida se o botão ativo é diferente do botão clicado antes de atualizar a visualização:
            if (btnAtivo != (IconButton)sender)
            {
                AtivarBotao((IconButton)sender);
                AbrirFormulario(formPerfisUsuario);
            }
        }

        // Evento de click no botão de categorias:
        private void BtnCategorias_Click(object sender, EventArgs e)
        {
            // Valida se o botão ativo é diferente do botão clicado antes de atualizar a visualização:
            if (btnAtivo != (IconButton)sender)
            {
                AtivarBotao((IconButton)sender);
                AbrirFormulario(formCategorias);
            }
        }

        // Evento de click no botão de chamados:
        private void BtnChamados_Click(object sender, EventArgs e)
        {
            // Valida se o botão ativo é diferente do botão clicado antes de atualizar a visualização:
            if (btnAtivo != (IconButton)sender)
            {
                AtivarBotao((IconButton)sender);
                AbrirFormulario(formChamados);
            }
        }

        // Evento de click no botão de estatísticas:
        private void BtnEstatisticas_Click(object sender, EventArgs e)
        {
            // Valida se o botão ativo é diferente do botão clicado antes de atualizar a visualização:
            if (btnAtivo != (IconButton)sender)
            {
                AtivarBotao((IconButton)sender);
                AbrirFormulario(formEstatisticas);
            }
        }

        // Evento de click no botão de menu do cadastro do usuário:
        private void MenuItemCadastro_Click(object sender, EventArgs e)
        {
            Form form = new FormGerenciarCadastro(LoginInfo.Usuario);
            if (form.ShowDialog() == DialogResult.OK)
            {
                menuItemUsuario.Text = LoginInfo.Usuario.Nome;
                MessageBox.Show("O seu cadastro foi atualizado com sucesso.", "Cadastro atualizado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento de click no botão de menu de logoff:
        private void MenuItemLogoff_Click(object sender, EventArgs e)
        {
            // Realiza o logoff do usuário:
            LoginInfo.Logoff();

            // Mostra o formuláio de login e encerra o formulário principal:
            Form form = Application.OpenForms["FormLogin"];
            if (form == null)
            {
                form = new FormLogin();
            }
            form.Show();

            Close();
        }

        // Evento de click no botão de menu de sair da aplicação:
        private void MenuItemSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Evento de click no botão de sair da aplicação (o botão está invisível no form):
        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Evento de fechamento do formulário principal:
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Verifica se o usuário está encerrando a aplicação (e valida o encerramento) ou se está fazendo logoff:
            if (LoginInfo.Usuario != null)
            {
                e.Cancel = MessageBox.Show("Deseja realmente sair do sistema?", "Encerrar Sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            }
        }
    }
}
