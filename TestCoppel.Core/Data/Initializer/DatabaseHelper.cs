using System.Data.Entity;
using System.Linq;

namespace TestCoppel.Core.Data.Initializer
{
    public class DatabaseHelper
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
    }
}
