using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AspAbpSPAMay.Configuration;
using AspAbpSPAMay.Web;

namespace AspAbpSPAMay.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AspAbpSPAMayDbContextFactory : IDesignTimeDbContextFactory<AspAbpSPAMayDbContext>
    {
        public AspAbpSPAMayDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AspAbpSPAMayDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AspAbpSPAMayDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AspAbpSPAMayConsts.ConnectionStringName));

            return new AspAbpSPAMayDbContext(builder.Options);
        }
    }
}
