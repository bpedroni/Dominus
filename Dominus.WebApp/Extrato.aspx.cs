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
    public partial class Extrato : Page
    {
        protected static Usuario Usuario;
        protected static String Periodo;
        protected static List<Categoria> Categorias;
        protected static List<GridRowTransacao> Transacoes;

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
                Response.Redirect("Login?ReturnUrl=Extrato", true);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            CarregarGridTransacoes();
        }

        protected void CarregarGridTransacoes()
        {
            Periodo = Session["Periodo"]?.ToString();

            DateTime periodo = DateTime.ParseExact(Periodo, @"MMMM / yyyy", new CultureInfo("PT-br"));
            Transacoes = TransacaoManager.GetGridTransacoes(Usuario, periodo.Month, periodo.Year);

            gridTransacoes.DataSource = Transacoes;
            gridTransacoes.DataBind();
        }

        public static String GetCategorias()
        {
            return JsonConvert.SerializeObject(Categorias);
        }

        protected void GridTransacoes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            try
            {
                Guid idTransacao = (Guid)gridTransacoes.DataKeys[rowIndex].Value;
                GridRowTransacao rowTransacao = Transacoes.FirstOrDefault(x => x.IdTransacao.Equals(idTransacao));

                if (rowTransacao != null)
                {
                    txtIdTransacao.Value = idTransacao.ToString();
                    txtIdCategoria.Value = rowTransacao.IdCategoria.ToString();
                    txtDescricao.Value = rowTransacao.Descricao;
                    txtData.Value = rowTransacao.Data.ToString(@"dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
                    txtValor.Value = rowTransacao.Valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
                    txtComentario.Value = rowTransacao.Comentario;
                    rdoTransacao.Checked = rowTransacao.Provisionado == 0;
                    rdoProvisao.Checked = rowTransacao.Provisionado == 1;
                    rdoReceita.Checked = rowTransacao.TipoFluxo == CategoriaManager.TIPO_FLUXO_RECEITA;
                    rdoDespesa.Checked = rowTransacao.TipoFluxo == CategoriaManager.TIPO_FLUXO_DESPESA;
                    chkRepetirMes.Checked = false;
                    if (!String.IsNullOrWhiteSpace(rowTransacao.Identificacao))
                    {
                        txtValor.Disabled = true;
                        txtData.Disabled = true;
                        rdoTransacao.Disabled = true;
                        rdoProvisao.Disabled = true;
                    }
                    txtDeletarTransacao.Value = idTransacao.ToString();

                    if (e.CommandName.Equals("editTransacao"))
                    {
                        StartComponentsScript("gerenciarTransacaoModal", rowTransacao);
                    }
                    else if (e.CommandName.Equals("deleteTransacao"))
                    {
                        StartComponentsScript("deletarTransacaoModal", rowTransacao);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnSalvarTransacao_Click(object sender, EventArgs e)
        {
            GridRowTransacao rowTransacao = Transacoes.FirstOrDefault(x => x.IdTransacao.Equals(Guid.Parse(txtIdTransacao.Value)));
            if (rowTransacao == null)
            {
                rowTransacao = new GridRowTransacao
                {
                    TipoFluxo = rdoReceita.Checked ? CategoriaManager.TIPO_FLUXO_RECEITA : CategoriaManager.TIPO_FLUXO_DESPESA,
                    IdCategoria = !String.IsNullOrWhiteSpace(txtIdCategoria.Value) ? Guid.Parse(txtIdCategoria.Value) : Guid.Empty
                };
            }
            try
            {
                // Limpa a mensagem de alerta, caso haja algum texto:
                lblMsg.Text = String.Empty;

                // Valida se os campos obrigatórios estão preenchidos:
                if (String.IsNullOrWhiteSpace(txtDescricao.Value) || txtDescricao.Value.Trim().Length > 100)
                {
                    txtDescricao.Focus();
                    lblMsg.Text = "A descrição deve ser preenchida.";
                    StartComponentsScript("gerenciarTransacaoModal", rowTransacao);
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtValor.Value))
                {
                    txtValor.Focus();
                    lblMsg.Text = "O valor deve ser preenchido.";
                    StartComponentsScript("gerenciarTransacaoModal", rowTransacao);
                    return;
                }
                Decimal valor;
                try
                {
                    valor = Decimal.Parse(txtValor.Value.Replace(".", ""), CultureInfo.CreateSpecificCulture("pt-BR"));
                }
                catch (Exception)
                {
                    txtValor.Focus();
                    lblMsg.Text = "Insira um número válido para o valor.";
                    StartComponentsScript("gerenciarTransacaoModal", rowTransacao);
                    return;
                }
                if (!rdoReceita.Checked && !rdoDespesa.Checked)
                {
                    lblMsg.Text = "O tipo do lançamento deve ser definido.";
                    StartComponentsScript("gerenciarTransacaoModal", rowTransacao);
                    return;
                }
                if (!rdoTransacao.Checked && !rdoProvisao.Checked)
                {
                    lblMsg.Text = "O modo do lançamento deve ser definido.";
                    StartComponentsScript("gerenciarTransacaoModal", rowTransacao);
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtIdCategoria.Value))
                {
                    lblMsg.Text = "A categoria deve ser definida.";
                    StartComponentsScript("gerenciarTransacaoModal", rowTransacao);
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtData.Value))
                {
                    txtData.Focus();
                    lblMsg.Text = "A data deve ser preenchida.";
                    StartComponentsScript("gerenciarTransacaoModal", rowTransacao);
                    return;
                }
                DateTime data;
                try
                {
                    data = DateTime.ParseExact(txtData.Value, @"dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
                }
                catch (Exception)
                {
                    txtValor.Focus();
                    lblMsg.Text = "Insira uma data válida para o lançamento (dd/mm/aaaa).";
                    StartComponentsScript("gerenciarTransacaoModal", rowTransacao);
                    return;
                }

                Transacao transacao = new Transacao();
                if (!String.IsNullOrWhiteSpace(txtIdTransacao.Value))
                {
                    transacao = TransacaoManager.GetTransacaoById(Usuario, Guid.Parse(txtIdTransacao.Value));
                }
                transacao.IdUsuario = Usuario.IdUsuario;
                transacao.IdCategoria = Guid.Parse(txtIdCategoria.Value);
                transacao.Descricao = txtDescricao.Value;
                transacao.TipoFluxo = rdoReceita.Checked ? CategoriaManager.TIPO_FLUXO_RECEITA : CategoriaManager.TIPO_FLUXO_DESPESA;
                transacao.Comentario = txtComentario.Value;
                transacao.Provisionado = rdoProvisao.Checked ? 1 : 0;
                if (String.IsNullOrWhiteSpace(transacao.Identificacao))
                {
                    if (transacao.Provisionado == 0)
                    {
                        transacao.Valor = valor;
                        transacao.Data = data;
                        transacao.ValorProvisao = null;
                        transacao.DataProvisao = null;
                    }
                    else
                    {
                        transacao.Valor = null;
                        transacao.Data = null;
                        transacao.ValorProvisao = valor;
                        transacao.DataProvisao = data;
                    }
                }
                if (!String.IsNullOrWhiteSpace(txtIdTransacao.Value))
                {
                    TransacaoManager.EditTransacao(transacao);
                }
                else
                {
                    TransacaoManager.AddTransacao(transacao);
                }
                if (chkRepetirMes.Checked)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (transacao.Provisionado == 0)
                            transacao.Data = transacao.Data?.AddMonths(1);
                        else
                            transacao.DataProvisao = transacao.DataProvisao?.AddMonths(1);

                        TransacaoManager.AddTransacao(transacao);
                    }
                }
                UpdateSaldoScript("gerenciarTransacaoModal", "Lançamento salvo com sucesso!");
            }
            catch (Exception)
            {
                ShowMessageErrorScript("Ocorreu um erro ao salvar o lançamento. Entre em contato com o administrador!");
                StartComponentsScript("gerenciarTransacaoModal", rowTransacao);
            }
        }

        protected void BtnDeletarTransacao_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtDeletarTransacao.Value))
            {
                try
                {
                    Transacao transacao = TransacaoManager.GetTransacaoById(Usuario, Guid.Parse(txtDeletarTransacao.Value));
                    TransacaoManager.DeleteTransacao(transacao);

                    UpdateSaldoScript("deletarTransacaoModal", "Lançamento removido com sucesso!");
                }
                catch (Exception)
                {
                    ShowMessageErrorScript("Ocorreu um erro ao remover o lançamento. Entre em contato com o administrador!");
                    StartComponentsScript("deletarTransacaoModal", new GridRowTransacao());
                }
            }
        }

        private void StartComponentsScript(String modal, GridRowTransacao rowTransacao)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");

            if (!String.IsNullOrWhiteSpace(rowTransacao.TipoFluxo))
                sb.Append("listarCategorias('" + rowTransacao.TipoFluxo + "');");

            if (!rowTransacao.IdCategoria.Equals(Guid.Empty))
                sb.Append("$('#listCategorias').val('" + rowTransacao.IdCategoria.ToString() + "');");

            if (!String.IsNullOrWhiteSpace(rowTransacao.IconeCategoria))
                sb.Append("$('#imgCategoria')[0].src = '" + rowTransacao.IconeCategoria + "';");

            sb.Append("$('.fieldMoney').mask('#.##0,00', { reverse: true });");
            sb.Append("$('#txtData').datepicker({ dateFormat: 'dd/mm/yy' });");
            sb.Append("$('#" + modal + "').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "startScript", sb.ToString(), false);
        }

        private void UpdateSaldoScript(String modal, String message)
        {
            decimal saldo = TransacaoManager.GetSaldo(Usuario);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#lblSaldo').text('" + saldo.ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR")) + "');");
            sb.Append("$('#lblSaldo')[0].className = '" + (saldo < 0 ? "text-danger" : "text-success") + "';");
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