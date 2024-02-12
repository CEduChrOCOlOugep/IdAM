namespace IdAM.Data
{
    public class App
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<ApplicationRole> Roles { get; set; }
    }
}