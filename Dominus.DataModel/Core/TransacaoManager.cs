using System;
using System.Collections.Generic;
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
    }
}
