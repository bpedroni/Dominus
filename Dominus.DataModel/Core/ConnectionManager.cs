using System;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public static class ConnectionManager
    {
        public const int STATUS_ATIVO = 1;
        public const int STATUS_INATIVO = 0;

        public static DominusContext context = new DominusContext();

        public static void TestaConexao()
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
    }
}
