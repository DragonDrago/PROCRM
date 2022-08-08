using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core.Tenant
{
    public class TenantContext:ITenantContext
    {
        public Tenant CurrentTenant { get; set; }
    }
}
