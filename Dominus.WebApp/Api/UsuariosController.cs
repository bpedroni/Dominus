using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dominus.WebApp.Api
{
    public class UsuariosController : ApiController
    {
        // GET api/usuarios - exibe todos os usuários ativos
        public List<Usuario> Get()
        {
            return UsuarioManager.GetUsuariosAtivos();
        }

        // GET api/usuarios/id/{id} - exibe o usuário solicitado pelo id
        [ActionName("id")]
        public Usuario Get(String id)
        {
            try
            {
                Guid guid = Guid.Parse(id.Trim());
                return UsuarioManager.GetUsuarioById(guid);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET api/usuarios/login/{id} - exibe o usuário solicitado pelo login ou e-mail
        [HttpGet]
        [ActionName("login")]
        public Usuario GetByLoginOrEmail(String id)
        {
            try
            {
                Usuario usuario = UsuarioManager.GetUsuarioByLogin(id.Trim());
                if (usuario == null)
                    usuario = UsuarioManager.GetUsuarioByEmail(id.Trim());

                return usuario;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // POST api/transacoes - salva o usuário recebido no banco de dados:
        public Usuario Post([FromBody] Usuario usuario)
        {
            try
            {
                UsuarioManager.AddUsuario(usuario);
                return UsuarioManager.GetUsuarioByEmail(usuario.Email.Trim());
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = "Erro ao criar usuario",
                    Content = new StringContent(ex.Message)
                });
            }
        }

        // PUT api/usuarios/{id} - edita o usuário recebido no banco de dados:
        public Usuario Put(String id, [FromBody] Usuario usuario)
        {
            try
            {
                usuario.IdUsuario = Guid.Parse(id.Trim());
                UsuarioManager.EditUsuario(usuario);
                return UsuarioManager.GetUsuarioById(usuario.IdUsuario);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = "Erro ao editar usuario",
                    Content = new StringContent(ex.Message)
                });
            }
        }

        // DELETE api/usuarios/{id} - remove o usuário recebido no banco de dados:
        public void Delete(String id)
        {
            try
            {
                Usuario usuario = UsuarioManager.GetUsuarioById(Guid.Parse(id.Trim()));
                UsuarioManager.DeleteUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = "Erro ao remover usuario",
                    Content = new StringContent(ex.Message)
                });
            }
        }
    }
}