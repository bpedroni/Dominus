using Dominus.DataModel.Core;
using System;
using System.Windows.Forms;

namespace Dominus.FormApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form splash = new FormSplash();
                splash.Show();
                Application.DoEvents();
                ConnectionManager.TestaConexao();
                splash.Close();
                Application.Run(new FormLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao iniciar a aplicação!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
    }
}
