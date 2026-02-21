namespace HospitalMangement.API.DTOs.Appointment
{
    public class AppointmentReadDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

        public string DoctorName { get; set; }   // Doctor.User.FullName
        public string PatientName { get; set; }  // Patient.User.FullName
    }
}