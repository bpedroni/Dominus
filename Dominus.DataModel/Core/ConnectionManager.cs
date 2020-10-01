using System;
using System.Configuration;
using System.Linq;
using System.Net;

namespace Dominus.DataModel.Core
{
    public class ConnectionManager
    {
        public const int STATUS_ATIVO = 1;
        public const int STATUS_INATIVO = 0;

        public DominusContext context;

        public void OpenConnection()
        {
            context = new DominusContext();
        }

        public void CloseConnection()
        {
            try
            {
                context.Dispose();
                context = null;

            }
            catch (Exception)
            {
                return;
            }
        }

        public void TestaConexao()
        {
            try
            {
                var teste = context.Usuarios.FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível fazer a conexão com o banco de dados!");
            }
        }

        public static bool VerificaSiteOnLine()
        {
            try
            {
                String urlDominus = ConfigurationManager.AppSettings["UrlSiteDominus"];
                HttpWebRequest request = WebRequest.Create(urlDominus) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
