using System;
using System.Text;

namespace Dominus.DataModel.Core
{
    public class Codificador
    {
        // Chave secreta utilizada para proteger o texto:
        private const String CHAVE = "**&**dOmInUs**#**";

        // Método utilizado para criptografar um texto fornecido:
        public static String Criptografar(String texto)
        {
            try
            {
                Byte[] b = Encoding.UTF8.GetBytes(texto);
                String codigo = Convert.ToBase64String(b);

                b = Encoding.UTF8.GetBytes(CHAVE + codigo + CHAVE);

                codigo = Convert.ToBase64String(b);

                return codigo;
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        // Método utilizado para descriptografar um texto fornecido:
        public static String Descriptografar(String codigo)
        {
            try
            {
                Byte[] b = Convert.FromBase64String(codigo);
                String texto = Encoding.UTF8.GetString(b);

                b = Convert.FromBase64String(texto.Replace(CHAVE, String.Empty));
                texto = Encoding.UTF8.GetString(b);

                return texto;
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}
