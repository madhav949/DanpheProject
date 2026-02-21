namespace HospitalMangement.API.DTOs.Doctor
{
    public class DoctorCreateDto
    {
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string Qualification { get; set; }
        public int ExperienceYears { get; set; }
    }
}