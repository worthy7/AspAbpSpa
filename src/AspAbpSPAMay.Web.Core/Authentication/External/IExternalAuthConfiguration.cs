using System.Collections.Generic;

namespace AspAbpSPAMay.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
