namespace HospitalMangement.API.Models;

public class Appointment
{
    public int Id { get; set; }
    public int DoctorId {  get; set; }
    public int PatientId {  get; set; }

    public DateTime AppointmentDate { get; set; }
    public AppointmentTypes Status { get; set; } = AppointmentTypes.Pending;

    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }    
}
public enum AppointmentTypes
{
    Pending,
    Cancelled,
    Approved
}
