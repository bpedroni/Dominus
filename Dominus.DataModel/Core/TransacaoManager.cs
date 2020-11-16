using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public class TransacaoManager
    {
        private static ConnectionManager connection = new ConnectionManager();

        public const String MODO_TRANSACAO = "Transação";
        public const String MODO_PROVISAO = "Provisão";
        public const int TRANSACAO_EFETUADA = 0;
        public const int TRANSACAO_PROVISIONADA = 1;

        public static List<Transacao> GetTransacoes(Usuario usuario, int? mes = null, int? ano = null)
        {
            try
            {
                // Retorna uma lista de transações e provisões do usuário fornecido:
                connection.OpenConnection();
                List<Transacao> transacoes = connection.context.Transacoes.Where(x => x.IdUsuario == usuario.IdUsuario
                && ((x.Data != null && (mes == null || x.Data.Value.Month == mes) && (ano == null || x.Data.Value.Year == ano))
                || (x.DataProvisao != null && (mes == null || x.DataProvisao.Value.Month == mes) && (ano == null || x.DataProvisao.Value.Year == ano)))).ToList();
                connection.CloseConnection();
                return transacoes;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static List<Transacao> GetTransacoesEfetuadas(Usuario usuario, int? mes = null, int? ano = null)
        {
            try
            {
                // Retorna uma lista de transações do usuário fornecido:
                return GetTransacoes(usuario, mes, ano).Where(x => x.Provisionado == TRANSACAO_EFETUADA).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Transacao> GetTransacoesProvisionadas(Usuario usuario, int? mes = null, int? ano = null)
        {
            try
            {
                // Retorna uma lista de provisões do usuário fornecido:
                return GetTransacoes(usuario, mes, ano).Where(x => x.Provisionado == TRANSACAO_PROVISIONADA).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Transacao GetTransacaoById(Guid idTransacao)
        {
            try
            {
                // Verifica se existe uma transação com o usuário e o id fornecidos:
                connection.OpenConnection();
                Transacao transacao = connection.context.Transacoes.FirstOrDefault(x => x.IdTransacao.Equals(idTransacao));
                connection.CloseConnection();
                return transacao;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void AddTransacao(Transacao transacao)
        {
            try
            {
                // A aplicação gera uma nova transação com as definições padrões:
                ValidarDadosTransacao(transacao);
                transacao.IdTransacao = Guid.NewGuid();
                transacao.Descricao = transacao.Descricao.Trim();
                transacao.Comentario = transacao.Comentario.Trim();
                connection.OpenConnection();
                connection.context.Entry(transacao).State = EntityState.Added;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void EditTransacao(Transacao transacao)
        {
            try
            {
                // A aplicação atualiza os dados da transação fornecida:
                Transacao old = GetTransacaoById(transacao.IdTransacao);
                if (old == null)
                    throw new Exception("Transação não encontrada no sistema.");

                ValidarDadosTransacao(transacao);
                old.IdUsuario = transacao.IdUsuario;
                old.IdCategoria = transacao.IdCategoria;
                old.Descricao = transacao.Descricao.Trim();
                old.Comentario = transacao.Comentario.Trim();
                if (String.IsNullOrWhiteSpace(old.Identificacao))
                {
                    old.Provisionado = transacao.Provisionado;
                    if (old.Provisionado.Equals(TRANSACAO_PROVISIONADA))
                    {
                        old.ValorProvisao = transacao.ValorProvisao;
                        old.DataProvisao = transacao.DataProvisao;
                    }
                    else
                    {
                        old.Valor = transacao.Valor;
                        old.Data = transacao.Data;
                    }
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

        public static void DeleteTransacao(Transacao transacao)
        {
            try
            {
                // A aplicação remove a transação fornecida:
                Transacao old = GetTransacaoById(transacao.IdTransacao);
                if (old == null)
                    throw new Exception("Transação não encontrada no sistema.");

                connection.OpenConnection();
                connection.context.Entry(transacao).State = EntityState.Deleted;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        private static void ValidarDadosTransacao(Transacao transacao)
        {
            if (UsuarioManager.GetUsuarioById(transacao.IdUsuario) == null)
                throw new TransacaoUsuarioException("Não foi possível salvar a transação com o usuário informado.");

            if (CategoriaManager.GetCategoriaById(transacao.IdCategoria) == null)
                throw new TransacaoUsuarioException("Não foi possível salvar a transação com a categoria informada.");

            if (String.IsNullOrWhiteSpace(transacao.Descricao) || transacao.Descricao.Trim().Length > 100)
                throw new TransacaoDescricaoException("A descrição deve ser preenchida (até 100 caracteres).");

            if (transacao.Provisionado == TRANSACAO_PROVISIONADA)
            {
                if (transacao.ValorProvisao == null)
                    throw new TransacaoValorException("A valor deve ser preenchido com um número decimal.");

                if (transacao.DataProvisao == null)
                    throw new TransacaoDataException("A data deve ser preenchida com uma data válida.");
            }
            else
            {
                if (transacao.Valor == null)
                    throw new TransacaoValorException("A valor deve ser preenchido com um número decimal.");

                if (transacao.Data == null)
                    throw new TransacaoDataException("A data deve ser preenchida com uma data válida.");
            }
            if (!transacao.TipoFluxo.Equals(CategoriaManager.TIPO_FLUXO_RECEITA) && !transacao.TipoFluxo.Equals(CategoriaManager.TIPO_FLUXO_DESPESA))
                throw new TransacaoTipoFluxoException("O tipo de fluxo deve ser 'Receita' ou 'Despesa'.");

            if (transacao.Comentario.Trim().Length > 255)
                throw new TransacaoDescricaoException("O comentário pode ter no máximo 255 caracteres).");

        }

        public static List<Transacao> GetReceitas(Usuario usuario, int? mes = null, int? ano = null)
        {
            try
            {
                // Retorna uma lista de transações de receita do usuário fornecido:
                return GetTransacoesEfetuadas(usuario, mes, ano).Where(x => x.TipoFluxo == CategoriaManager.TIPO_FLUXO_RECEITA).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Transacao> GetDespesas(Usuario usuario, int? mes = null, int? ano = null)
        {
            try
            {
                // Retorna uma lista de transações de despesa do usuário fornecido:
                return GetTransacoesEfetuadas(usuario, mes, ano).Where(x => x.TipoFluxo == CategoriaManager.TIPO_FLUXO_DESPESA).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal GetSaldo(Usuario usuario, int? mes = null, int? ano = null)
        {
            decimal? saldo = 0;
            if (usuario != null)
            {
                List<Transacao> receitas = GetReceitas(usuario, mes, ano);
                List<Transacao> despesas = GetDespesas(usuario, mes, ano);

                saldo = receitas.Sum(x => x.Valor) - despesas.Sum(x => x.Valor);
            }
            return (decimal)saldo;
        }

        public static List<GridRowTransacao> GetGridTransacoes(Usuario usuario, int? mes = null, int? ano = null)
        {
            try
            {
                List<GridRowTransacao> gridTransacoes = new List<GridRowTransacao>();

                foreach (Transacao transacao in GetTransacoesEfetuadas(usuario, mes, ano))
                {
                    Categoria categoria = CategoriaManager.GetCategoriaById(transacao.IdCategoria);

                    gridTransacoes.Add(new GridRowTransacao
                    {
                        IdTransacao = transacao.IdTransacao,
                        Identificacao = transacao.Identificacao,
                        IdCategoria = transacao.IdCategoria,
                        Categoria = categoria.Nome,
                        DescricaoCategoria = categoria.Descricao,
                        IconeCategoria = "Images/Categorias/" + categoria.Icone,
                        Modo = MODO_TRANSACAO,
                        TipoFluxo = transacao.TipoFluxo,
                        Descricao = transacao.Descricao,
                        Data = (DateTime)transacao.Data,
                        Valor = (Decimal)transacao.Valor,
                        Provisionado = transacao.Provisionado,
                        Comentario = transacao.Comentario
                    });
                }
                foreach (Transacao provisao in GetTransacoesProvisionadas(usuario, mes, ano))
                {
                    Categoria categoria = CategoriaManager.GetCategoriaById(provisao.IdCategoria);

                    gridTransacoes.Add(new GridRowTransacao
                    {
                        IdTransacao = provisao.IdTransacao,
                        Identificacao = provisao.Identificacao,
                        IdCategoria = provisao.IdCategoria,
                        Categoria = categoria.Nome,
                        DescricaoCategoria = categoria.Descricao,
                        IconeCategoria = "Images/Categorias/" + categoria.Icone,
                        Modo = MODO_PROVISAO,
                        TipoFluxo = provisao.TipoFluxo,
                        Descricao = provisao.Descricao,
                        Data = (DateTime)provisao.DataProvisao,
                        Valor = (Decimal)provisao.ValorProvisao,
                        Provisionado = provisao.Provisionado,
                        Comentario = provisao.Comentario
                    });
                }

                // Retorna uma lista de transações de despesa do usuário fornecido:
                return gridTransacoes.OrderByDescending(x => x.Data).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class GridRowTransacao
    {
        public Guid IdTransacao { get; set; }
        public String Identificacao { get; set; }
        public Guid IdCategoria { get; set; }
        public String Categoria { get; set; }
        public String DescricaoCategoria { get; set; }
        public String IconeCategoria { get; set; }
        public String Modo { get; set; }
        public String TipoFluxo { get; set; }
        public String Descricao { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public int Provisionado { get; set; }
        public String Comentario { get; set; }
    }

    public class TransacaoUsuarioException : Exception
    {
        public TransacaoUsuarioException() { }

        public TransacaoUsuarioException(string message) : base(message) { }

        public TransacaoUsuarioException(string message, Exception inner) : base(message, inner) { }
    }

    public class TransacaoCategoriaException : Exception
    {
        public TransacaoCategoriaException() { }

        public TransacaoCategoriaException(string message) : base(message) { }

        public TransacaoCategoriaException(string message, Exception inner) : base(message, inner) { }
    }

    public class TransacaoDescricaoException : Exception
    {
        public TransacaoDescricaoException() { }

        public TransacaoDescricaoException(string message) : base(message) { }

        public TransacaoDescricaoException(string message, Exception inner) : base(message, inner) { }
    }

    public class TransacaoValorException : Exception
    {
        public TransacaoValorException() { }

        public TransacaoValorException(string message) : base(message) { }

        public TransacaoValorException(string message, Exception inner) : base(message, inner) { }
    }

    public class TransacaoDataException : Exception
    {
        public TransacaoDataException() { }

        public TransacaoDataException(string message) : base(message) { }

        public TransacaoDataException(string message, Exception inner) : base(message, inner) { }
    }

    public class TransacaoTipoFluxoException : Exception
    {
        public TransacaoTipoFluxoException() { }

        public TransacaoTipoFluxoException(string message) : base(message) { }

        public TransacaoTipoFluxoException(string message, Exception inner) : base(message, inner) { }
    }

    public class TransacaoComentarioException : Exception
    {
        public TransacaoComentarioException() { }

        public TransacaoComentarioException(string message) : base(message) { }

        public TransacaoComentarioException(string message, Exception inner) : base(message, inner) { }
    }
}
