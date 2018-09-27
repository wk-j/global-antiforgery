using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

namespace Antiforgery.Controllers {
    [Route("api/[controller]/[action]")]
    public class XsrfTokenController : ControllerBase {
        private readonly IAntiforgery antiforgery;

        public XsrfTokenController(IAntiforgery antiforgery) {
            this.antiforgery = antiforgery;
        }

        [HttpGet]
        public IActionResult Get() {
            var tokens = antiforgery.GetAndStoreTokens(HttpContext);

            return new ObjectResult(new {
                token = tokens.RequestToken,
                tokenName = tokens.HeaderName
            });
        }
    }
}