using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core.Tenant
{
    public class Tenant
    {
        public string TenantId { get; set; }
        public string DbName { get; set; }
        public string ConnectionString { get; set; }
        public string CompanyName { get; set; }
    }
}
