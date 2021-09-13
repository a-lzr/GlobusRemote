using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Services
{
    public class GlobalExceptionHandlerMidlleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMidlleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var logger = context.RequestServices.GetService(typeof(ILogger)) as ILogger;
                string info = "";
                if (context != null)
                {
                    info = context.Connection.RemoteIpAddress.ToString().Replace(":", "_") + " ";
                }
                logger.LogError($"{DateTime.Now} {info}{e.Message}");
            }
        }
    }
}
