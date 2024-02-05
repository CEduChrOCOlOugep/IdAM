using IdAM.Data;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        // Check if the database is already seeded
        if (context.Users.Any())
        {
            return;
        }

        // Read data from JSON files
        var users = JsonConvert.DeserializeObject<List<ApplicationUser>>(File.ReadAllText("FileBaseContext/AspNetUsers.json"));
        var userroles = JsonConvert.DeserializeObject<List<IdentityUserRole<string>>>(File.ReadAllText("FileBaseContext/AspNetUserRoles.json"));
        var userclaims = JsonConvert.DeserializeObject<List<IdentityUserClaim<string>>>(File.ReadAllText("FileBaseContext/AspNetUserClaims.json"));
        var roles = JsonConvert.DeserializeObject<List<ApplicationRole>>(File.ReadAllText("FileBaseContext/AspNetRoles.json"));
        var roleclaims = JsonConvert.DeserializeObject<List<IdentityRoleClaim<string>>>(File.ReadAllText("FileBaseContext/AspNetRoleClaims.json"));

        // Remove explicit Id values from userclaims and roleclaims
        userclaims.ForEach(uc => uc.Id = 0);
        roleclaims.ForEach(rc => rc.Id = 0);

        // Seed data
        context.Users.AddRange(users);
        context.UserRoles.AddRange(userroles);
        context.UserClaims.AddRange(userclaims);
        context.Roles.AddRange(roles);
        context.RoleClaims.AddRange(roleclaims);
        context.SaveChanges();
    }
}