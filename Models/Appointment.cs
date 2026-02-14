namespace HMS.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId {  get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
