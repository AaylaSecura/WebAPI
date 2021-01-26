using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Sdt.Web.Common.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BrowserForbiddenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Browser[] _browsersForbidden;

        public BrowserForbiddenMiddleware(RequestDelegate next, params Browser[] browsersForbidden)
        {
            _next = next;
            _browsersForbidden = browsersForbidden;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var browserType = (Browser) httpContext.Items["X-BrowserType"];
            if (_browsersForbidden.Any(c => c == browserType)) //in der Blacklist vorhanden
            {
                httpContext.Response.StatusCode = (int) HttpStatusCode.Forbidden;
            }
            else //alles ok
            {
                await _next(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BrowserForbiddenMiddlewareExtensions
    {
        public static IApplicationBuilder UseBrowserForbiddenMiddleware(this IApplicationBuilder builder, params Browser[] browsersForbidden)
        {
            return builder.UseMiddleware<BrowserForbiddenMiddleware>(browsersForbidden);
        }
    }
}
