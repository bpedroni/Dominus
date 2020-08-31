using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public class UsuarioManager
    {
        public static List<Usuario> GetUsuarios()
        {
            try
            {
                return ConnectionManager.connection.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Usuario ValidarUsuario(String login, String senha)
        {
            try
            {
                // Verifica se existe um usuário com login e senha fornecidos:
                Usuario usuario = ConnectionManager.connection.Usuarios.FirstOrDefault(x => x.Login.ToLower() == login.ToLower() && x.Senha == senha);
                if (usuario == null)
                {
                    // Verifica se existe um usuário com e-mail e senha fornecidos:
                    usuario = ConnectionManager.connection.Usuarios.FirstOrDefault(x => x.Email.ToLower() == login.ToLower() && x.Senha == senha);
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Usuario GetUsuarioById(int idUsuario)
        {
            try
            {
                Usuario usuario = ConnectionManager.connection.Usuarios.FirstOrDefault(x => x.IdUsuario == idUsuario);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Usuario GetUsuarioByEmail(String email)
        {
            try
            {
                // Verifica se existe um usuário com o e-mail fornecido:
                Usuario usuario = ConnectionManager.connection.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddUsuario(Usuario usuario)
        {
            try
            {
                ConnectionManager.connection.Usuarios.Add(usuario);
                ConnectionManager.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditUsuario(Usuario usuario)
        {
            try
            {
                ConnectionManager.connection.Entry(usuario).State = EntityState.Modified;
                ConnectionManager.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
