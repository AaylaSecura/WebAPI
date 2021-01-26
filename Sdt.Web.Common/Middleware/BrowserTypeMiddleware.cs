using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Sdt.Web.Common.Middleware
{
    public enum Browser
    {
        InternetExplorer,
        Firefox,
        Chrome,
        Edge,
        Opera,
        SomethingElse
    }

    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BrowserTypeMiddleware
    {
        private readonly RequestDelegate _next;

        public BrowserTypeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["X-BrowserType"] = IdentifyBrowserType(httpContext);

            await _next(httpContext);
        }

        private Browser IdentifyBrowserType(HttpContext context)
        {
            var userAgent = context.Request.Headers["User-Agent"][0].ToLower();
            Browser browserType;

            if (userAgent.Contains("chrome") &&
                !(userAgent.Contains("edge") || userAgent.Contains("edg") || userAgent.Contains("opr")))
            {
                browserType = Browser.Chrome;
            }
            else if (userAgent.Contains("firefox"))
            {
                browserType = Browser.Firefox;
            }
            else if (userAgent.Contains("trident"))
            {
                browserType = Browser.InternetExplorer;
            }
            else if (userAgent.Contains("edge") || userAgent.Contains("edg"))
            {
                browserType = Browser.Edge;
            }
            else if (userAgent.Contains("opr"))
            {
                browserType = Browser.Opera;
            }
            else
            {
                browserType = Browser.SomethingElse;
            }

            return browserType;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BrowserTypeMiddlewareExtensions
    {
        public static IApplicationBuilder UseBrowserTypeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserTypeMiddleware>();
        }
    }
}
