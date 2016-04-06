using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

namespace OSIRT.Database
{
    public class SqLiteConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }

    }
}
