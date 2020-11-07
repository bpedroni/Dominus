using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public class TransacaoManager
    {
        private static ConnectionManager connection = new ConnectionManager();

        public static List<Transacao> GetTransacoes(Usuario usuario, int? mes = null, int? ano = null)
        {
            try
            {
                // Retorna uma lista de transações do usuário fornecido:
                connection.OpenConnection();
                List<Transacao> transacoes = connection.context.Transacoes
                    .Where(x => x.IdUsuario == usuario.IdUsuario
                    && x.Data != null
                    && (mes == null || x.Data.Value.Month == mes)
                    && (ano == null || x.Data.Value.Year == ano)).ToList();
                connection.CloseConnection();
                return transacoes;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static List<Transacao> GetProvisoes(Usuario usuario, int? mes = null, int? ano = null)
        {
            try
            {
                // Retorna uma lista de provisões do usuário fornecido:
                connection.OpenConnection();
                List<Transacao> transacoes = connection.context.Transacoes
                    .Where(x => x.IdUsuario == usuario.IdUsuario
                    && x.DataProvisao != null
                    && (mes == null || x.DataProvisao.Value.Month == mes)
                    && (ano == null || x.DataProvisao.Value.Year == ano)).ToList();
                connection.CloseConnection();
                return transacoes;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static Transacao GetTransacaoById(Usuario usuario, Guid idTransacao)
        {
            try
            {
                // Verifica se existe uma categoria com o id fornecido:
                Transacao transacao = GetTransacoes(usuario).FirstOrDefault(x => x.IdTransacao.Equals(idTransacao));
                if (transacao == null)
                    transacao = GetProvisoes(usuario).FirstOrDefault(x => x.IdTransacao.Equals(idTransacao));

                return transacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddTransacao(Transacao transacao)
        {
            try
            {
                // A aplicação gera uma nova transação com as definições padrões:
                transacao.IdTransacao = Guid.NewGuid();
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
                connection.OpenConnection();
                connection.context.Entry(transacao).State = EntityState.Modified;
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

        public static List<Transacao> GetReceitas(Usuario usuario, int? mes = null, int? ano = null)
        {
            try
            {
                // Retorna uma lista de transações de receita do usuário fornecido:
                return GetTransacoes(usuario, mes, ano).Where(x => x.TipoFluxo == CategoriaManager.TIPO_FLUXO_RECEITA).ToList();
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
                return GetTransacoes(usuario, mes, ano).Where(x => x.TipoFluxo == CategoriaManager.TIPO_FLUXO_DESPESA).ToList();
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

                foreach (Transacao transacao in GetTransacoes(usuario, mes, ano))
                {
                    Categoria categoria = CategoriaManager.GetCategoriaById(transacao.IdCategoria);

                    gridTransacoes.Add(new GridRowTransacao
                    {
                        IdTransacao = transacao.IdTransacao,
                        Identificacao = transacao.Identificacao,
                        IdCategoria = transacao.IdCategoria,
                        Categoria = categoria.Nome,
                        IconeCategoria = "Images/Categorias/" + categoria.Icone,
                        Modo = "Transação",
                        TipoFluxo = transacao.TipoFluxo,
                        Descricao = transacao.Descricao,
                        Data = (DateTime)transacao.Data,
                        Valor = (Decimal)transacao.Valor,
                        Provisionado =transacao.Provisionado,
                        Comentario = transacao.Comentario
                    });
                }
                foreach (Transacao provisao in GetProvisoes(usuario, mes, ano))
                {
                    Categoria categoria = CategoriaManager.GetCategoriaById(provisao.IdCategoria);

                    gridTransacoes.Add(new GridRowTransacao
                    {
                        IdTransacao = provisao.IdTransacao,
                        Identificacao = provisao.Identificacao,
                        IdCategoria = provisao.IdCategoria,
                        Categoria = categoria.Nome,
                        IconeCategoria = "Images/Categorias/" + categoria.Icone,
                        Modo = "Provisão",
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
        public String IconeCategoria { get; set; }
        public String Modo { get; set; }
        public String TipoFluxo { get; set; }
        public String Descricao { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public int Provisionado { get; set; }
        public String Comentario { get; set; }
    }
}
