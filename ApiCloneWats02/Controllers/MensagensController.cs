using ApiCloneWats02.Models;
using App.Domain;
using System;
using System.Web.Http;

namespace ApiCloneWats02.Controllers
{
    public class MensagensController : ApiController
    {
        // GET: api/Mensagens
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                MensagenModel usuario = new MensagenModel();
                return Ok(usuario.ListarMensagem());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET: api/Mensagens/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mensagens
        [HttpPost]
        public IHttpActionResult Post([FromBody]MensagemDTO mensagenDTO)
        {
            try
            {
                MensagenModel mensagen = new MensagenModel();
                mensagen.InserirMensagem(mensagenDTO);
                return Ok("Mensagem enviada!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Mensagens/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mensagens/5
        public void Delete(int id)
        {
        }
    }
}
