using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Sdt.Web.Common.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BrowserErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public BrowserErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Vorher
            await _next(httpContext);
            //Nachher
            switch (httpContext.Response.StatusCode)
            {
                case 403: await httpContext.Response.WriteAsync("Der Browser ist Mist!", Encoding.UTF8); break;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BrowserErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseBrowserErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserErrorMiddleware>();
        }
    }
}
