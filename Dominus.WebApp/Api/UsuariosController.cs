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

        // POST api/<controller>
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

        // PUT api/<controller>/5
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

        // DELETE api/<controller>/5
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