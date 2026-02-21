namespace HospitalMangement.API.DTOs.Doctor
{
    public class DoctorUpdateDto
    {
        public int DepartmentId { get; set; }
        public string Qualification { get; set; }
        public int ExperienceYears { get; set; }
    }
}