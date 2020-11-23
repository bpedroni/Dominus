using Dominus.DataModel;
using Dominus.DataModel.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;

namespace Dominus.WebApp
{
    public partial class Relatorios : Page
    {
        protected static Usuario Usuario;
        protected static String Periodo;
        protected static List<RelatorioUsuario> RelatorioUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario = (Usuario)Session["Usuario"];
            }
            else
            {
                Usuario = null;
                Response.Redirect("Login?ReturnUrl=Relatorios", true);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            CarregarRelatorioUsuario();
        }

        protected void CarregarRelatorioUsuario()
        {
            DateTime? dataInicial, dataFinal;
            try
            {
                dataInicial = DateTime.ParseExact(txtDataInicial.Value + " 00:00:00", @"dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR"));
            }
            catch (Exception)
            {
                dataInicial = null;
            }
            try
            {
                dataFinal = DateTime.ParseExact(txtDataFinal.Value + " 23:59:59", @"dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("pt-BR"));
            }
            catch (Exception)
            {
                dataFinal = null;
            }

            RelatorioUsuario = RelatorioManager.GetRelatorioUsuario(Usuario, dataInicial, dataFinal);
        }

        public static String GetRelatorioUsuario()
        {
            return JsonConvert.SerializeObject(RelatorioUsuario);
        }

        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarRelatorioUsuario();
            UpdateRelatorioUsuarioScript();
        }

        private void UpdateRelatorioUsuarioScript()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("window._relatorioUsuario = " + GetRelatorioUsuario() + ";");
            sb.Append("$('#" + txtDataInicial.ClientID + "').datepicker({ dateFormat: 'dd/mm/yy' });");
            sb.Append("$('#" + txtDataFinal.ClientID + "').datepicker({ dateFormat: 'dd/mm/yy' });");
            sb.Append("carregarPivotTable($('#pnlPivot'))");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "updateScript", sb.ToString(), false);
        }
    }
}