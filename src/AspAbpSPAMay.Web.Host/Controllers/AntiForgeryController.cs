using Microsoft.AspNetCore.Antiforgery;
using AspAbpSPAMay.Controllers;

namespace AspAbpSPAMay.Web.Host.Controllers
{
    public class AntiForgeryController : AspAbpSPAMayControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
