using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
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
                Guid guid = Guid.Parse(id);
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
                Usuario usuario = UsuarioManager.GetUsuarioByLogin(id);
                if (usuario == null)
                    usuario = UsuarioManager.GetUsuarioByLogin(id);

                return usuario;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // POST api/transacoes - salva o usuário recebido no banco de dados:
        public void Post([FromBody] Usuario usuario)
        {
            try
            {
                UsuarioManager.AddUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/usuarios/{id} - edita o usuário recebido no banco de dados:
        public void Put(String id, [FromBody] Usuario usuario)
        {
            try
            {
                usuario.IdUsuario = Guid.Parse(id);
                UsuarioManager.EditUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/usuarios/{id} - remove o usuário recebido no banco de dados:
        public void Delete(String id)
        {
            try
            {
                Guid guid = Guid.Parse(id);
                Usuario usuario = UsuarioManager.GetUsuarioById(guid);
                UsuarioManager.DeleteUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}