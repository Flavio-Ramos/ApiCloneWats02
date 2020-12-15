using ApiCloneWats02.Models;
using App.Domain;
using System;
using System.Web.Http;

namespace ApiCloneWats02.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();
                return Ok(usuario.ListarUsuarios());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            
        }

        // GET: api/Usuario/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                
                UsuarioModel usuario = new UsuarioModel();
                return Ok(usuario.ListarUsuario(id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        // POST: api/Usuario
        [HttpPost]
        public IHttpActionResult Post([FromBody]UsuarioDTO parUsuario)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();
                usuario.InserirUsuarios(parUsuario);
                return Ok("Inserido com sucesso!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Usuario/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]UsuarioDTO paramUsuario)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();
                usuario.AtualizarUsuario(paramUsuario);
                return Ok("Altearado com sucesso!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // DELETE: api/Usuario/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();
                usuario.DeletarUsuario(id);
                return Ok("Deletado com sucesso!");
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
