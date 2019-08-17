using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiddlewareWebAPI.App
{
    public static class AuthenticationMiddlewareHandler
    {
        public static IApplicationBuilder UseAuthenticationMiddlewareHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
