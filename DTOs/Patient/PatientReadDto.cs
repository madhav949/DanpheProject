namespace HospitalMangement.API.DTOs.Patient
{
    public class PatientReadDto
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfAdmit { get; set; }

        public string FullName { get; set; } // Relation
        public string PhoneNumber { get; set; }
        
    }
}