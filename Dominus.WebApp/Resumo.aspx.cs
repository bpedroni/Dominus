using Dominus.DataModel;
using Dominus.DataModel.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Dominus.WebApp
{
    public partial class Resumo : System.Web.UI.Page
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

            DateTime periodo = DateTime.ParseExact(Periodo, @"MMMM / yyyy", new CultureInfo("PT-br"));
            Transacoes = TransacaoManager.GetGridTransacoes(Usuario, periodo.Month, periodo.Year).Where(x => x.Modo == "Transação").ToList();

            gridTransacoes.DataSource = Transacoes.Take(3).ToList();
            gridTransacoes.DataBind();
        }

        public static String GetTransacoes()
        {
            return JsonConvert.SerializeObject(Transacoes);
        }
    }
}