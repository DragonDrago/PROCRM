using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core.Tenant
{
    public interface ITenantContext
    {
        Tenant CurrentTenant { get; set; }
    }
}
