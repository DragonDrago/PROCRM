using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core.Exceptions
{
    public static class ExceptionExtention
    {
        public static IApplicationBuilder UseLimaExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ProCRMExceptionMiddleware>();
        }
    }
}
