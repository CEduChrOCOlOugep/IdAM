using Microsoft.AspNetCore.Identity;

namespace IdAM.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<IdentityUserRole<string>> Roles { get; set; }
        public ICollection<IdentityUserClaim<string>> Claims { get; set; }
        
        public ICollection<UserApplication> UserApplications { get; set; }
        
    }
}
