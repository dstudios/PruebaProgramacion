using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using TestCoppel.Core.Data;

namespace TestCoppel.Core.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<coppelDbContext>
    {
        public Configuration()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PrincipalDatabase"].ConnectionString;
            TargetDatabase = new DbConnectionInfo(connectionString, "System.Data.SqlClient");
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }
    }
}
