using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspAbpSPAMay.Configuration;

namespace AspAbpSPAMay.Web.Host.Startup
{
    [DependsOn(
       typeof(AspAbpSPAMayWebCoreModule))]
    public class AspAbpSPAMayWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AspAbpSPAMayWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspAbpSPAMayWebHostModule).GetAssembly());
        }
    }
}
