namespace HospitalMangement.API.DTOs.Patient
{
    public class PatientReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfAdmit { get; set; }

        public string UserFullName { get; set; } // Relation
        public string UserEmail { get; set; }
    }
}