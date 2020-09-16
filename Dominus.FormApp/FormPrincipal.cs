using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            try
            {
                InitializeComponent();
                panelMenu.Height = 50;
                btnUsuario.Text = "Olá, " + LoginInfo.Usuario.Nome;
                CarregarGridPerfisUsuario();
                CarregarGridCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao iniciar o formulário principal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void CarregarGridPerfisUsuario(String usuario = null)
        {
            List<Usuario> usuarios = UsuarioManager.GetUsuariosAtivos().Where(x => x.IdUsuario != LoginInfo.Usuario.IdUsuario).ToList();
            gridPerfisUsuario.DataSource = usuarios.Where(x => String.IsNullOrEmpty(usuario) || x.Nome.ToLower().Contains(usuario.ToLower()) || x.Login.ToLower().Contains(usuario.ToLower())).ToList();
        }

        private void CarregarGridCategorias(String categoria = null)
        {
            List<Categoria> categorias = CategoriaManager.GetCategoriasAtivas().ToList();
            gridCategorias.DataSource = categorias.Where(x => String.IsNullOrEmpty(categoria) || x.Nome.ToLower().Contains(categoria.ToLower()) || x.Descricao.ToLower().Contains(categoria.ToLower())).ToList();
        }

        private void BtnAtualizarPerfis_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridPerfisUsuario.Rows)
            {
                Usuario usuario = (Usuario)row.DataBoundItem;
                UsuarioManager.EditUsuario(usuario);
            }
            MessageBox.Show("Os perfis foram atualizados com sucesso.", "Perfis atualizados!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GridPerfisUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Usuario usuario = (Usuario)gridPerfisUsuario.Rows[e.RowIndex].DataBoundItem;
                UsuarioManager.EditUsuario(usuario);
                MessageBox.Show("O perfil do usuário " + usuario.Login + " foi atualizado com sucesso.", "Perfil atualizado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAdicionarCategoria_Click(object sender, EventArgs e)
        {
            Form form = new FormGerenciarCategoria(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                CarregarGridCategorias();
                MessageBox.Show("A categoria foi inserida com sucesso.", "Categoria nova incluída!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEditarCategoria_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = gridCategorias.SelectedRows[0];
            if (row != null)
            {
                Categoria categoria = (Categoria)row.DataBoundItem;
                EditarCategoria(categoria);
            }
        }

        private void BtnExcluirCategoria_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = gridCategorias.SelectedRows[0];
            if (row != null)
            {
                if (MessageBox.Show("Deseja realmente excluir a categoria?", "Excluir categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CategoriaManager.DeleteCategoria((Categoria)row.DataBoundItem);
                    CarregarGridCategorias();
                }
            }
        }

        private void GridCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Categoria categoria = (Categoria)gridCategorias.Rows[e.RowIndex].DataBoundItem;
                EditarCategoria(categoria);
            }
        }

        private void EditarCategoria(Categoria categoria)
        {
            Form form = new FormGerenciarCategoria(categoria);
            if (form.ShowDialog() == DialogResult.OK)
            {
                CarregarGridCategorias();
                MessageBox.Show("A categoria foi editada com sucesso.", "Categoria atualizada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            panelMenu.Height = panelMenu.Height > 50 ? 50 : 170;
        }

        private void BtnCadastro_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 50;
            Form form = new FormGerenciarCadastro(LoginInfo.Usuario);
            if (form.ShowDialog() == DialogResult.OK)
            {
                btnUsuario.Text = "Olá, " + LoginInfo.Usuario.Nome;
                MessageBox.Show("O seu cadastro foi atualizado com sucesso.", "Cadastro atualizado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 50;
            LoginInfo.Logout();
            Form form = Application.OpenForms["FormLogin"];
            form.Show();
            Close();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            panelMenu.Height = 50;
            Close();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoginInfo.Usuario != null)
            {
                e.Cancel = MessageBox.Show("Deseja realmente sair do sistema?", "Encerrar Sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            }
        }

        private void TxtFiltroUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnFitrarUsuario_Click(this, new EventArgs());
            }
        }

        private void BtnFitrarUsuario_Click(object sender, EventArgs e)
        {
            CarregarGridPerfisUsuario(txtFiltroUsuario.Text);
        }

        private void TxtFiltroCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnFiltrarCategoria_Click(this, new EventArgs());
            }
        }

        private void BtnFiltrarCategoria_Click(object sender, EventArgs e)
        {
            CarregarGridCategorias(txtFiltroCategoria.Text);
        }
    }
}
