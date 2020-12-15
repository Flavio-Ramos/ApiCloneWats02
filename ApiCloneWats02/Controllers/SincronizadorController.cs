using ApiCloneWats02.Models;
using App.Domain;
using System.Collections.Generic;
using System.Web.Http;

namespace ApiCloneWats02.Controllers
{
    public class SincronizadorController : ApiController
    {
        // GET: api/Sincronizador
        public IEnumerable<string> Get()
        {
            //vai para model
            //SincronizadorModel sincronizadorModel = new SincronizadorModel();
            //return sincronizadorModel.Sincronizar(sincronia);
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sincronizador/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sincronizador
        public SincronizadorDTO Post([FromBody]SincronizadorDTO sincronia)
        {
            SincronizadorModel sincronizadorModel = new SincronizadorModel();
            return sincronizadorModel.Sincronizar(sincronia);
        }

        // PUT: api/Sincronizador/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sincronizador/5
        public void Delete(int id)
        {
        }
    }
}
