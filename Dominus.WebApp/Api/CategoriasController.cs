using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
        public HttpResponseMessage GetIconeCategoria(String id)
        {
            try
            {
                String path = HttpContext.Current.Server.MapPath("~/Images/Categorias/");

                Guid guid = Guid.Parse(id);
                Categoria categoria = CategoriaManager.GetCategoriaById(guid);

                String icone = path + categoria?.Icone;
                if (File.Exists(icone))
                {
                    FileStream file = new FileStream(icone, FileMode.Open, FileAccess.Read);
                    HttpResponseMessage response = new HttpResponseMessage { Content = new StreamContent(file) };
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = categoria.Icone;
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");

                    return response;
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
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

        // POST api/categorias/salvaIcone/{id} - salva uma imagem como ícone de uma categoria solicitada pelo id:
        [HttpPost]
        [ActionName("uploadIcone")]
        public HttpResponseMessage PostIconeCategoria(String id)
        {
            try
            {
                String path = HttpContext.Current.Server.MapPath("~/Images/Categorias/");

                Guid guid = Guid.Parse(id);
                Categoria categoria = CategoriaManager.GetCategoriaById(guid);

                byte[] data = Request.Content.ReadAsByteArrayAsync().Result;
                using (MemoryStream ms = new MemoryStream(data))
                {
                    try
                    {
                        Image image = Image.FromStream(ms);
                        if (image.Width > 64)
                        {
                            image = (Image)(new Bitmap(image, new Size(64, 64 * (image.Height / image.Width)))); ;
                        }
                        image.Save(path + categoria.Icone);
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    catch (Exception)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
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