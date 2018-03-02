using Microsoft.AspNetCore.Builder;

namespace Antiforgery.Middleware {
    public static class ApplicationBuilderExtensions {
        public static IApplicationBuilder UseAntiforgeryTokens(this IApplicationBuilder app) {
            return app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();
        }
    }
}