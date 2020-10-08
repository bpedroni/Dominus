using System;
using System.Configuration;
using System.Linq;
using System.Net;

namespace Dominus.DataModel.Core
{
    // Classe com o conjunto de métodos relacionados à conexão com o banco de dados e com o site do Dominus
    public class ConnectionManager
    {
        public const int STATUS_ATIVO = 1;
        public const int STATUS_INATIVO = 0;

        public DominusContext context;

        // Método utilizado para abrir uma conexão com o banco de dados
        public void OpenConnection()
        {
            // Abre uma conexão com o banco de dados:
            context = new DominusContext();
        }

        // Método utilizado para fechar a conexão com o banco de dados
        public void CloseConnection()
        {
            try
            {
                // Fecha a conexão com o banco de dados:
                context.Dispose();
                context = null;

            }
            catch (Exception)
            {
                context = null;
            }
        }

        // Método utilizado para testar a conexão com o banco de dados
        public void TestaConexao()
        {
            try
            {
                // Verifica se a conexão retorna dados e pode ser utilizada no sistema:
                Usuario teste = context.Usuarios.FirstOrDefault();
            }
            catch (Exception)
            {
                // Gera uma exceção de falha na conexão com o banco de dados:
                throw new Exception("Não foi possível fazer a conexão com o banco de dados!");
            }
        }

        // Método utilizado para verificar se o site do Dominus está funcionando
        public static bool VerificaSiteOnLine()
        {
            try
            {
                String urlDominus = ConfigurationManager.AppSettings["UrlSiteDominus"];

                // Cria uma requisição com o site do Dominus:
                HttpWebRequest request = WebRequest.Create(urlDominus) as HttpWebRequest;
                request.Method = "HEAD";

                // Envia uma resposta da requisição criada para o site do Dominus:
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();

                // Retorna verdadeiro se a reposta da requisição estiver com o status OK ou falso caso contrário:
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
