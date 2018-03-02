using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

namespace Antiforgery.Controllers {
    [Route("api/[controller]/[action]")]
    public class XsrfTokenController : Controller {
        private readonly IAntiforgery _antiforgery;

        public XsrfTokenController(IAntiforgery antiforgery) {
            _antiforgery = antiforgery;
        }

        [HttpGet]
        public IActionResult Get() {
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);

            return new ObjectResult(new {
                token = tokens.RequestToken,
                tokenName = tokens.HeaderName
            });
        }
    }
}