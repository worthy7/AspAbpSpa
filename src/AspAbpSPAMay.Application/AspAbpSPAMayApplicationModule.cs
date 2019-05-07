using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspAbpSPAMay.Authorization;

namespace AspAbpSPAMay
{
    [DependsOn(
        typeof(AspAbpSPAMayCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AspAbpSPAMayApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AspAbpSPAMayAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AspAbpSPAMayApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
