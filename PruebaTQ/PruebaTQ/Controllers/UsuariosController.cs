using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTQ.Models;
using PruebaTQ.Servicios;

namespace PruebaTQ.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ISUsuario _serviciousuario;

        public UsuariosController(ISUsuario sUsuario)
        {
            _serviciousuario = sUsuario;
        }

        // GET: api/<UsuarioController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // POST api/<UsuarioController>
        [HttpPost("Usuario")]
        public ActionResult<Usuario> NuevoUsuario(Usuario u)
        {
            Usuario usuario = new Usuario
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Correo = u.Correo,
                Clave = u.Clave,
                Rol = u.Rol
            };

            _serviciousuario.InsertUsuario(usuario);
            return usuario;
        }

        /*
        [HttpPost("Producto")]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
