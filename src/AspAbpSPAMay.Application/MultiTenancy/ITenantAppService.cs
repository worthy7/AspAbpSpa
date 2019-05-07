using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AspAbpSPAMay.MultiTenancy.Dto;

namespace AspAbpSPAMay.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

