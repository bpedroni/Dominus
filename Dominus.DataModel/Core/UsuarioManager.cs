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
        private static ConnectionManager connection = new ConnectionManager();

        public const int PERFIL_ADMINISTRADOR = 1;
        public const int PERFIL_USUARIO = 0;

        public static List<Usuario> GetUsuarios()
        {
            try
            {
                // Retorna uma lista de usuários cadastrados sistema:
                connection.OpenConnection();
                List<Usuario> usuarios = connection.context.Usuarios.ToList();
                connection.CloseConnection();
                return usuarios;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
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
                // A aplicação gera um novo usuário com as definições padrões:
                ValidarDadosUsuario(usuario);
                usuario.IdUsuario = Guid.NewGuid();
                usuario.Nome = usuario.Nome.Trim();
                usuario.Login = usuario.Login.Trim();
                usuario.Email = usuario.Email.Trim();
                usuario.DataCriacao = DateTime.Now;
                usuario.PerfilAdministrador = PERFIL_USUARIO;
                usuario.Ativo = ConnectionManager.STATUS_ATIVO;

                connection.OpenConnection();
                connection.context.Entry(usuario).State = EntityState.Added;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void EditUsuario(Usuario usuario)
        {
            try
            {
                // A aplicação atualiza os dados do usuário fornecido:
                Usuario old = GetUsuarioById(usuario.IdUsuario);
                if (old == null)
                    throw new Exception("Usuário não encontrado no sistema.");

                ValidarDadosUsuario(usuario, old);
                old.Nome = usuario.Nome.Trim();
                old.Login = usuario.Login.Trim();
                old.Senha = usuario.Senha;

                connection.OpenConnection();
                connection.context.Entry(old).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void DeleteUsuario(Usuario usuario)
        {
            try
            {
                // A aplicação remove o usuário fornecido alterando o seu status para inativo:
                Usuario old = GetUsuarioById(usuario.IdUsuario);
                if (old == null)
                    throw new Exception("Usuário não encontrado no sistema.");

                old.Ativo = ConnectionManager.STATUS_INATIVO;

                connection.OpenConnection();
                connection.context.Entry(old).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void EditPerfilUsuario(List<Usuario> usuarios)
        {
            try
            {
                // A aplicação atualiza apenas o PerfilAdministrador do usuário fornecido:
                connection.OpenConnection();
                foreach (Usuario usuario in usuarios)
                {
                    connection.context.Entry(usuario).State = EntityState.Modified;
                }
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        private static void ValidarDadosUsuario(Usuario usuario, Usuario old = null)
        {
            if (String.IsNullOrWhiteSpace(usuario.Nome) || usuario.Nome.Trim().Length > 100)
                throw new UsuarioNomeException("O nome deve ser preenchido (até 100 caracteres).");

            if (String.IsNullOrWhiteSpace(usuario.Login) || usuario.Login.Trim().Length < 4 || usuario.Login.Trim().Length > 15)
                throw new UsuarioLoginException("O login deve ser preenchido (de 4 até 15 caracteres).");

            if (!System.Text.RegularExpressions.Regex.IsMatch(usuario.Login.Trim(), @"^[a-zA-Z0-9_]+$"))
                throw new UsuarioLoginException("O login deve conter apenas letras, números ou '_'(sublinhado).");

            if ((old == null || !usuario.Login.Trim().Equals(old.Login)) && GetUsuarioByLogin(usuario.Login.Trim()) != null)
                throw new UsuarioLoginException("O sistema já possui um usuário com o login '" + usuario.Login.Trim() + "'. Escolha um outro nome.");

            if (String.IsNullOrWhiteSpace(usuario.Email) || usuario.Email.Trim().Length > 100 || !ValidarEmail(usuario.Email))
                throw new UsuarioEmailException("O e-mail deve ser preenchido com um endereço válido (até 100 caracteres).");

            if ((old == null || !usuario.Email.Trim().Equals(old.Email)) && GetUsuarioByEmail(usuario.Email.Trim()) != null)
                throw new UsuarioEmailException("O sistema já possui um usuário com o e-mail '" + usuario.Email.Trim() + "'.");

            if (String.IsNullOrWhiteSpace(Codificador.Descriptografar(usuario.Senha)) || Codificador.Descriptografar(usuario.Senha).Length < 8 || Codificador.Descriptografar(usuario.Senha).Length > 20)
                throw new UsuarioSenhaException("A senha deve ser preenchida e deve atender à política de segurança.");
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

        public static bool ValidarSenha(String senha)
        {
            bool senhaValida = senha.Length >= 8
                && senha.Length <= 20
                && senha.Any(char.IsUpper)
                && senha.Any(char.IsLower)
                && senha.Any(char.IsDigit);

            return senhaValida;
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
                    client.UseDefaultCredentials = section.Network.DefaultCredentials;
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

    public class UsuarioNomeException : Exception
    {
        public UsuarioNomeException() { }

        public UsuarioNomeException(string message) : base(message) { }

        public UsuarioNomeException(string message, Exception inner) : base(message, inner) { }
    }

    public class UsuarioLoginException : Exception
    {
        public UsuarioLoginException() { }

        public UsuarioLoginException(string message) : base(message) { }

        public UsuarioLoginException(string message, Exception inner) : base(message, inner) { }
    }

    public class UsuarioEmailException : Exception
    {
        public UsuarioEmailException() { }

        public UsuarioEmailException(string message) : base(message) { }

        public UsuarioEmailException(string message, Exception inner) : base(message, inner) { }
    }

    public class UsuarioSenhaException : Exception
    {
        public UsuarioSenhaException() { }

        public UsuarioSenhaException(string message) : base(message) { }

        public UsuarioSenhaException(string message, Exception inner) : base(message, inner) { }
    }
}
