using System.Threading.Tasks;
using Abp.Application.Services;
using AspAbpSPAMay.Authorization.Accounts.Dto;

namespace AspAbpSPAMay.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
