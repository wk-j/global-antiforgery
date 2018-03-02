using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace Antiforgery.Middleware {

    public class ValidateAntiForgeryTokenMiddleware {
        private readonly RequestDelegate next;
        private readonly IAntiforgery antiforgery;
        public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery) {
            this.next = next;
            this.antiforgery = antiforgery;
        }

        public async Task Invoke(HttpContext context) {
            if (HttpMethods.IsPost(context.Request.Method)) {
                await antiforgery.ValidateRequestAsync(context);
            }

            await next(context);
        }
    }
}