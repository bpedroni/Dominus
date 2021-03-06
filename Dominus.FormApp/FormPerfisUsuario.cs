﻿using Dominus.DataModel;
using Dominus.DataModel.Core;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    public partial class FormPerfisUsuario : Form
    {
        public FormPerfisUsuario()
        {
            InitializeComponent();
            try
            {
                DataGridViewImageColumn column = (DataGridViewImageColumn)gridPerfisUsuario.Columns["UsuarioSalvar"];
                column.Image = IconChar.Save.ToBitmap(20, System.Drawing.Color.DarkGreen);
            }
            catch (Exception) { }
        }

        private void FormPerfisUsuario_Shown(object sender, EventArgs e)
        {
            CarregarGridPerfisUsuario();
        }

        private void CarregarGridPerfisUsuario(String usuario = null)
        {
            List<Usuario> usuarios = UsuarioManager.GetUsuariosAtivos().Where(x => x.IdUsuario != LoginInfo.Usuario.IdUsuario).ToList();
            gridPerfisUsuario.DataSource = usuarios.Where(x =>
                String.IsNullOrEmpty(usuario) ||
                x.Nome.ToLower().Contains(usuario.ToLower()) ||
                x.Login.ToLower().Contains(usuario.ToLower()))
            .OrderBy(x => x.Nome).ToList();
        }

        private void TxtFiltroUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnFiltrarUsuario_Click(this, new EventArgs());
            }
        }

        private void BtnFiltrarUsuario_Click(object sender, EventArgs e)
        {
            CarregarGridPerfisUsuario(txtFiltroUsuario.Text);
        }

        private void BtnAtualizarPerfis_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = new List<Usuario>();
            foreach (DataGridViewRow row in gridPerfisUsuario.Rows)
            {
                Usuario usuario = (Usuario)row.DataBoundItem;
                usuarios.Add(usuario);
            }
            UsuarioManager.EditPerfilUsuario(usuarios);
            MessageBox.Show("Os perfis foram atualizados com sucesso.", "Perfis atualizados!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GridPerfisUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewColumn column = senderGrid.Columns[e.ColumnIndex];
                if (column.Name == "UsuarioSalvar")
                {
                    List<Usuario> usuarios = new List<Usuario>();
                    Usuario usuario = (Usuario)gridPerfisUsuario.Rows[e.RowIndex].DataBoundItem;
                    usuarios.Add(usuario);
                    UsuarioManager.EditPerfilUsuario(usuarios);
                    MessageBox.Show("O perfil do usuário " + usuario.Login + " foi atualizado com sucesso.", "Perfil atualizado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
