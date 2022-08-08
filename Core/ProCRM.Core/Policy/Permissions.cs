using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core.Policy
{
    public class Permissions
    {
        public IEnumerable<string> Grants { get; set; }

        public Permissions()
        {
            Grants = new List<string>();
        }
    }
}
