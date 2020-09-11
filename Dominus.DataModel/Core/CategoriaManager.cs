using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dominus.DataModel.Core
{
    public class CategoriaManager
    {
        public const String TIPO_FLUXO_RECEITA = "Receita";
        public const String TIPO_FLUXO_DESPESA = "Despesa";

        public static List<Categoria> GetCategorias()
        {
            try
            {
                // Retorna uma lista de categorias cadastradas no sistema:
                return ConnectionManager.context.Categorias.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Categoria> GetCategoriasAtivas()
        {
            try
            {
                // Retorna uma lista de categorias que estão com o status ativo no sistema:
                return GetCategorias().Where(x => x.Ativo == ConnectionManager.STATUS_ATIVO).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Categoria GetCategoriaById(Guid idCategoria)
        {
            try
            {
                // Verifica se existe uma categoria com o id fornecido:
                Categoria categoria = GetCategorias().FirstOrDefault(x => x.IdCategoria == idCategoria);
                return categoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Categoria GetCategoriaByNome(String nome)
        {
            try
            {
                // Verifica se existe uma categoria com o nome fornecido:
                Categoria categoria = GetCategorias().FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
                return categoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddCategoria(Categoria categoria)
        {
            try
            {
                if (GetCategoriaByNome(categoria.Nome) != null)
                {
                    throw new Exception("O sistema já possui uma categoria com o nome '" + categoria.Nome + "'.");
                }
                // A aplicação gera uma nova categoria com as definições padrões:
                categoria.IdCategoria = Guid.NewGuid();
                categoria.DataCriacao = DateTime.Now;
                categoria.Ativo = ConnectionManager.STATUS_ATIVO;
                ConnectionManager.context.Entry(categoria).State = EntityState.Added;
                ConnectionManager.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditCategoria(Categoria categoria)
        {
            try
            {
                // A aplicação atualiza os dados da categoria fornecida:
                ConnectionManager.context.Entry(categoria).State = EntityState.Modified;
                ConnectionManager.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteCategoria(Categoria categoria)
        {
            try
            {
                // A aplicação remove a categoria alterando o seu status para inativo:
                categoria.Ativo = ConnectionManager.STATUS_INATIVO;
                ConnectionManager.context.Entry(categoria).State = EntityState.Modified;
                ConnectionManager.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
