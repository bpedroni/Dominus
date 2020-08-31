using System;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public static class ConnectionManager
    {
        public static DominusConnection connection = new DominusConnection();

        public static void TestaConexao()
        {
            try
            {
                var teste = connection.Usuarios.FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível fazer a conexão com o banco de dados!");
            }
        }
    }
}
