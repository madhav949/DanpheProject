using HospitalMangement.API.Models;

namespace HospitalMangement.API.DTOs.Appointment
{
    public class AppointmentCreateDto
    {
        public AppointmentTypes AppointmentStatus { get; set; } = AppointmentTypes.Pending;
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}