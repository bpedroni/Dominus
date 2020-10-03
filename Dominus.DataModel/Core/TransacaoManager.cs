using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public class TransacaoManager
    {
        public static List<Transacao> GetTransacoes(Usuario usuario, int? mes = null)
        {
            try
            {
                // Retorna uma lista de transações do usuário fornecido:
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                List<Transacao> transacoes = connection.context.Transacoes
                    .Where(x => x.IdUsuario == usuario.IdUsuario
                    && x.Data != null
                    && (mes == null || x.Data.Value.Month == mes)).ToList();
                connection.CloseConnection();
                return transacoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Transacao> GetProvisoes(Usuario usuario, int? mes = null)
        {
            try
            {
                // Retorna uma lista de provisões do usuário fornecido:
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                List<Transacao> transacoes = connection.context.Transacoes
                    .Where(x => x.IdUsuario == usuario.IdUsuario
                    && x.DataProvisao != null
                    && (mes == null || x.DataProvisao.Value.Month == mes)).ToList();
                connection.CloseConnection();
                return transacoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Transacao> GetReceitas(Usuario usuario, int? mes = null)
        {
            try
            {
                // Retorna uma lista de transações de receita do usuário fornecido:
                return GetTransacoes(usuario, mes).Where(x => x.TipoFluxo == CategoriaManager.TIPO_FLUXO_RECEITA).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Transacao> GetDespesas(Usuario usuario, int? mes = null)
        {
            try
            {
                // Retorna uma lista de transações de despesa do usuário fornecido:
                return GetTransacoes(usuario, mes).Where(x => x.TipoFluxo == CategoriaManager.TIPO_FLUXO_DESPESA).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal GetSaldo(Usuario usuario, int? mes = null)
        {
            decimal? saldo = 0;
            if (usuario != null)
            {
                List<Transacao> receitas = GetReceitas(usuario, mes);
                List<Transacao> despesas = GetDespesas(usuario, mes);

                saldo = receitas.Sum(x => x.Valor) - despesas.Sum(x => x.Valor);
            }
            return (decimal)saldo;
        }
    }
}
