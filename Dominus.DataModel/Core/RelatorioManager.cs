using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public class RelatorioManager
    {
        private static ConnectionManager connection = new ConnectionManager();

        public static List<Relatorio> GetRelatorios(Usuario usuario)
        {
            try
            {
                // Retorna uma lista dos relatórios do usuário fornecido:
                connection.OpenConnection();
                List<Relatorio> relatorios = connection.context.Relatorios.Where(x => x.IdUsuario == usuario.IdUsuario).ToList();
                connection.CloseConnection();
                return relatorios;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static List<TipoRelatorio> GetTiposRelatorio()
        {
            try
            {
                // Retorna uma lista dos tipos de relatório:
                connection.OpenConnection();
                List<TipoRelatorio> tiposRelatorio = connection.context.TiposRelatorio.OrderBy(x => x.Descricao).ToList();
                connection.CloseConnection();
                return tiposRelatorio;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static Relatorio GetRelatorioById(Guid idRelatorio)
        {
            try
            {
                // Verifica se existe um relatório com o id fornecido:
                connection.OpenConnection();
                Relatorio relatorio = connection.context.Relatorios.FirstOrDefault(x => x.IdRelatorio.Equals(idRelatorio));
                connection.CloseConnection();
                return relatorio;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static TipoRelatorio GetTipoRelatorioById(Guid idTipoRelatorio)
        {
            try
            {
                // Verifica se existe um tipo de relatório com o id fornecido:
                connection.OpenConnection();
                TipoRelatorio tipoRelatorio = connection.context.TiposRelatorio.FirstOrDefault(x => x.IdTipoRelatorio.Equals(idTipoRelatorio));
                connection.CloseConnection();
                return tipoRelatorio;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void AddRelatorio(Relatorio relatorio)
        {
            try
            {
                // A aplicação gera um novo relatório com as definições padrões:
                ValidarDadosRelatorio(relatorio);
                if (relatorio.IdRelatorio == Guid.Empty || GetRelatorioById(relatorio.IdRelatorio) != null)
                {
                    relatorio.IdRelatorio = Guid.NewGuid();
                }
                relatorio.Nome = relatorio.Nome.Trim();
                connection.OpenConnection();
                connection.context.Entry(relatorio).State = EntityState.Added;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void EditRelatorio(Relatorio relatorio)
        {
            try
            {
                // A aplicação atualiza os dados do relatório fornecido:
                Relatorio old = GetRelatorioById(relatorio.IdRelatorio);
                if (old == null)
                    throw new Exception("Relatório não encontrado no sistema.");

                ValidarDadosRelatorio(relatorio);
                old.IdUsuario = relatorio.IdUsuario;
                old.IdTipoRelatorio = relatorio.IdTipoRelatorio;
                old.Nome = relatorio.Nome.Trim();
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

        public static void DeleteRelatorio(Relatorio relatorio)
        {
            try
            {
                // A aplicação remove o relatório fornecido:
                Relatorio old = GetRelatorioById(relatorio.IdRelatorio);
                if (old == null)
                    throw new Exception("Relatório não encontrado no sistema.");

                connection.OpenConnection();
                connection.context.Entry(relatorio).State = EntityState.Deleted;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        private static void ValidarDadosRelatorio(Relatorio relatorio)
        {
            if (UsuarioManager.GetUsuarioById(relatorio.IdUsuario) == null)
                throw new RelatorioUsuarioException("Não foi possível salvar o relatório com o usuário informado.");

            if (GetTipoRelatorioById(relatorio.IdTipoRelatorio) == null)
                throw new RelatorioTipoException("Não foi possível salvar o relatório com o tipo informado.");

            if (String.IsNullOrWhiteSpace(relatorio.Nome) || relatorio.Nome.Trim().Length > 100)
                throw new RelatorioNomeException("O nome deve ser preenchido (até 100 caracteres).");

            if (String.IsNullOrWhiteSpace(relatorio.InfoLinha) || relatorio.InfoLinha.Trim().Length > 100)
                throw new RelatorioInfoLinhaException("A informação de linha deve ser preenchida (até 100 caracteres).");

            if (String.IsNullOrWhiteSpace(relatorio.InfoColuna) || relatorio.InfoColuna.Trim().Length > 100)
                throw new RelatorioInfoColunaException("A informação da coluna deve ser preenchida (até 100 caracteres).");
        }

        public static List<RelatorioUsuario> GetRelatorioUsuario(Usuario usuario, DateTime? dataInicial = null, DateTime? dataFinal = null)
        {
            try
            {
                // Retorna uma lista do relatório das transações do usuário fornecido:
                connection.OpenConnection();
                List<RelatorioTransacoes> relatorio = connection.context.RelatoriosTransacoes.Where(x => x.IdUsuario == usuario.IdUsuario
                && (dataInicial == null || x.Data >= dataInicial)
                && (dataFinal == null || x.Data <= dataFinal)).ToList();
                connection.CloseConnection();

                List<RelatorioUsuario> relatorioUsuario = new List<RelatorioUsuario>();
                foreach (RelatorioTransacoes transacao in relatorio.OrderBy(x => x.Data))
                {
                    relatorioUsuario.Add(new RelatorioUsuario
                    {
                        Tipo = transacao.Tipo,
                        Modo = transacao.Modo,
                        Categoria = transacao.Categoria,
                        Descrição = transacao.Descrição,
                        Dia = transacao.Data.Day,
                        Mês = transacao.Data.ToString(@"MMMM", CultureInfo.GetCultureInfo("pt-BR")),
                        Ano = transacao.Data.Year,
                        Valor = (Decimal)transacao.Valor,
                        Comentário = transacao.Comentário
                    });
                }
                return relatorioUsuario;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }
    }

    public class RelatorioUsuario
    {
        public String Tipo { get; set; }
        public String Modo { get; set; }
        public String Categoria { get; set; }
        public String Descrição { get; set; }
        public int Dia { get; set; }
        public String Mês { get; set; }
        public int Ano { get; set; }
        public Decimal Valor { get; set; }
        public String Comentário { get; set; }
    }

    public class RelatorioUsuarioException : Exception
    {
        public RelatorioUsuarioException() { }

        public RelatorioUsuarioException(string message) : base(message) { }

        public RelatorioUsuarioException(string message, Exception inner) : base(message, inner) { }
    }

    public class RelatorioTipoException : Exception
    {
        public RelatorioTipoException() { }

        public RelatorioTipoException(string message) : base(message) { }

        public RelatorioTipoException(string message, Exception inner) : base(message, inner) { }
    }

    public class RelatorioNomeException : Exception
    {
        public RelatorioNomeException() { }

        public RelatorioNomeException(string message) : base(message) { }

        public RelatorioNomeException(string message, Exception inner) : base(message, inner) { }
    }

    public class RelatorioInfoLinhaException : Exception
    {
        public RelatorioInfoLinhaException() { }

        public RelatorioInfoLinhaException(string message) : base(message) { }

        public RelatorioInfoLinhaException(string message, Exception inner) : base(message, inner) { }
    }

    public class RelatorioInfoColunaException : Exception
    {
        public RelatorioInfoColunaException() { }

        public RelatorioInfoColunaException(string message) : base(message) { }

        public RelatorioInfoColunaException(string message, Exception inner) : base(message, inner) { }
    }
}
