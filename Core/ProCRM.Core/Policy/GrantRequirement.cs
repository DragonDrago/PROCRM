using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core.Policy
{
    public class GrantRequirement:IAuthorizationRequirement
    {
        public string GrantName { get; set; }
        public GrantRequirement(string grantName)
        {
            GrantName = grantName;
        }
    }
}
