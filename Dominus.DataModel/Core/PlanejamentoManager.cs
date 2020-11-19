using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dominus.DataModel.Core
{
    class PlanejamentoManager
    {
        private static ConnectionManager connection = new ConnectionManager();

        public static List<Planejamento> GetPlanejamentos(Usuario usuario, Categoria categoria = null, int? mes = null, int? ano = null)
        {
            try
            {
                // Retorna uma lista de planejamentos do usuário fornecido:
                connection.OpenConnection();
                List<Planejamento> planejamentos = connection.context.Planejamentos.Where(x => x.IdUsuario == usuario.IdUsuario
                && (categoria == null || x.IdCategoria == categoria.IdCategoria)
                && (mes == null || x.Mes == mes)
                && (ano == null || x.Ano == ano)).ToList();
                connection.CloseConnection();
                return planejamentos;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static Planejamento GetPlanejamentoById(Guid idPlanejamento)
        {
            try
            {
                // Verifica se existe um planejamento com o id fornecido:
                connection.OpenConnection();
                Planejamento planejamento = connection.context.Planejamentos.FirstOrDefault(x => x.IdPlanejamento.Equals(idPlanejamento));
                connection.CloseConnection();
                return planejamento;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static Planejamento GetPlanejamentoCategoriaByMesEAno(Usuario usuario, Categoria categoria, int mes, int ano)
        {
            try
            {
                // Verifica se existe um planejamento do usuário para a categoria, o mês e o ano fornecidos:
                connection.OpenConnection();
                Planejamento planejamento = connection.context.Planejamentos.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario && x.IdCategoria == categoria.IdCategoria && x.Mes == mes && x.Ano == ano);
                connection.CloseConnection();
                return planejamento;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void AddPlanejamento(Planejamento planejamento)
        {
            try
            {
                // A aplicação gera um novo planejamento com as definições padrões:
                ValidarDadosPlanejamento(planejamento);
                if (planejamento.IdPlanejamento == Guid.Empty)
                {
                    planejamento.IdPlanejamento = Guid.NewGuid();
                }
                planejamento.DataAtualizacao = DateTime.UtcNow.AddHours(-3);
                connection.OpenConnection();
                connection.context.Entry(planejamento).State = EntityState.Added;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void EditPlanejamento(Planejamento planejamento)
        {
            try
            {
                // A aplicação atualiza os dados do planejamento fornecido:
                Planejamento old = GetPlanejamentoById(planejamento.IdPlanejamento);
                if (old == null)
                    throw new Exception("Planejamento não encontrado no sistema.");

                ValidarDadosPlanejamento(planejamento);
                planejamento.DataAtualizacao = DateTime.UtcNow.AddHours(-3);
                connection.OpenConnection();
                connection.context.Entry(planejamento).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void DeletePlanejamento(Planejamento planejamento)
        {
            try
            {
                // A aplicação remove o planejamento fornecido:
                Planejamento old = GetPlanejamentoById(planejamento.IdPlanejamento);
                if (old == null)
                    throw new Exception("Planejamento não encontrado no sistema.");

                connection.OpenConnection();
                connection.context.Entry(planejamento).State = EntityState.Deleted;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        private static void ValidarDadosPlanejamento(Planejamento planejamento)
        {
            if (UsuarioManager.GetUsuarioById(planejamento.IdUsuario) == null)
                throw new PlanejamentoUsuarioException("Não foi possível salvar o planejamento com o usuário informado.");

            if (CategoriaManager.GetCategoriaById(planejamento.IdCategoria) == null)
                throw new PlanejamentoCategoriaException("Não foi possível salvar o planejamento com a categoria informada.");

            if (planejamento.Mes < 1 || planejamento.Mes > 12)
                throw new PlanejamentoMesException("O mês fornecido não é válido.");

            if (planejamento.Valor <= 0)
                throw new PlanejamentoValorException("O valor deve ser preenchido com um número decimal positivo.");
        }
    }

    public class PlanejamentoUsuarioException : Exception
    {
        public PlanejamentoUsuarioException() { }

        public PlanejamentoUsuarioException(string message) : base(message) { }

        public PlanejamentoUsuarioException(string message, Exception inner) : base(message, inner) { }
    }

    public class PlanejamentoCategoriaException : Exception
    {
        public PlanejamentoCategoriaException() { }

        public PlanejamentoCategoriaException(string message) : base(message) { }

        public PlanejamentoCategoriaException(string message, Exception inner) : base(message, inner) { }
    }

    public class PlanejamentoMesException : Exception
    {
        public PlanejamentoMesException() { }

        public PlanejamentoMesException(string message) : base(message) { }

        public PlanejamentoMesException(string message, Exception inner) : base(message, inner) { }
    }

    public class PlanejamentoValorException : Exception
    {
        public PlanejamentoValorException() { }

        public PlanejamentoValorException(string message) : base(message) { }

        public PlanejamentoValorException(string message, Exception inner) : base(message, inner) { }
    }
}
