namespace HospitalMangement.API.Models;

public class Doctor
{
    public int Id { get; set; }
    public int DepartmentId {  get; set; }
    public string DocFullName { get; set; }

    public string Qualification { get; set; }
    public int ExperienceYears {  get; set; }

    public Department Department { get; set; }
}
