using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
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

        private void CarregarGridPerfisUsuario()
        {
            gridPerfisUsuario.DataSource = UsuarioManager.GetUsuariosAtivos().Where(x => x.IdUsuario != LoginInfo.Usuario.IdUsuario).ToList();
        }

        private void CarregarGridCategorias()
        {
            gridCategorias.DataSource = CategoriaManager.GetCategoriasAtivas().ToList();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Deseja realmente sair do sistema?", "Encerrar Sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
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

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
