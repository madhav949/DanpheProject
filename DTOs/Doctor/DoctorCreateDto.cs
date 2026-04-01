namespace HospitalMangement.API.DTOs.Doctor
{
    public class DoctorCreateDto
    {
        public int DepartmentId { get; set; }
        public string DocFullName { get; set; }
        public string Qualification { get; set; }
        public int ExperienceYears { get; set; }
    }
}