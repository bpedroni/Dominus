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
    public class ChamadoManager
    {
        private static ConnectionManager connection = new ConnectionManager();

        public const int CHAMADO_VALIDADO = 1;
        public const int CHAMADO_NAO_VALIDADO = 0;

        public static List<Chamado> GetChamados()
        {
            try
            {
                // Retorna uma lista de chamados cadastrados sistema:
                connection.OpenConnection();
                // Aqui são excluídos os chamados que estão associados a um novo chamado:
                List<Chamado> chamados = connection.context.Chamados.ToList();
                connection.CloseConnection();
                return chamados;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static List<Chamado> GetChamadosAbertos()
        {
            try
            {
                // Retorna uma lista de chamados que estão abertos no sistema:
                return GetChamados().Where(x => x.Validado == CHAMADO_NAO_VALIDADO).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Chamado GetChamadoById(Guid idChamado)
        {
            try
            {
                // Verifica se existe um usuário com o id fornecido:
                Chamado chamado = GetChamados().FirstOrDefault(x => x.IdChamado == idChamado);
                return chamado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Usuario GetUsuario(Chamado chamado)
        {
            Usuario usuario = UsuarioManager.GetUsuarioById(chamado.IdUsuario);
            return usuario;
        }

        public static Usuario GetUsuarioSuporte(Chamado chamado)
        {
            Usuario usuario = null;
            if (chamado.IdUsuarioSuporte != null)
            {
                usuario = UsuarioManager.GetUsuarioById((Guid)chamado.IdUsuarioSuporte);
            }
            return usuario;
        }

        public static void AddChamado(Chamado chamado)
        {
            try
            {
                if (GetChamadoById(chamado.IdChamado) != null)
                {
                    throw new Exception("O sistema já possui um chamado com o id informado.");
                }
                // A aplicação gera um novo chamado com as definições padrões:
                chamado.IdChamado = Guid.NewGuid();
                chamado.DataCriacao = DateTime.Now;
                chamado.Validado = CHAMADO_NAO_VALIDADO;
                connection.OpenConnection();
                connection.context.Entry(chamado).State = EntityState.Added;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void EditChamado(Chamado chamado)
        {
            try
            {
                // A aplicação atualiza os dados do chamado fornecido:
                connection.OpenConnection();
                connection.context.Entry(chamado).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void DeleteChamado(Chamado chamado)
        {
            try
            {
                // A aplicação remove o chamado fornecido:
                connection.OpenConnection();
                connection.context.Entry(chamado).State = EntityState.Deleted;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void EnviarMensagemContato(String nome, String email, String assunto, String mensagem)
        {
            try
            {
                // Envio da mensagem do usuário ao e-mail do administrador do sistema:
                SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                String msg = String.Format(
                    "A aplicação registrou um novo contato!" + Environment.NewLine + Environment.NewLine +
                    "****************************************************************************************************" + Environment.NewLine +
                    "Nome do usuário: " + nome + Environment.NewLine +
                    "E-mail de contato: " + email + Environment.NewLine +
                    "Título da mensagem: " + assunto + Environment.NewLine +
                    "Mensagem enviada: " + Environment.NewLine + mensagem + Environment.NewLine +
                    "****************************************************************************************************"
                );
                EnviarEmail(section.Network.UserName, "Novo Contato DOMINUS: " + assunto, msg);

                // Envio de confirmacao do contato ao e-mail fornecido pelo usuário:
                msg = String.Format(
                     "Olá, " + nome + "!" + Environment.NewLine + Environment.NewLine +
                    "A equipe Dominus regitrou o seu contato e o retornaremos assim que possível." + Environment.NewLine + Environment.NewLine +
                    "****************************************************************************************************" + Environment.NewLine +
                    "Título da mensagem: " + assunto + Environment.NewLine +
                    "Mensagem enviada: " + Environment.NewLine + mensagem + Environment.NewLine +
                    "****************************************************************************************************" + Environment.NewLine + Environment.NewLine +
                    "Este é um envio automático de e-mail. Não é necessário respondê-lo"
                 );
                EnviarEmail(email, "Recebemos sua mensagem!", msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EnviarEmail(String email, String titulo, String mensagem)
        {
            try
            {
                MailMessage mailMessage = new MailMessage
                {
                    Subject = titulo,
                    Body = mensagem
                };
                mailMessage.To.Add(email);

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
