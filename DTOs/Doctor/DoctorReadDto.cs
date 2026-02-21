namespace HospitalMangement.API.DTOs.Doctor
{
    public class DoctorReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string Qualification { get; set; }
        public int ExperienceYears { get; set; }

        public string DepartmentName { get; set; } // Relation
    }
}