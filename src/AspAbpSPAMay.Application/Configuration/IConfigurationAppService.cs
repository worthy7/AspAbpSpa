using System.Threading.Tasks;
using AspAbpSPAMay.Configuration.Dto;

namespace AspAbpSPAMay.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
