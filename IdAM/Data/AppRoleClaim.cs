using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdAM.Data
{
    public class AppRoleClaim : IdentityRoleClaim<string>
    {
        public string RoleId { get; set; }
        public int AppId { get; set; }

        [ForeignKey("RoleId,AppId")]
        public AppRole AppRole { get; set; }
    }
}