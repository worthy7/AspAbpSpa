using AspAbpSPAMay.Authorization.Roles;
using AspAbpSPAMay.Users;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspAbpSPAMay.Tests
{
    public class RolesTests : AspAbpSPAMayTestBase
    {

        [Fact]
        public async Task AdminRoleShouldExist()
        {
            // arrange
            LoginAsHostAdmin();

            // act get all the roles we can use
            var uas = LocalIocManager.Resolve<IUserAppService>();

            var roles = await uas.GetRoles();
            roles.Items.ShouldContain(c => c.Name == StaticRoleNames.Host.Mod);
            
        }
    }
}
