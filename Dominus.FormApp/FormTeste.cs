using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominus.DataModel;

namespace Dominus.FormApp
{
    public partial class FormTeste : Form
    {
        DominusConnection connection = new DominusConnection();

        public FormTeste()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = connection.Usuarios.First();
            label1.Text = usuario.Nome;
        }
    }
}
