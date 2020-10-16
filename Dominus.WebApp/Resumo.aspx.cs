using Dominus.DataModel;
using System;
using System.Data;

using System.Data.SqlClient;

namespace Dominus.WebApp
{
    public partial class Resumo : System.Web.UI.Page
    {
        protected static Usuario Usuario;

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

        protected void pesquisa()
        {
            SqlDataAdapter dadapter = new SqlDataAdapter();
            DataSet dt = new DataSet();
            int mes, ano;
            Double valor;

            // Verificar a necessidade de alterar o valor do objeto Usuario inicializado no carregamento da página (linha 18)
            //Usuario = Convert.ToString((Usuario)Session["Usuario"]);

            // Ver a possibilidade de criar objetos para exibir consulta
            // Não é necessário o uso de ' para identificar a variável string em um comando sql
            String str = "select Sum(t.valor), c.nome from Transacao t" +
                "inner join Categoria c on c.idCategoria = t.idCategoria" +
                "where idUsuario in" +
                "(select t.idUsuario from transacao t" +
                "inner join usuario u on t.idusuario = u.idusuario" +
                "and u.login = '@usuario' and month(data) = @mes and year(data) = @ano) group by idCategoria";

        }
    }

}