namespace HospitalMangement.API.Models;

public class Doctor
{
    public int Id { get; set; }
    public int UserId {  get; set; }
    public int DepartmentId {  get; set; }

    public string Qualification { get; set; }
    public int ExperienceYears {  get; set; }

    public User user { get; set; }
    public Department Department { get; set; }
}
