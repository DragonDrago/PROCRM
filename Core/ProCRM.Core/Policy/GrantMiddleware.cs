using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core.Policy
{
    public class GrantMiddleware
    {
        private RequestDelegate _next;

        public GrantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, Permissions permissions)
        {
            if (context.Request.Headers.ContainsKey("grants"))
            {
                permissions.Grants = context.Request.Headers["grants"].ToString().Split(",");
            }

            await _next(context);
        }
    }
}
