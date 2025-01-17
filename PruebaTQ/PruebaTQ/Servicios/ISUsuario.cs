using PruebaTQ.Models;

namespace PruebaTQ.Servicios
{
    public interface ISUsuario
    {
        public IEnumerable<Usuario> GetUsuarios();

        public Usuario GetUsuario(int id);

        public Usuario InsertUsuario(Usuario u);
        public Usuario UpdateUsuario(int id);
        public Usuario DeleteUsuario(int id);

    }
}
