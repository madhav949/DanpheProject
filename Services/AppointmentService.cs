using HMS.HospitalDb;
using HMS.Models;

namespace HMS.Services
{
    public class AppointmentService
    {
        private readonly DbHMScs _context;
        public AppointmentService(DbHMScs context)
        {
            _context = context;
        }
        public List<Appointment> GetAll() {
            return _context.Appointments.Where(a => !a.IsDeleted).ToList();
        }
        public Appointment GetById(Guid id)
        {
            return _context.Appointments.Find(id);
        }
        public Appointment Book(Appointment appointment)
        {
            appointment.Id = Guid.NewGuid();
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }
        public bool Delete(Guid id)
        {
            var appointment = _context.Appointments.Find(id);
            if(appointment == null) return false;
            appointment.IsDeleted = true;
            return true;
        }
    }
}
