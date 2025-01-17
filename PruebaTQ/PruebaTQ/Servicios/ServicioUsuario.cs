using PruebaTQ.Clases;
using PruebaTQ.Models;

namespace PruebaTQ.Servicios
{
    public class ServicioUsuario : ISUsuario
    {

        private readonly DataPostgres _dbContext;

        public ServicioUsuario(DataPostgres dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> InsertarUsuarioAsync(Usuario u)
        {
            _dbContext.Usuarios.Add(u);
            await _dbContext.SaveChangesAsync();
            return u;
        }


        public Usuario DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public Usuario InsertUsuario(Usuario u)
        {
            throw new NotImplementedException();
        }

        public Usuario UpdateUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
