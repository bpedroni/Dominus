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
    public partial class Resumo : Page
    {
        protected static Usuario Usuario;
        protected static String Periodo;
        protected static List<GridRowTransacao> Transacoes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario = (Usuario)Session["Usuario"];
            }
            else
            {
                Response.Redirect("Login?ReturnUrl=Resumo", true);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            CarregarGridTransacoes();
        }

        protected void CarregarGridTransacoes()
        {
            Periodo = Session["Periodo"]?.ToString();

            DateTime periodo = DateTime.ParseExact(Periodo, @"MMMM / yyyy", CultureInfo.GetCultureInfo("pt-BR"));
            Transacoes = TransacaoManager.GetGridTransacoes(Usuario, periodo.Month, periodo.Year).Where(x => x.Modo == TransacaoManager.MODO_TRANSACAO).ToList();

            gridTransacoes.DataSource = Transacoes.Take(3).ToList();
            gridTransacoes.DataBind();
        }

        public static String GetTransacoes()
        {
            return JsonConvert.SerializeObject(Transacoes);
        }
    }
}