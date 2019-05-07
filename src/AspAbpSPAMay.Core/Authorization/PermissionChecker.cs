using Abp.Authorization;
using AspAbpSPAMay.Authorization.Roles;
using AspAbpSPAMay.Authorization.Users;

namespace AspAbpSPAMay.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
