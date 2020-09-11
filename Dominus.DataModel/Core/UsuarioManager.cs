using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public class UsuarioManager
    {
        public const int PERFIL_ADMINISTRADOR = 1;
        public const int PERFIL_USUARIO = 0;

        public static List<Usuario> GetUsuarios()
        {
            try
            {
                // Retorna uma lista de usuários cadastrados sistema:
                return ConnectionManager.context.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Usuario> GetUsuariosAtivos()
        {
            try
            {
                // Retorna uma lista de usuários que estão com o status ativo no sistema:
                return GetUsuarios().Where(x => x.Ativo == ConnectionManager.STATUS_ATIVO).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Usuario GetUsuarioById(Guid idUsuario)
        {
            try
            {
                // Verifica se existe um usuário com o id fornecido:
                Usuario usuario = GetUsuarios().FirstOrDefault(x => x.IdUsuario == idUsuario);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Usuario GetUsuarioByLogin(String login)
        {
            try
            {
                // Verifica se existe um usuário com o login fornecido:
                Usuario usuario = GetUsuarios().FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
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
                Usuario usuario = GetUsuarios().FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
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
                if (GetUsuarioByLogin(usuario.Login) != null)
                {
                    throw new Exception("O sistema já possui um usuário com o login '" + usuario.Login + "'.");
                }
                if (GetUsuarioByEmail(usuario.Email) != null)
                {
                    throw new Exception("O sistema já possui um usuário com o e-mail '" + usuario.Email + "'.");
                }
                // A aplicação gera um novo usuário com as definições padrões:
                usuario.IdUsuario = Guid.NewGuid();
                usuario.DataCriacao = DateTime.Now;
                usuario.PerfilAdministrador = PERFIL_USUARIO;
                usuario.Ativo = ConnectionManager.STATUS_ATIVO;
                ConnectionManager.context.Entry(usuario).State = EntityState.Added;
                ConnectionManager.context.SaveChanges();
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
                // A aplicação atualiza os dados do usuário fornecido:
                ConnectionManager.context.Entry(usuario).State = EntityState.Modified;
                ConnectionManager.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteUsuario(Usuario usuario)
        {
            try
            {
                // A aplicação remove o usuário fornecido alterando o seu status para inativo:
                usuario.Ativo = ConnectionManager.STATUS_INATIVO;
                ConnectionManager.context.Entry(usuario).State = EntityState.Modified;
                ConnectionManager.context.SaveChanges();
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
                Usuario usuario = GetUsuarios().FirstOrDefault(x => x.Login.ToLower() == login.ToLower() && x.Senha == senha);
                if (usuario == null)
                {
                    // Verifica se existe um usuário com e-mail e senha fornecidos:
                    usuario = GetUsuarios().FirstOrDefault(x => x.Email.ToLower() == login.ToLower() && x.Senha == senha);
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
