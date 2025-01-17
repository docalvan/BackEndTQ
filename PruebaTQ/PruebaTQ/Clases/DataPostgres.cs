using Microsoft.EntityFrameworkCore;
using PruebaTQ.Models;

namespace PruebaTQ.Clases
{
    public class DataPostgres: DbContext
    {
        public DataPostgres(DbContextOptions<DataPostgres> options): base(options){ }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
    }
}
