using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominus.DataModel.Core
{
    public class CategoriaManager
    {
        public static List<Categoria> GetCategorias()
        {
            try
            {
                return ConnectionManager.connection.Categorias.ToList();
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
                ConnectionManager.connection.Categorias.Add(categoria);
                ConnectionManager.connection.SaveChanges();
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
                ConnectionManager.connection.Entry(categoria).State = EntityState.Modified;
                ConnectionManager.connection.SaveChanges();
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
                ConnectionManager.connection.Entry(categoria).State = EntityState.Deleted;
                ConnectionManager.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
