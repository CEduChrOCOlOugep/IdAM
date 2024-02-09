using Microsoft.AspNetCore.Identity;

namespace IdAM.Data
{
    public class UserApplication
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int AppId { get; set; }
        public App App { get; set; }
    }
}
