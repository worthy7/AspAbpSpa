using Abp.Domain.Repositories;
using AspAbpSPAMay.Authorization.Users;
using AspAbpSPAMay.MultiTenancy;
using System.Threading.Tasks;
using Xunit;

namespace AspAbpSPAMay.Tests
{
    public class PkDupBug : AspAbpSPAMayTestBase
    {

        [Fact]
        public async Task ShouldAllowEntityUpdate()
        {

            var _tenantRepo = LocalIocManager.Resolve<IRepository<Tenant>>();

            Tenant tenant = _tenantRepo.Insert(new Tenant("Tname", "name"));

            var _userRepo = LocalIocManager.Resolve<IRepository<User,long>>();

            // save the event locally
            _userRepo.InsertOrUpdate(new User()
            {
                Tenant = tenant,
                Name = "jojo"
            });

        }
    
    }
}
