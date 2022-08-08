using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core.Tenant
{
    public class TenantMiddleware
    {
        private RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITenantContext tenantContext)
        {
            if (context.Request.Headers.Keys.Count(c => c.StartsWith("xl-")) == 4)
            {
                tenantContext.CurrentTenant = new Tenant()
                {
                    ConnectionString = context.Request.Headers["xl-db-connection"],
                    CompanyName = context.Request.Headers["xl-company-name"],
                    DbName = context.Request.Headers["xl-db-name"],
                    TenantId = context.Request.Headers["xl-tenant-id"]
                };
            }

            await _next(context);
        }
    }
}
