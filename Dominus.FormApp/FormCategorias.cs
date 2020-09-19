using Dominus.DataModel;
using Dominus.DataModel.Core;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormCategorias : Form
    {
        public FormCategorias()
        {
            InitializeComponent();
            try
            {
                DataGridViewImageColumn column = (DataGridViewImageColumn)gridCategorias.Columns["CategoriaEditar"];
                column.Image = IconChar.Pen.ToBitmap(20, System.Drawing.Color.Blue);

                column = (DataGridViewImageColumn)gridCategorias.Columns["CategoriaExcluir"];
                column.Image = IconChar.TimesCircle.ToBitmap(20, System.Drawing.Color.Red);
            }
            catch (Exception) { }
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            CarregarGridCategorias();
        }

        private void CarregarGridCategorias(String categoria = null)
        {
            List<Categoria> categorias = CategoriaManager.GetCategoriasAtivas().ToList();
            gridCategorias.DataSource = categorias.Where(x =>
                String.IsNullOrEmpty(categoria) ||
                x.Nome.ToLower().Contains(categoria.ToLower()))
            .OrderBy(x => x.Nome).ToList();
        }

        private void EditarCategoria(Categoria categoria)
        {
            FormGerenciarCategoria form = new FormGerenciarCategoria(categoria);
            if (form.ShowDialog() == DialogResult.OK)
            {
                CarregarGridCategorias(txtFiltroCategoria.Text);
                MessageBox.Show("A categoria foi editada com sucesso.", "Categoria atualizada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void BtnAdicionarCategoria_Click(object sender, EventArgs e)
        {
            FormGerenciarCategoria form = new FormGerenciarCategoria();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CarregarGridCategorias(txtFiltroCategoria.Text);
                MessageBox.Show("A categoria foi inserida com sucesso.", "Categoria nova incluída!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void GridCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn column && e.RowIndex >= 0)
            {
                Categoria categoria = (Categoria)gridCategorias.Rows[e.RowIndex].DataBoundItem;
                switch (column.Name)
                {
                    case "CategoriaEditar":
                        EditarCategoria(categoria);
                        break;
                    case "CategoriaExcluir":
                        if (MessageBox.Show("Deseja realmente excluir a categoria?", "Excluir categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            CategoriaManager.DeleteCategoria(categoria);
                            CarregarGridCategorias(txtFiltroCategoria.Text);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
