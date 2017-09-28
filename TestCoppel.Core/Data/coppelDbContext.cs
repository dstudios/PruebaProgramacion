using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using TestCoppel.Core.Data.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestCoppel.Core.Data
{
    public partial class coppelDbContext : DbContext
    {
        private const string ConnectionStringName = @"PrincipalDatabase";

        public coppelDbContext()
            : this(ConnectionStringName)
        {
        }

        public coppelDbContext(string connectionString)
            : this(DbConnectionFactory.GetWrappedDbConnection(connectionString))
        {
        }

        public coppelDbContext(DbConnection connection)
            : base(connection, true)
        {
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Proveedor>().HasMany(x => x.Productos).WithMany(x => x.Proveedores).Map(
                x => x.ToTable("ProveedorProducto").MapLeftKey("ProductoID").MapRightKey("ProveedorID"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
