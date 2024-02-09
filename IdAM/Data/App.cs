namespace IdAM.Data;

public class App
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserApplication> UserApplications { get; set; }
    public ICollection<AppRole> AppRoles { get; set; }
    
}