using Dominus.DataModel;
using Dominus.DataModel.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dominus.WebApp
{
    public partial class Relatorios : Page
    {
        protected static Usuario Usuario;
        protected static String Periodo;
        protected static List<TipoRelatorio> TiposRelatorio;
        protected static List<ItemRelatorio> ListaRelatorios;
        protected static List<RelatorioUsuario> RelatorioUsuario;
        protected static ItemRelatorio ItemRelatorio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario = (Usuario)Session["Usuario"];
                if (!IsPostBack)
                {
                    CarregarDadosRelatorios();
                }
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

        protected void CarregarDadosRelatorios()
        {
            TiposRelatorio = RelatorioManager.GetTiposRelatorio();
            ListaRelatorios = new List<ItemRelatorio>();
            ItemRelatorio = null;

            ddListaRelatorios.Items.Clear();
            ddListaRelatorios.Items.Add(new ListItem());

            foreach (Relatorio relatorio in RelatorioManager.GetRelatorios(Usuario))
            {
                ListaRelatorios.Add(new ItemRelatorio
                {
                    IdRelatorio = relatorio.IdRelatorio,
                    Nome = relatorio.Nome,
                    Rows = JsonConvert.DeserializeObject(relatorio.InfoLinha),
                    Cols = JsonConvert.DeserializeObject(relatorio.InfoColuna),
                    Renderer = TiposRelatorio.Find(x => x.IdTipoRelatorio == relatorio.IdTipoRelatorio)?.Tipo
                });

                ListItem item = new ListItem(relatorio.Nome, relatorio.IdRelatorio.ToString());
                ddListaRelatorios.Items.Add(item);
            }
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

        public static String GetTiposRelatorio()
        {
            return JsonConvert.SerializeObject(TiposRelatorio);
        }

        public static String GetItemRelatorio()
        {
            return JsonConvert.SerializeObject(ItemRelatorio);
        }

        public static String GetRelatorioUsuario()
        {
            return JsonConvert.SerializeObject(RelatorioUsuario);
        }

        protected void DdListaRelatorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Guid.TryParse(ddListaRelatorios.SelectedValue, out Guid guid))
            {
                ItemRelatorio = ListaRelatorios.Find(x => x.IdRelatorio == guid);
            }

            UpdateRelatorioUsuarioScript();
        }

        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarRelatorioUsuario();
            UpdateRelatorioUsuarioScript();
        }

        protected void BtnSalvarRelatorio_Click(object sender, EventArgs e)
        {
            // Limpa a mensagem de alerta, caso haja algum texto:
            lblMsg.Text = String.Empty;

            if (String.IsNullOrWhiteSpace(txtNome.Value) || txtNome.Value.Trim().Length > 100)
            {
                lblMsg.Text = "O nome deve ser preenchido (até 100 caracteres).";
            }

            if (Guid.TryParse(txtTipoRelatorio.Value, out Guid guid))
            {
                try
                {
                    Guid idRelatorio = Guid.NewGuid();
                    RelatorioManager.AddRelatorio(new Relatorio
                    {
                        IdRelatorio = idRelatorio,
                        IdTipoRelatorio = guid,
                        IdUsuario = Usuario.IdUsuario,
                        Nome = txtNome.Value,
                        InfoLinha = txtInfoLinha.Value,
                        InfoColuna = txtInfoColuna.Value
                    });

                    CarregarDadosRelatorios();
                    ddListaRelatorios.SelectedValue = idRelatorio.ToString();

                    UpdateSaldoScript("salvarModeloRelatorioModal", "Modelo de relatório salvo com sucesso!");
                }
                catch (Exception ex)
                {
                    switch (ex.GetType().Name)
                    {
                        case "RelatorioUsuarioException":
                        case "RelatorioTipoException":
                        case "RelatorioNomeException":
                        case "RelatorioInfoLinhaException":
                        case "RelatorioInfoColunaException":
                            ShowMessageErrorScript(ex.Message);
                            break;
                        default:
                            ShowMessageErrorScript("Ocorreu um erro ao salvar o lançamento. Entre em contato com o administrador!");
                            break;
                    }
                }
            }
        }

        private void UpdateRelatorioUsuarioScript()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("window._relatorioUsuario = " + GetRelatorioUsuario() + ";");
            sb.Append("window._relatorio = " + GetItemRelatorio() + ";");
            sb.Append("$('#" + txtDataInicial.ClientID + "').datepicker({ dateFormat: 'dd/mm/yy' });");
            sb.Append("$('#" + txtDataFinal.ClientID + "').datepicker({ dateFormat: 'dd/mm/yy' });");
            sb.Append("carregarPivotTable($('#pnlPivot'))");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "updateScript", sb.ToString(), false);
        }

        private void UpdateSaldoScript(String modal, String message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("swal({ title: 'Concluído', text: '" + message + "!', type: 'success', timer: 2000 });");
            sb.Append("$('#" + modal + "').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "closeModalScript", sb.ToString(), false);
        }

        private void ShowMessageErrorScript(String message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("swal({ title: 'Erro', text: '" + message + "', type: 'error', timer: 5000 });");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "closeModalScript", sb.ToString(), false);
        }
    }
}