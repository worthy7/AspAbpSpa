using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AspAbpSPAMay.Controllers
{
    public abstract class AspAbpSPAMayControllerBase: AbpController
    {
        protected AspAbpSPAMayControllerBase()
        {
            LocalizationSourceName = AspAbpSPAMayConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
