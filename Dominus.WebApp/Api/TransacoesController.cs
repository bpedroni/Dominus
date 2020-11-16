using Dominus.DataModel;
using Dominus.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dominus.WebApp.Api
{
    public class TransacoesController : ApiController
    {
        // GET api/transacoes - exibe todas as transacoes de um usuário:
        public List<Transacao> Get()
        {
            return null;
        }

        // GET api/transacoes/{id} - exibe todas as transacoes de um usuário:
        public List<Transacao> Get(String id, int? mes = null, int? ano = null)
        {
            try
            {
                Guid guid = Guid.Parse(id);
                Usuario usuario = UsuarioManager.GetUsuarioById(guid);
                if (usuario != null)
                {
                    return TransacaoManager.GetTransacoes(usuario, mes, ano);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // POST api/transacoes - salva a transação recebida no banco de dados:
        public void Post([FromBody] Transacao transacao)
        {
            try
            {
                TransacaoManager.AddTransacao(transacao);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    ReasonPhrase = "Erro ao criar transação",
                    Content = new StringContent(ex.Message)
                });
            }
        }

        // PUT api/transacoes/{id} - edita a transação recebida no banco de dados:
        public void Put(String id, [FromBody] Transacao transacao)
        {
            try
            {
                transacao.IdTransacao = Guid.Parse(id);
                TransacaoManager.EditTransacao(transacao);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    ReasonPhrase = "Erro ao editar transação",
                    Content = new StringContent(ex.Message)
                });
            }
        }

        // DELETE api/transacoes/{id} - remove a transação recebida no banco de dados:
        public void Delete(String id)
        {
            try
            {
                Transacao transacao = TransacaoManager.GetTransacaoById(Guid.Parse(id));
                TransacaoManager.DeleteTransacao(transacao);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    ReasonPhrase = "Erro ao remover transação",
                    Content = new StringContent(ex.Message)
                });
            }
        }
    }
}