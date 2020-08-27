using System;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public class UsuarioManager
    {
        public static Usuario ValidarUsuario(String login, String senha)
        {
            DominusConnection connection = new DominusConnection();
            // Verifica se existe um usuário com login e senha fornecidos:
            Usuario usuario = connection.Usuarios.FirstOrDefault(x => x.Login.ToLower() == login.ToLower() && x.Senha == senha);
            if (usuario == null)
            {
                // Verifica se existe um usuário com e-mail e senha fornecidos:
                usuario = connection.Usuarios.FirstOrDefault(x => x.Email.ToLower() == login.ToLower() && x.Senha == senha);
            }
            return usuario;
        }

        public static Usuario GetUsuarioByEmail(String email)
        {
            DominusConnection connection = new DominusConnection();
            // Verifica se existe um usuário com o e-mail fornecido:
            Usuario usuario = connection.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            return usuario;
        }
    }
}
