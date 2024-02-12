using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdAM.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<IdentityUserRole<string>> Roles { get; set; }
        public ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public ICollection<App> Apps { get; set; }
    }
}