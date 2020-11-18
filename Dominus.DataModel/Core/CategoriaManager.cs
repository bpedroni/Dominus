using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;

namespace Dominus.DataModel.Core
{
    public class CategoriaManager
    {
        private static ConnectionManager connection = new ConnectionManager();

        public const String TIPO_FLUXO_RECEITA = "Receita";
        public const String TIPO_FLUXO_DESPESA = "Despesa";

        public static List<Categoria> GetCategorias()
        {
            try
            {
                // Retorna uma lista de categorias cadastradas no sistema:
                connection.OpenConnection();
                List<Categoria> categorias = connection.context.Categorias.ToList();
                connection.CloseConnection();
                return categorias;
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
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
                // A aplicação gera uma nova categoria com as definições padrões:
                ValidarDadosCategoria(categoria);
                if (categoria.IdCategoria == Guid.Empty)
                {
                    categoria.IdCategoria = Guid.NewGuid();
                }
                categoria.Nome = categoria.Nome.Trim();
                categoria.Descricao = categoria.Descricao.Trim();
                categoria.DataCriacao = DateTime.Now;
                categoria.Ativo = ConnectionManager.STATUS_ATIVO;

                connection.OpenConnection();
                connection.context.Entry(categoria).State = EntityState.Added;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void EditCategoria(Categoria categoria)
        {
            try
            {
                // A aplicação atualiza os dados da categoria fornecida:
                Categoria old = GetCategoriaById(categoria.IdCategoria);
                if (old == null)
                    throw new Exception("Categoria não encontrada no sistema.");

                ValidarDadosCategoria(categoria, old);
                old.Nome = categoria.Nome.Trim();
                old.Descricao = categoria.Descricao.Trim();
                old.TipoFluxo = categoria.TipoFluxo;

                connection.OpenConnection();
                connection.context.Entry(old).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        public static void DeleteCategoria(Categoria categoria)
        {
            try
            {
                // A aplicação remove a categoria alterando o seu status para inativo:
                Categoria old = GetCategoriaById(categoria.IdCategoria);
                if (old == null)
                    throw new Exception("Categoria não encontrada no sistema.");

                old.Ativo = ConnectionManager.STATUS_INATIVO;

                connection.OpenConnection();
                connection.context.Entry(old).State = EntityState.Modified;
                connection.context.SaveChanges();
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                connection.CloseConnection();
                throw ex;
            }
        }

        private static void ValidarDadosCategoria(Categoria categoria, Categoria old = null)
        {
            if (String.IsNullOrWhiteSpace(categoria.Nome) || categoria.Nome.Trim().Length > 50)
                throw new CategoriaNomeException("O nome deve ser preenchido (até 50 caracteres).");

            if ((old == null || !categoria.Nome.Trim().Equals(old.Nome) || !categoria.TipoFluxo.Equals(old.TipoFluxo)) && GetCategoriaByNomeETipo(categoria.Nome.Trim(), categoria.TipoFluxo) != null)
                throw new CategoriaNomeException("O sistema já possui uma categoria com o nome e o tipo de fluxo indicados.");

            if (String.IsNullOrWhiteSpace(categoria.Descricao) || categoria.Descricao.Trim().Length > 255)
                throw new CategoriaDescricaoException("A descrição deve ser preenchida (até 255 caracteres).");

            if (!categoria.TipoFluxo.Equals(TIPO_FLUXO_RECEITA) && !categoria.TipoFluxo.Equals(TIPO_FLUXO_DESPESA))
                throw new CategoriaTipoFluxoException("O tipo de fluxo deve ser 'Receita' ou 'Despesa'.");

            if (String.IsNullOrWhiteSpace(categoria.Icone) || categoria.Icone.Trim().Length > 100)
                throw new CategoriaIconeException("O ícone deve conter o nome de uma imagem no formato PNG (até 100 caracteres).");
        }

        public static Image GetIconeCategoria(Categoria categoria)
        {
            try
            {
                // Verifica se o site está no ar e retorna a imagem do ícone da categoria fornecida:
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
                // Verifica se o site está no ar e salva a imagem do ícone da categoria fornecida:
                if (ConnectionManager.VerificaSiteOnLine())
                {
                    String urlDominus = ConfigurationManager.AppSettings["UrlSiteDominus"];
                    using (WebClient webClient = new WebClient { UseDefaultCredentials = true })
                    {
                        webClient.Headers.Add(HttpRequestHeader.ContentType, "image/gif");
                        byte[] imageBytes = webClient.DownloadData(filepath);
                        webClient.UploadData(urlDominus + "/api/Categorias/uploadIcone/" + categoria.IdCategoria.ToString(),
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

        public class CategoriaNomeException : Exception
        {
            public CategoriaNomeException() { }

            public CategoriaNomeException(string message) : base(message) { }

            public CategoriaNomeException(string message, Exception inner) : base(message, inner) { }
        }

        public class CategoriaDescricaoException : Exception
        {
            public CategoriaDescricaoException() { }

            public CategoriaDescricaoException(string message) : base(message) { }

            public CategoriaDescricaoException(string message, Exception inner) : base(message, inner) { }
        }

        public class CategoriaTipoFluxoException : Exception
        {
            public CategoriaTipoFluxoException() { }

            public CategoriaTipoFluxoException(string message) : base(message) { }

            public CategoriaTipoFluxoException(string message, Exception inner) : base(message, inner) { }
        }

        public class CategoriaIconeException : Exception
        {
            public CategoriaIconeException() { }

            public CategoriaIconeException(string message) : base(message) { }

            public CategoriaIconeException(string message, Exception inner) : base(message, inner) { }
        }
    }
}
