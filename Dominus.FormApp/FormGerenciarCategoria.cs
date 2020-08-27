using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormGerenciarCategoria : Form
    {
        public Categoria Categoria = new Categoria();

        public FormGerenciarCategoria(Categoria categoria)
        {
            Categoria.IdCategoria = 0;

            InitializeComponent();

            if (categoria != null)
            {
                Categoria = categoria;
                txtNome.Text = Categoria.Nome;
                txtDescricao.Text = Categoria.Descricao;
                rdoBtnReceita.Checked = Categoria.TipoFluxo == "Receita";
                rdoBtnDespesa.Checked = Categoria.TipoFluxo == "Despesa";
                txtIcone.Text = Categoria.Icone;
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o nome da categoria.", "O nome da categoria é obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return;
            }
            if (!rdoBtnDespesa.Checked && !rdoBtnReceita.Checked)
            {
                MessageBox.Show("Escolha o tipo defluxo da categoria.", "O tipo de fluxo da categoria é obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Preencha a descrição da categoria.", "A descrição da categoria é obrigatória!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(txtIcone.Text))
            {
                MessageBox.Show("Escolha um ícone para a categoria.", "O ícone da categoria é obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIcone.Focus();
                return;
            }

            Categoria.Nome = txtNome.Text;
            Categoria.Descricao = txtDescricao.Text;
            Categoria.TipoFluxo = rdoBtnReceita.Checked ? "Receita" : "Despesa";
            Categoria.Icone = txtIcone.Text;

            if (Categoria.IdCategoria == 0)
            {
                CategoriaManager.AddCategoria(Categoria);
            }
            else
            {
                CategoriaManager.EditCategoria(Categoria);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnEncontrarIcone_Click(object sender, EventArgs e)
        {

        }
    }
}
