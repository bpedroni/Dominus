using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

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
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                List<Categoria> categorias = connection.context.Categorias.ToList();
                connection.CloseConnection();
                return categorias;
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

        public static Categoria GetCategoriaByNomeETipo(String nome, String tipoFluxo)
        {
            try
            {
                // Verifica se existe uma categoria com o nome fornecido:
                Categoria categoria = GetCategorias().FirstOrDefault(x => x.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase) && x.TipoFluxo.Equals(tipoFluxo));
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
                if (GetCategoriaByNomeETipo(categoria.Nome, categoria.TipoFluxo) != null)
                {
                    throw new Exception("O sistema já possui uma categoria com o nome '" + categoria.Nome + "'.");
                }
                // A aplicação gera uma nova categoria com as definições padrões:
                categoria.IdCategoria = Guid.NewGuid();
                categoria.DataCriacao = DateTime.Now;
                categoria.Ativo = ConnectionManager.STATUS_ATIVO;
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                connection.context.Entry(categoria).State = EntityState.Added;
                connection.context.SaveChanges();
                connection.CloseConnection();
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
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                connection.context.Entry(categoria).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
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
                ConnectionManager connection = new ConnectionManager();
                connection.OpenConnection();
                connection.context.Entry(categoria).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Image GetIconeCategoria(Categoria categoria)
        {
            try
            {
                if (ConnectionManager.VerificaSiteOnLine())
                {
                    String urlDominus = ConfigurationManager.AppSettings["UrlSiteDominus"];
                    WebRequest request = WebRequest.Create(urlDominus + "/api/Categorias/icone/" + categoria.IdCategoria.ToString());

                    using (WebResponse response = request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    {
                        return Image.FromStream(stream);
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool SaveIconeCategoria(Categoria categoria, String filepath)
        {
            try
            {
                if (ConnectionManager.VerificaSiteOnLine() && GetCategoriaByNomeETipo(categoria.Nome, categoria.TipoFluxo) != null)
                {
                    Categoria categ = GetCategoriaByNomeETipo(categoria.Nome, categoria.TipoFluxo);
                    String urlDominus = ConfigurationManager.AppSettings["UrlSiteDominus"];
                    using (WebClient webClient = new WebClient { UseDefaultCredentials = true })
                    {
                        webClient.Headers.Add(HttpRequestHeader.ContentType, "image/gif");
                        byte[] imageBytes = webClient.DownloadData(filepath);
                        webClient.UploadData(urlDominus + "/api/Categorias/uploadIcone/" + categ.IdCategoria.ToString(),
                            WebRequestMethods.Http.Post,
                            imageBytes);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
