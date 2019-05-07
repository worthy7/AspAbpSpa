using Abp.Application.Services.Dto;

namespace AspAbpSPAMay.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

