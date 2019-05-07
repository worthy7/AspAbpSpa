using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspAbpSPAMay.Configuration;
using AspAbpSPAMay.EntityFrameworkCore;
using AspAbpSPAMay.Migrator.DependencyInjection;

namespace AspAbpSPAMay.Migrator
{
    [DependsOn(typeof(AspAbpSPAMayEntityFrameworkModule))]
    public class AspAbpSPAMayMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AspAbpSPAMayMigratorModule(AspAbpSPAMayEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(AspAbpSPAMayMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AspAbpSPAMayConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspAbpSPAMayMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
