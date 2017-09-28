using System.Data.Entity;

namespace TestCoppel.Core.Data.Initializer
{
    public class DatabaseInitializer : MigrateDatabaseToLatestVersion<coppelDbContext, Migrations.Configuration>
    {
    }
}
