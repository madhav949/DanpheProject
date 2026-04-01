namespace HospitalMangement.API.DTOs.Patient
{
    public class PatientUpdateDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public string Gender { get; set; }
        public string Address { get; set; }
    }
}