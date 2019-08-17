using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MiddlewareWebAPI.App
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY = "123456789";

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            bool isValidKey = false;
            var keyExist = context.Request.Headers.ContainsKey("key");
            //context.Request.Body.

            if(keyExist)
            {
                if(context.Request.Headers["key"] == API_KEY)
                {
                    isValidKey = true;
                }

            }

            if(!isValidKey)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("User is Unauthorized");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
