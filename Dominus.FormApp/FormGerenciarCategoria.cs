using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormGerenciarCategoria : Form
    {
        private Categoria Categoria;

        public FormGerenciarCategoria(Categoria categoria = null)
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
                    Image image = CategoriaManager.GetIconeCategoria(Categoria);
                    if (image != null)
                    {
                        pictureIcone.Image = new Bitmap(image, new Size(48, 48));
                    }
                }
                else
                {
                    Categoria = new Categoria();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir o formulário de categoria. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria
                {
                    Nome = txtNome.Text.Trim(),
                    Descricao = txtDescricao.Text.Trim(),
                    TipoFluxo = rdoBtnReceita.Checked ? CategoriaManager.TIPO_FLUXO_RECEITA : rdoBtnDespesa.Checked ? CategoriaManager.TIPO_FLUXO_DESPESA : "",
                    Icone = txtIcone.Text
                };

                if (Categoria.IdCategoria == Guid.Empty)
                {
                    CategoriaManager.AddCategoria(categoria);
                }
                else
                {
                    categoria.IdCategoria = Categoria.IdCategoria;
                    CategoriaManager.EditCategoria(categoria);
                }
                if (!String.IsNullOrWhiteSpace(openFileDialogIcone.FileName))
                {
                    try
                    {
                        if (!CategoriaManager.SaveIconeCategoria(categoria, openFileDialogIcone.FileName))
                        {
                            MessageBox.Show("Não foi possível salvar a imagem selecionada.", "Erro ao salvar ícone!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar imagem no servidor. " + Environment.NewLine + ex.Message, "Erro ao salvar ícone!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                switch (ex.GetType().Name)
                {
                    case "CategoriaNomeException":
                        MessageBox.Show(ex.Message, "Revise o preenchimento do nome", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNome.Focus();
                        break;
                    case "CategoriaTipoFluxoException":
                        MessageBox.Show(ex.Message, "Revise o preenchimento da senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "CategoriaDescricaoException":
                        MessageBox.Show(ex.Message, "Revise o preenchimento da descrição", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDescricao.Focus();
                        break;
                    case "CategoriaIconeException":
                        MessageBox.Show(ex.Message, "Revise o preenchimento do ícone", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtIcone.Focus();
                        break;
                    default:
                        MessageBox.Show("Erro ao salvar categoria. " + Environment.NewLine + ex.Message, "Erro!!! Contate o administrador do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
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
            try
            {
                Image image = new Bitmap(openFileDialogIcone.FileName);
                if (image != null)
                {
                    pictureIcone.Image = new Bitmap(image, new Size(48, 48));
                    txtIcone.Text = openFileDialogIcone.SafeFileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao carregar a imagem selecionada.", "Erro ao abrir arquivo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
