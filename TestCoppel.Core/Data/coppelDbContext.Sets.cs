using System.Data.Entity;
using TestCoppel.Core.Data.Models;

namespace TestCoppel.Core.Data
{
    public partial class coppelDbContext : DbContext
    {
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
