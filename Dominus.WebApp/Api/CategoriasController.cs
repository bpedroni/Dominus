using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Dominus.WebApp
{
    public class CategoriasController : ApiController
    {
        // GET api/categorias - exibe todas as categorias ativas:
        public List<Categoria> Get()
        {
            List<Categoria> categorias = CategoriaManager.GetCategoriasAtivas();

            foreach (Categoria categoria in categorias)
            {
                categoria.Transacoes.Clear();
                categoria.Planejamentos.Clear();
            }

            return categorias;
        }

        // GET api/categorias/tipo/{id} - exibe todas as categorias ativas de algum tipo de fluxo:
        [HttpGet]
        [ActionName("tipo")]
        public List<Categoria> GetCategoriasByTipo(String id)
        {
            List<Categoria> categorias = CategoriaManager.GetCategoriasAtivas().Where(x => x.TipoFluxo.Equals(id, StringComparison.CurrentCultureIgnoreCase)).ToList();

            foreach (Categoria categoria in categorias)
            {
                categoria.Transacoes.Clear();
                categoria.Planejamentos.Clear();
            }

            return categorias;
        }

        // GET api/categorias/id/{id} - exibe a categoria solicitada pelo id
        [ActionName("id")]
        public Categoria Get(String id)
        {
            try
            {
                Guid guid = Guid.Parse(id);
                Categoria categoria = CategoriaManager.GetCategoriaById(guid);
                categoria.Transacoes.Clear();
                categoria.Planejamentos.Clear();

                return categoria;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET api/categorias/icone/{id} - exibe o ícone de uma categoria solicitado pelo id:
        [HttpGet]
        [ActionName("icone")]
        public String GetIconeCategoria(String id)
        {
            String path = HttpContext.Current.Server.MapPath("~/Images/Categorias/");

            Guid guid = Guid.Parse(id);
            Categoria categoria = CategoriaManager.GetCategoriaById(guid);

            String icone = path + categoria.Icone;
            if (File.Exists(icone))
            {
                byte[] b = File.ReadAllBytes(icone);
                return "data:image/png;base64," + Convert.ToBase64String(b);
            }
            return path + categoria.Icone;
        }

        // POST api/<controller>
        public void Post([FromBody] Categoria categoria)
        {
            try
            {
                CategoriaManager.AddCategoria(categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<controller>/5
        public void Put(String id, [FromBody] Categoria categoria)
        {
            try
            {
                categoria.IdCategoria = Guid.Parse(id);
                CategoriaManager.EditCategoria(categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(String id)
        {
            try
            {
                Guid guid = Guid.Parse(id);
                Categoria categoria = CategoriaManager.GetCategoriaById(guid);
                CategoriaManager.DeleteCategoria(categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}