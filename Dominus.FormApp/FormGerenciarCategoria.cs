using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.IO;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormGerenciarCategoria : Form
    {
        private Categoria Categoria;

        public FormGerenciarCategoria(Categoria categoria)
        {
            try
            {
                InitializeComponent();

                // Verifica se o formulário recebeu uma categoria e atualiza os componentes:
                if (categoria != null)
                {
                    Categoria = categoria;
                    txtNome.Text = Categoria.Nome;
                    txtDescricao.Text = Categoria.Descricao;
                    rdoBtnReceita.Checked = Categoria.TipoFluxo == (CategoriaManager.TIPO_FLUXO_RECEITA);
                    rdoBtnReceita.Enabled = false;
                    rdoBtnDespesa.Checked = Categoria.TipoFluxo == (CategoriaManager.TIPO_FLUXO_DESPESA);
                    rdoBtnDespesa.Enabled = false;
                    txtIcone.Text = Categoria.Icone;
                }
                else
                {
                    Categoria = new Categoria();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir o formulário de categoria. Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (!String.IsNullOrWhiteSpace(openFileDialogIcone.FileName))
                {
                    MessageBox.Show("FALTA IMPLEMENTAR! Aqui a aplicação salvará a imagem do ícone no servidor.");
                }

                Categoria.Nome = txtNome.Text.Trim();
                Categoria.Descricao = txtDescricao.Text.Trim();
                Categoria.TipoFluxo = rdoBtnReceita.Checked ? CategoriaManager.TIPO_FLUXO_RECEITA : CategoriaManager.TIPO_FLUXO_DESPESA;
                Categoria.Icone = txtIcone.Text.Trim();

                if (Categoria.IdCategoria == Guid.Empty)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao salvar categoria!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnEncontrarIcone_Click(object sender, EventArgs e)
        {
            openFileDialogIcone.ShowDialog();
        }

        private void OpenFileDialogIcone_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtIcone.Text = openFileDialogIcone.SafeFileName;
        }

        private void TxtIcone_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)
                && File.Exists(((string[])e.Data.GetData(DataFormats.FileDrop))[0])
                && Path.GetExtension(((string[])e.Data.GetData(DataFormats.FileDrop))[0]).ToLower() == ".png")
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TxtIcone_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)
                && File.Exists(((string[])e.Data.GetData(DataFormats.FileDrop))[0])
                && Path.GetExtension(((string[])e.Data.GetData(DataFormats.FileDrop))[0]).ToLower() == ".png")
            {
                openFileDialogIcone.FileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                txtIcone.Text = openFileDialogIcone.SafeFileName;
            }
        }
    }
}
