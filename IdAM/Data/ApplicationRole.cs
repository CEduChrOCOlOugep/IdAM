using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdAM.Data
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }

        public ApplicationRole(string roleName)
            : base(roleName) { }

        public ICollection<App> Apps { get; set; }
        public ICollection<IdentityRoleClaim<string>> Claims { get; set; }
    }
}