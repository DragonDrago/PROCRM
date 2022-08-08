using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core.Policy
{
    public class GrantAuthorizationHandler:AuthorizationHandler<GrantRequirement>
    {
        private  Permissions _permissions;

        public GrantAuthorizationHandler(Permissions permissions)
        {
            _permissions = permissions;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GrantRequirement requirement)
        {
            if (_permissions.Grants.Contains(requirement.GrantName))
                context.Succeed(requirement);

            return Task.FromResult(0);
        }
    }
}
