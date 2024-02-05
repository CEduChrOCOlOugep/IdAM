using Microsoft.AspNetCore.Identity;

namespace IdAM.Data
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }

        public ApplicationRole(string roleName)
            : base(roleName) { }

        public ICollection<IdentityRoleClaim<string>> Claims { get; set; }
    }

}
