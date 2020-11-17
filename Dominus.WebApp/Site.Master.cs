using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dominus.WebApp
{
    public partial class Site : MasterPage
    {
        protected static bool UsuarioConectado = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se o usuário está logado:
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                UsuarioConectado = true;

                // Atualiza o nome e o saldo do usuário na página:
                lblNomeUsuario.Text = usuario.Nome;
                decimal saldo = TransacaoManager.GetSaldo(usuario);
                lblSaldo.Text = saldo.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
                lblSaldo.CssClass = saldo < 0 ? "text-danger" : "text-success";

                // Verifica se o usuário possui chamados respondidos e não validados e exibe um alerta ao usuário:
                List<Chamado> chamados = ChamadoManager.GetChamadosAbertosRespondidos(usuario);
                if (chamados.Count > 0)
                {
                    lblChamados.Visible = true;
                    lblChamados.Text = chamados.Count.ToString();
                    linkContato.Title = "Você tem mensagem(s) respondida(s)";
                }

                // Verifica se o usuário selecionou um período na página e atualiza o período na Session:
                if (IsPostBack && ddListaPeriodo.SelectedIndex >= 0)
                {
                    Session["Periodo"] = ddListaPeriodo.SelectedValue;
                }

                // Atualiza a lista de períodos com os meses que contêm transações do usuário:
                AtualizaListaPeriodos(usuario);

                // Seleciona na lista o período do escopo baseado na Session do usuário:
                if (Session["Periodo"] != null)
                {
                    ddListaPeriodo.SelectedValue = Session["Periodo"].ToString();
                }
            }
            else
            {
                UsuarioConectado = false;
            }
        }

        // Método que carrega a lista de períodos das transações do usuário:
        private void AtualizaListaPeriodos(Usuario usuario)
        {
            DateTime periodo = DateTime.Now;
            if (Session["Periodo"] != null)
            {
                periodo = DateTime.ParseExact(Session["Periodo"].ToString(), @"MMMM / yyyy", CultureInfo.GetCultureInfo("pt-BR"));
            }

            // Define as variáveis dos extremos do período, inicializando com a data atual:
            DateTime dataInicio = DateTime.Now.AddMonths(-2) < periodo ? DateTime.Now.AddMonths(-2) : periodo;
            DateTime dataFim = DateTime.Now.AddMonths(2) > periodo ? DateTime.Now.AddMonths(2) : periodo;

            // Define a lista de transações do usuário:
            List<GridRowTransacao> transacoes = TransacaoManager.GetGridTransacoes(usuario);
            if (transacoes.Count > 0)
            {
                // Define a primeira e última transações do usuário baseadas na data:
                GridRowTransacao primeiraTransacao = transacoes.Last();
                GridRowTransacao ultimaTransacao = transacoes.First();

                // Atualiza as datas de início e fim da lista de períodos com as datas das transações:
                if ((DateTime)primeiraTransacao.Data < dataInicio)
                {
                    dataInicio = (DateTime)primeiraTransacao.Data;
                }
                if ((DateTime)ultimaTransacao.Data > dataFim)
                {
                    dataFim = (DateTime)ultimaTransacao.Data;
                }
            }

            // Limpa a lista atual e adiciona os períodos de acordo com as datas de início e fim:
            ddListaPeriodo.Items.Clear();
            while (dataInicio.Year < dataFim.Year || (dataInicio.Year == dataFim.Year && dataInicio.Month <= dataFim.Month))
            {
                String data = dataInicio.ToString(@"MMMM / yyyy", CultureInfo.GetCultureInfo("pt-BR"));
                ListItem item = new ListItem(data);
                ddListaPeriodo.Items.Add(item);
                dataInicio = dataInicio.AddMonths(1);
            }
        }

        protected void BtnMesAnterior_Click(object sender, EventArgs e)
        {
            // Altera o período do escopo, baseado na Session do usuário, para o mês anterior:
            CalculaMesPeriodo(-1);
        }

        protected void BtnMesSeguinte_Click(object sender, EventArgs e)
        {
            // Altera o período do escopo, baseado na Session do usuário, para o mês seguinte:
            CalculaMesPeriodo(1);
        }

        private void CalculaMesPeriodo(int mes)
        {
            DateTime periodo = DateTime.ParseExact(ddListaPeriodo.SelectedValue, @"MMMM / yyyy", CultureInfo.GetCultureInfo("pt-BR"));
            String novoPeriodo = periodo.AddMonths(mes).ToString(@"MMMM / yyyy", CultureInfo.GetCultureInfo("pt-BR"));

            // Insere o novo período na lista no caso de não conter este período na lista:
            if (!ddListaPeriodo.DataValueField.Contains(novoPeriodo))
            {
                ddListaPeriodo.Items.Add(novoPeriodo);
            }
            // Altera o período do escopo na Session do usuário e atualiza a seleção na lista:
            Session["Periodo"] = novoPeriodo;
            ddListaPeriodo.SelectedValue = novoPeriodo;
        }
    }
}