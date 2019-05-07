using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AspAbpSPAMay.Authorization.Roles;
using AspAbpSPAMay.Authorization.Users;
using AspAbpSPAMay.MultiTenancy;

namespace AspAbpSPAMay.EntityFrameworkCore
{
    public class AspAbpSPAMayDbContext : AbpZeroDbContext<Tenant, Role, User, AspAbpSPAMayDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AspAbpSPAMayDbContext(DbContextOptions<AspAbpSPAMayDbContext> options)
            : base(options)
        {
        }
    }
}
