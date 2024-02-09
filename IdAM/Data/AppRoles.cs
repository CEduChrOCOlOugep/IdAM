namespace IdAM.Data
{
    public class AppRole
    {
        public string RoleId { get; set; }
        public ApplicationRole Role { get; set; }

        public int AppId { get; set; }
        public App App { get; set; }

        public ICollection<AppRoleClaim> RoleClaims { get; set; }
    }
}