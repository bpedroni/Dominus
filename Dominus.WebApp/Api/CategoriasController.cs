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
using System.Web;
using System.Web.Http;

namespace Dominus.WebApp
{
    public class CategoriasController : ApiController
    {
        // GET api/categorias - exibe todas as categorias ativas:
        public List<Categoria> Get()
        {
            return CategoriaManager.GetCategoriasAtivas();
        }

        // GET api/categorias/tipo/{id} - exibe todas as categorias ativas de algum tipo de fluxo:
        [HttpGet]
        [ActionName("tipo")]
        public List<Categoria> GetCategoriasByTipo(String id)
        {
            return CategoriaManager.GetCategoriasAtivas().Where(x => x.TipoFluxo.Equals(id.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        // GET api/categorias/id/{id} - exibe a categoria solicitada pelo id
        [ActionName("id")]
        public Categoria Get(String id)
        {
            try
            {
                Guid guid = Guid.Parse(id.Trim());
                return CategoriaManager.GetCategoriaById(guid);
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

                Categoria categoria = CategoriaManager.GetCategoriaById(Guid.Parse(id.Trim()));

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

        // POST api/categorias - salva a categoria recebida no banco de dados:
        public Categoria Post([FromBody] Categoria categoria)
        {
            try
            {
                if (categoria.IdCategoria == Guid.Empty)
                {
                    categoria.IdCategoria = Guid.NewGuid();
                }
                CategoriaManager.AddCategoria(categoria);
                return CategoriaManager.GetCategoriaById(categoria.IdCategoria);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = "Erro ao criar categoria",
                    Content = new StringContent(ex.Message)
                });
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

                Categoria categoria = CategoriaManager.GetCategoriaById(Guid.Parse(id.Trim()));

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

        // PUT api/categorias/{id} - edita a categoria recebida no banco de dados:
        public Categoria Put(String id, [FromBody] Categoria categoria)
        {
            try
            {
                categoria.IdCategoria = Guid.Parse(id.Trim());
                CategoriaManager.EditCategoria(categoria);
                return CategoriaManager.GetCategoriaById(categoria.IdCategoria);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = "Erro ao editar categoria",
                    Content = new StringContent(ex.Message)
                });
            }
        }

        // DELETE api/categorias/{id} - remove a categoria recebida no banco de dados:
        public void Delete(String id)
        {
            try
            {
                Categoria categoria = CategoriaManager.GetCategoriaById(Guid.Parse(id.Trim()));
                CategoriaManager.DeleteCategoria(categoria);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = "Erro ao remover categoria",
                    Content = new StringContent(ex.Message)
                });
            }
        }
    }
}