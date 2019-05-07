using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AspAbpSPAMay.EntityFrameworkCore
{
    public static class AspAbpSPAMayDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AspAbpSPAMayDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AspAbpSPAMayDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
