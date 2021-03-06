﻿using Dominus.DataModel;
using Dominus.DataModel.Core;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormCategorias : Form
    {
        public List<Icone> Icones;

        public FormCategorias()
        {
            InitializeComponent();
            try
            {
                DataGridViewImageColumn column = (DataGridViewImageColumn)gridCategorias.Columns["CategoriaEditar"];
                column.Image = IconChar.Pen.ToBitmap(20, Color.Blue);

                column = (DataGridViewImageColumn)gridCategorias.Columns["CategoriaExcluir"];
                column.Image = IconChar.TimesCircle.ToBitmap(20, Color.Red);
            }
            catch (Exception) { }
        }

        private void FormCategorias_Shown(object sender, EventArgs e)
        {
            Icones = new List<Icone>();

            CarregarGridCategorias();
            if (ConnectionManager.VerificaSiteOnLine())
            {
                foreach (DataGridViewRow row in gridCategorias.Rows)
                {
                    Categoria categoria = (Categoria)row.DataBoundItem;
                    DataGridViewImageCell iconeCell = (DataGridViewImageCell)row.Cells["Image"];

                    Image image = CategoriaManager.GetIconeCategoria(categoria);
                    if (image != null)
                    {
                        iconeCell.Value = new Bitmap(image, new Size(18, 18));
                        Icones.Add(new Icone
                        {
                            IdCategoria = categoria.IdCategoria,
                            Bitmap = (Bitmap)iconeCell.Value
                        });
                    }
                }
            }
            else
            {
                MessageBox.Show("Não foi possível carregar os ícones das categorias.", "Ícones não carregados!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarregarGridCategorias(String nome = null)
        {
            List<Categoria> categorias = CategoriaManager.GetCategoriasAtivas();
            gridCategorias.DataSource = categorias.Where(x =>
                String.IsNullOrEmpty(nome) ||
                x.Nome.ToLower().Contains(nome.ToLower()))
            .OrderBy(x => x.Nome).ToList();

            foreach (DataGridViewRow row in gridCategorias.Rows)
            {
                Categoria categoria = (Categoria)row.DataBoundItem;
                DataGridViewImageCell iconeCell = (DataGridViewImageCell)row.Cells["Image"];

                if (Icones.Count > 0)
                {
                    iconeCell.Value = Icones.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria)?.Bitmap;
                }
            }
        }

        private void EditarCategoria(Categoria categoria)
        {
            FormGerenciarCategoria form = new FormGerenciarCategoria(categoria);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Image image = CategoriaManager.GetIconeCategoria(categoria);
                if (image != null)
                {
                    Icone icone = Icones.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                    if (icone != null)
                    {
                        icone.Bitmap = new Bitmap(image, new Size(18, 18));
                    }
                }
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

                if (ConnectionManager.VerificaSiteOnLine())
                {
                    foreach (DataGridViewRow row in gridCategorias.Rows)
                    {
                        Categoria categoria = (Categoria)row.DataBoundItem;
                        if (Icones.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria) == null)
                        {
                            Image image = CategoriaManager.GetIconeCategoria(categoria);
                            if (image != null)
                            {
                                DataGridViewImageCell iconeCell = (DataGridViewImageCell)row.Cells["Image"];
                                iconeCell.Value = new Bitmap(image, new Size(18, 18));
                                Icones.Add(new Icone
                                {
                                    IdCategoria = categoria.IdCategoria,
                                    Bitmap = (Bitmap)iconeCell.Value
                                });
                            }
                        }
                    }
                }
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

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewColumn column = senderGrid.Columns[e.ColumnIndex];
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

    public class Icone
    {
        public Guid IdCategoria { get; set; }
        public Bitmap Bitmap { get; set; }
    }
}
