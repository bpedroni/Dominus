using Dominus.DataModel;
using Dominus.DataModel.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;

namespace Dominus.WebApp
{
    public partial class Planejamento : Page
    {
        protected static Usuario Usuario;
        protected static String Periodo;
        protected static List<Categoria> Categorias;
        protected static List<GridRowPlanejamento> Planejamentos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario = (Usuario)Session["Usuario"];
                if (!IsPostBack)
                {
                    Categorias = CategoriaManager.GetCategoriasAtivas();
                }
            }
            else
            {
                Usuario = null;
                Response.Redirect("Login?ReturnUrl=Planejamento", true);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            CarregarPlanejamentoCategorias();
        }

        protected void CarregarPlanejamentoCategorias()
        {
            Periodo = Session["Periodo"]?.ToString();

            DateTime periodo = DateTime.ParseExact(Periodo, @"MMMM / yyyy", CultureInfo.GetCultureInfo("pt-BR"));
            Planejamentos = PlanejamentoManager.GetRowPlanejamentos(Usuario, periodo.Month, periodo.Year);

            gridPlanejamentos.DataSource = Planejamentos;
            gridPlanejamentos.DataBind();
        }

        public static String GetPlanejamentos()
        {
            DateTime periodo = DateTime.ParseExact(Periodo, @"MMMM / yyyy", CultureInfo.GetCultureInfo("pt-BR"));
            Planejamentos = PlanejamentoManager.GetRowPlanejamentos(Usuario, periodo.Month, periodo.Year);
            return JsonConvert.SerializeObject(Planejamentos);
        }

        public static String GetCategorias()
        {
            return JsonConvert.SerializeObject(Categorias);
        }

        public static String GetInicioPeriodo()
        {
            DateTime periodo = DateTime.ParseExact(Periodo, @"MMMM / yyyy", CultureInfo.GetCultureInfo("pt-BR"));
            return periodo.ToString(@"dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        }

        protected void GridPlanejamentos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                Guid idCategoria = (Guid)gridPlanejamentos.DataKeys[rowIndex].Value;
                GridRowPlanejamento rowPlanejamento = Planejamentos.FirstOrDefault(x => x.IdCategoria.Equals(idCategoria));

                if (rowPlanejamento != null)
                {
                    txtIdPlanejamento.Value = rowPlanejamento.IdPlanejamento.ToString();
                    txtIdCategoria.Value = idCategoria.ToString();
                    rdoReceita.Checked = rowPlanejamento.TipoFluxo == CategoriaManager.TIPO_FLUXO_RECEITA;
                    rdoDespesa.Checked = rowPlanejamento.TipoFluxo == CategoriaManager.TIPO_FLUXO_DESPESA;
                    txtValor.Value = rowPlanejamento.ValorPlanejado > 0 ? rowPlanejamento.ValorPlanejado.ToString("N", CultureInfo.GetCultureInfo("pt-BR")) : String.Empty;
                    chkRepetirMes.Checked = false;
                    txtRepetirMes.Text = "3";
                    txtDeletarPlanejamento.Value = rowPlanejamento.IdPlanejamento.ToString();

                    if (e.CommandName.Equals("editPlanejamento"))
                    {
                        StartComponentsScript("gerenciarPlanejamentoModal", rowPlanejamento);
                    }
                    else if (e.CommandName.Equals("deletePlanejamento"))
                    {
                        StartComponentsScript("deletarPlanejamentoModal", rowPlanejamento);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnSalvarPlanejamento_Click(object sender, EventArgs e)
        {
            GridRowPlanejamento rowPlanejamento = null;
            if (Guid.TryParse(txtIdPlanejamento.Value, out Guid guid))
            {
                rowPlanejamento = Planejamentos.FirstOrDefault(x => x.IdPlanejamento.Equals(guid));
            }
            if (rowPlanejamento == null)
            {
                rowPlanejamento = new GridRowPlanejamento
                {
                    TipoFluxo = rdoReceita.Checked ? CategoriaManager.TIPO_FLUXO_RECEITA : CategoriaManager.TIPO_FLUXO_DESPESA,
                    IdCategoria = !String.IsNullOrWhiteSpace(txtIdCategoria.Value) ? Guid.Parse(txtIdCategoria.Value) : Guid.Empty
                };
            }
            try
            {
                // Limpa a mensagem de alerta, caso haja algum texto:
                lblMsg.Text = String.Empty;

                if (!rdoReceita.Checked && !rdoDespesa.Checked)
                {
                    lblMsg.Text = "O tipo deve ser definido.";
                    StartComponentsScript("gerenciarPlanejamentoModal", rowPlanejamento);
                    return;
                }
                if (!Decimal.TryParse(txtValor.Value.Replace(".", ""), NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("pt-BR"), out Decimal valor))
                {
                    txtValor.Focus();
                    lblMsg.Text = "Insira um número válido para o valor.";
                    StartComponentsScript("gerenciarPlanejamentoModal", rowPlanejamento);
                    return;
                }
                if (chkRepetirMes.Checked && !Int32.TryParse(txtRepetirMes.Text, out int num))
                {
                    lblMsg.Text = "O número de meses deve ser um número inteiro. Coloque um número válido ou desmarque esta opção.";
                    StartComponentsScript("gerenciarPlanejamentoModal", rowPlanejamento);
                    return;
                }

                DataModel.Planejamento planejamento = new DataModel.Planejamento();
                if (!rowPlanejamento.IdPlanejamento.Equals(Guid.Empty))
                {
                    planejamento.IdPlanejamento = guid;
                }
                planejamento.IdUsuario = Usuario.IdUsuario;
                planejamento.IdCategoria = Guid.Parse(txtIdCategoria.Value);
                DateTime periodo = DateTime.ParseExact(Periodo, @"MMMM / yyyy", CultureInfo.GetCultureInfo("pt-BR"));
                planejamento.Mes = periodo.Month;
                planejamento.Ano = periodo.Year;
                planejamento.Valor = valor;
                PlanejamentoManager.SavePlanejamento(planejamento);

                if (chkRepetirMes.Checked && Int32.TryParse(txtRepetirMes.Text, out int numMeses))
                {
                    for (int i = 0; i < Math.Min(numMeses, 12); i++)
                    {
                        periodo = periodo.AddMonths(1);
                        planejamento.Mes = periodo.Month;
                        planejamento.Ano = periodo.Year;
                        PlanejamentoManager.SavePlanejamento(planejamento);
                    }
                }
                ShowMessageSuccessScript("gerenciarPlanejamentoModal", "Planejamento salvo com sucesso!");
            }
            catch (Exception ex)
            {
                switch (ex.GetType().Name)
                {
                    case "PlanejamentoUsuarioException":
                    case "PlanejamentoCategoriaException":
                    case "PlanejamentoMesException":
                    case "PlanejamentoValorException":
                        ShowMessageErrorScript(ex.Message);
                        break;
                    default:
                        ShowMessageErrorScript("Ocorreu um erro ao salvar o planejamento. Entre em contato com o administrador!");
                        break;
                }
                StartComponentsScript("gerenciarTransacaoModal", rowPlanejamento);
            }
        }

        protected void BtnDeletarPlanejamento_Click(object sender, EventArgs e)
        {
            if (Guid.TryParse(txtDeletarPlanejamento.Value, out Guid guid))
            {
                try
                {
                    DataModel.Planejamento planejamento = PlanejamentoManager.GetPlanejamentoById(guid);
                    if (planejamento != null)
                    {
                        PlanejamentoManager.DeletePlanejamento(planejamento);
                    }

                    ShowMessageSuccessScript("deletarPlanejamentoModal", "Valor planejado removido com sucesso!");
                }
                catch (Exception)
                {
                    ShowMessageErrorScript("Ocorreu um erro ao remover o valor planejado. Entre em contato com o administrador!");
                    StartComponentsScript("deletarPlanejamentoModal", new GridRowPlanejamento());
                }
            }
        }

        private void StartComponentsScript(String modal, GridRowPlanejamento rowPlanejamento)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");

            if (!String.IsNullOrWhiteSpace(rowPlanejamento.TipoFluxo))
                sb.Append("listarCategorias('" + rowPlanejamento.TipoFluxo + "');");

            if (!rowPlanejamento.IdCategoria.Equals(Guid.Empty))
                sb.Append("$('#listCategorias').val('" + rowPlanejamento.IdCategoria.ToString() + "');");

            if (!String.IsNullOrWhiteSpace(rowPlanejamento.IconeCategoria))
            {
                sb.Append("$('#imgCategoria')[0].src = '" + rowPlanejamento.IconeCategoria + "';");
                sb.Append("$('#imgCategoria')[0].title = '" + rowPlanejamento.Categoria + "';");
            }

            sb.Append("$('.fieldMoney').mask('#.##0,00', { reverse: true });");
            sb.Append("$('#" + modal + "').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "startScript", sb.ToString(), false);
        }

        private void ShowMessageSuccessScript(String modal, String message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("swal({ title: 'Concluído', text: '" + message + "!', type: 'success', timer: 2000 });");
            sb.Append("$('#" + modal + "').modal('hide');");
            sb.Append("window._planejamentos = " + GetPlanejamentos() + ";");
            sb.Append("window._chartPlanejamento.destroy();");
            sb.Append("desenharGraficoPlanejamento();");
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