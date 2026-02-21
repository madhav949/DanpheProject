namespace HospitalMangement.API.DTOs.Patient
{
    public class PatientCreateDto
    {
        public int UserId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfAdmit { get; set; }
    }
}