using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AspAbpSPAMay.EntityFrameworkCore.Seed;

namespace AspAbpSPAMay.EntityFrameworkCore
{
    [DependsOn(
        typeof(AspAbpSPAMayCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class AspAbpSPAMayEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<AspAbpSPAMayDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        AspAbpSPAMayDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        AspAbpSPAMayDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspAbpSPAMayEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
