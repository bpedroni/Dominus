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
            if (Session["Usuario"] is Usuario usuario)
            {
                UsuarioConectado = true;

                // Atualiza o nome e o saldo do usuário na página:
                lblNomeUsuario.Text = usuario.Nome;
                lblSaldo.Text = TransacaoManager.GetSaldo(usuario).ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR"));

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
            // Define as variáveis dos extremos do período, inicializando com a data atual:
            DateTime dataInicio = DateTime.Now;
            DateTime dataFim = DateTime.Now;

            // Define a lista de transações do usuário:
            List<Transacao> transacoes = TransacaoManager.GetTransacoes(usuario);
            if (transacoes.Count > 0)
            {
                // Define a primeira e última transações do usuário baseadas na data:
                Transacao primeiraTransacao = transacoes.Aggregate((x1, x2) => x1.Data < x2.Data ? x1 : x2);
                Transacao ultimaTransacao = transacoes.Aggregate((x1, x2) => x1.Data > x2.Data ? x1 : x2);

                // Atualiza as datas de início e fim da lista de períodos com as datas das transações:
                if ((DateTime)primeiraTransacao.Data < DateTime.Now)
                {
                    dataInicio = (DateTime)primeiraTransacao.Data;
                }
                if ((DateTime)ultimaTransacao.Data > DateTime.Now)
                {
                    dataFim = (DateTime)ultimaTransacao.Data;
                }
            }

            // Limpa a lista atual e adiciona os períodos de acordo com as datas de início e fim:
            ddListaPeriodo.Items.Clear();
            while (dataInicio.Year <= dataFim.Year && dataInicio.Month <= dataFim.Month)
            {
                String data = dataInicio.ToString(@"MMMM / yyyy", new CultureInfo("PT-br"));
                ListItem item = new ListItem(data);
                ddListaPeriodo.Items.Add(item);
                dataInicio = dataInicio.AddMonths(1);
            }
        }
    }
}