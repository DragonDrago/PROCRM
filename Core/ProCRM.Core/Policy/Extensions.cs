using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core.Policy
{
   public static class Extensions
   {
        public static IServiceCollection AddGrantAccess(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<Permissions>();

            services.AddScoped<IAuthorizationHandler, GrantAuthorizationHandler>();

            return services;
        }

        public static IApplicationBuilder UseGrantsAccess(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GrantMiddleware>();
        }
    }
}
