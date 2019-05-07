using Abp.MultiTenancy;
using AspAbpSPAMay.Authorization.Users;

namespace AspAbpSPAMay.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
