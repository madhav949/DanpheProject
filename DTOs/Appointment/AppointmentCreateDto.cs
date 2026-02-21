namespace HospitalMangement.API.DTOs.Appointment
{
    public class AppointmentCreateDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}