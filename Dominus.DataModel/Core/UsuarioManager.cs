using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;

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
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                List<Usuario> usuarios = connection.context.Usuarios.ToList();
                connection.CloseConnection();
                return usuarios;
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
                Usuario usuario = GetUsuarios().FirstOrDefault(x => x.Login.Equals(login, StringComparison.CurrentCultureIgnoreCase));
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
                Usuario usuario = GetUsuarios().FirstOrDefault(x => x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
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
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                connection.context.Entry(usuario).State = EntityState.Added;
                connection.context.SaveChanges();
                connection.CloseConnection();
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
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                connection.context.Entry(usuario).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
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
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                connection.context.Entry(usuario).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
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
                String senhaCodificada = Codificador.Criptografar(senha);
                // Verifica se existe um usuário com login e senha fornecidos:
                Usuario usuario = GetUsuarios().FirstOrDefault(x => x.Login.Equals(login, StringComparison.CurrentCultureIgnoreCase) && x.Senha == senhaCodificada);
                if (usuario == null)
                {
                    // Verifica se existe um usuário com e-mail e senha fornecidos:
                    usuario = GetUsuarios().FirstOrDefault(x => x.Email.Equals(login, StringComparison.CurrentCultureIgnoreCase) && x.Senha == senhaCodificada);
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidarEmail(String email)
        {
            // Verifica se o e-mail digitado é válido:
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static void EnviarSenhaPorEmail(Usuario usuario)
        {
            try
            {
                MailMessage mailMessage = new MailMessage
                {
                    Subject = "Recuperação de senha - Dominus",
                    Body = String.Format(
                        "Olá, " + usuario.Nome + "!" + Environment.NewLine + Environment.NewLine +
                        "Suas credenciais de acesso à plataforma Dominus são:" + Environment.NewLine +
                        " - login: " + usuario.Login + Environment.NewLine +
                        " - senha: " + Codificador.Descriptografar(usuario.Senha)
                        )
                };
                mailMessage.To.Add(usuario.Email);

                SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

                using (SmtpClient client = new SmtpClient(section.Network.Host, section.Network.Port))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(section.Network.UserName, section.Network.Password);
                    client.EnableSsl = section.Network.EnableSsl;
                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
