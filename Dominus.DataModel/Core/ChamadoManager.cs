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
        public const String STATUS_FINALIZADO = "Chamado Finalizado";
        public const String STATUS_RESPONDIDO = "Chamado Respondido";
        public const String STATUS_SEM_RESPOSTA = "Chamado Sem Resposta";

        public static List<Chamado> GetChamados(Usuario usuario = null)
        {
            try
            {
                // Retorna uma lista de chamados cadastrados sistema:
                connection.OpenConnection();
                List<Chamado> chamados = connection.context.Chamados.OrderBy(x => x.DataCriacao).ToList();
                if (usuario != null)
                {
                    chamados = chamados.Where(x => x.IdUsuario.Equals(usuario.IdUsuario)).ToList();
                }
                connection.CloseConnection();
                return chamados;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static List<Chamado> GetChamadosAbertos(Usuario usuario = null)
        {
            try
            {
                // Retorna uma lista de chamados que estão abertos no sistema:
                return GetChamados(usuario).Where(x => x.Validado == CHAMADO_NAO_VALIDADO).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Chamado> GetChamadosAbertosRespondidos(Usuario usuario)
        {
            // Retorna uma lista de chamados respondidos e não validados do usuário fornecido:
            return GetChamadosAbertos(usuario).Where(x => x.IdUsuarioSuporte != null).ToList();
        }

        public static List<Chamado> GetChamadosPrimarios(Usuario usuario)
        {
            // Retorna uma lista de chamados criados sem associação com algum outro chamado:
            return GetChamados(usuario).Where(x => x.IdChamadoAssociado == null).ToList();
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

        public static Chamado GetChamadoAssociado(Chamado chamado)
        {
            // Retorna o chamado criado a partir do chamado fornecido (ou nulo, caso não exista):
            return GetChamados().FirstOrDefault(x => x.IdChamadoAssociado == chamado.IdChamado);
        }

        public static String GetStatusChamado(Chamado chamado)
        {
            // Retorna o status do chamado fornecido:
            Chamado chamadoAssociado = GetChamadoAssociado(chamado);
            if (chamadoAssociado != null)
            {
                return GetStatusChamado(chamadoAssociado);
            }
            if (chamado.Validado == CHAMADO_VALIDADO)
            {
                return STATUS_FINALIZADO;
            }
            if (chamado.IdUsuarioSuporte != null)
            {
                return STATUS_RESPONDIDO;
            }
            return STATUS_SEM_RESPOSTA;
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
                // A aplicação gera um novo chamado com as definições padrões:
                ValidarDadosChamado(chamado);
                Usuario usuario = GetUsuario(chamado);
                chamado.IdChamado = Guid.NewGuid();
                chamado.Titulo = chamado.Titulo.Trim();
                chamado.Mensagem = chamado.Mensagem.Trim();
                chamado.DataCriacao = DateTime.Now;
                chamado.Validado = CHAMADO_NAO_VALIDADO;
                chamado.MensagemResposta = "Olá, " + usuario.Nome + "!";
                connection.OpenConnection();
                connection.context.Entry(chamado).State = EntityState.Added;
                connection.context.SaveChanges();
                connection.CloseConnection();
                // Atualiza o chamado associado, caso exista:
                if (Guid.TryParse(chamado.IdChamadoAssociado.ToString(), out Guid guid))
                {
                    Chamado chamadoAssociado = GetChamadoById(guid);
                    FinalizaChamado(chamadoAssociado);
                }
                // Envia a mensagem de contato para a conta de e-mail do administrador do sistema:
                EnviarMensagemContato(usuario.Nome, usuario.Email, chamado.Titulo, chamado.Mensagem);
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void EditRespostaChamado(Chamado chamado)
        {
            try
            {
                // A aplicação atualiza a resposta do chamado fornecido:
                Chamado old = GetChamadoById(chamado.IdChamado);
                if (old == null)
                    throw new Exception("Chamado não encontrado no sistema.");

                ValidarDadosChamado(chamado);
                old.IdUsuarioSuporte = chamado.IdUsuarioSuporte;
                if (old.IdUsuarioSuporte != null)
                {
                    old.MensagemResposta = chamado.MensagemResposta;
                    old.DataResposta = DateTime.Now;
                }
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

        public static void FinalizaChamado(Chamado chamado)
        {
            try
            {
                // A aplicação atualiza a resposta do chamado fornecido:
                Chamado old = GetChamadoById(chamado.IdChamado);
                if (old == null)
                    throw new Exception("Chamado não encontrado no sistema.");

                old.Validado = CHAMADO_VALIDADO;
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

        public static void DeleteChamado(Chamado chamado)
        {
            try
            {
                // A aplicação remove o chamado fornecido:
                Chamado old = GetChamadoById(chamado.IdChamado);
                if (old == null)
                    throw new Exception("Chamado não encontrado no sistema.");

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

        public static void ValidarDadosChamado(Chamado chamado)
        {
            if (UsuarioManager.GetUsuarioById(chamado.IdUsuario) == null)
                throw new ChamadoUsuarioException("Não foi possível salvar o chamado com o usuário informado.");

            if (String.IsNullOrWhiteSpace(chamado.Titulo) || chamado.Titulo.Trim().Length > 50)
                throw new ChamadoTituloException("O título deve ser preenchido (até 50 caracteres).");

            if (String.IsNullOrWhiteSpace(chamado.Mensagem) || chamado.Mensagem.Trim().Length > 1000)
                throw new ChamadoMensagemException("A mensagem deve ser preenchida (até 1000 caracteres).");

            if (chamado.IdUsuarioSuporte != null && UsuarioManager.GetUsuarioById((Guid)chamado.IdUsuarioSuporte) == null)
                throw new ChamadoUsuarioException("Não foi possível salvar o chamado com o usuário de suporte informado.");

            if (chamado.IdUsuarioSuporte != null && (String.IsNullOrWhiteSpace(chamado.MensagemResposta) || chamado.MensagemResposta.Trim().Length > 1000))
                throw new ChamadoMensagemException("A resposta deve ser preenchida (até 1000 caracteres).");
        }

        public static void EnviarMensagemContato(String nome, String email, String titulo, String mensagem)
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
                    "Título da mensagem: " + titulo + Environment.NewLine +
                    "Mensagem enviada: " + Environment.NewLine + mensagem + Environment.NewLine +
                    "****************************************************************************************************"
                );
                EnviarEmail(section.Network.UserName, "Novo Contato DOMINUS: " + titulo, msg);

                // Envio de confirmacao do contato ao e-mail fornecido pelo usuário:
                msg = String.Format(
                     "Olá, " + nome + "!" + Environment.NewLine + Environment.NewLine +
                    "A equipe Dominus regitrou o seu contato e o retornaremos assim que possível." + Environment.NewLine + Environment.NewLine +
                    "****************************************************************************************************" + Environment.NewLine +
                    "Título da mensagem: " + titulo + Environment.NewLine +
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

    public class ChamadoUsuarioException : Exception
    {
        public ChamadoUsuarioException() { }

        public ChamadoUsuarioException(string message) : base(message) { }

        public ChamadoUsuarioException(string message, Exception inner) : base(message, inner) { }
    }

    public class ChamadoTituloException : Exception
    {
        public ChamadoTituloException() { }

        public ChamadoTituloException(string message) : base(message) { }

        public ChamadoTituloException(string message, Exception inner) : base(message, inner) { }
    }

    public class ChamadoMensagemException : Exception
    {
        public ChamadoMensagemException() { }

        public ChamadoMensagemException(string message) : base(message) { }

        public ChamadoMensagemException(string message, Exception inner) : base(message, inner) { }
    }
}
