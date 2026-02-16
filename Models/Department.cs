namespace HospitalMangement.API.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
}
