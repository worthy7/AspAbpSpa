using System.Threading.Tasks;
using Abp.Application.Services;
using AspAbpSPAMay.Sessions.Dto;

namespace AspAbpSPAMay.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
