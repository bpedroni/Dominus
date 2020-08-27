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
        public static DominusConnection connection = new DominusConnection();

        public static List<Categoria> GetCategorias()
        {
            try
            {
                return connection.Categorias.ToList();
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
                connection.Categorias.Add(categoria);
                connection.SaveChanges();
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
                connection.Entry(categoria).State = EntityState.Modified;
                connection.SaveChanges();
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
                connection.Entry(categoria).State = EntityState.Deleted;
                connection.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
