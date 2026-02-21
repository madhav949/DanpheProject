using HospitalMangement.API.Data;
using HospitalMangement.API.DTOs.Appointment;
using HospitalMangement.API.Models;
using HospitalMangement.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalMangement.API.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HospitalDbContext _context;

        public AppointmentService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentReadDto>> GetAllAsync()
        {
            var appointments = await _context.Appointments
                                             .Include(a => a.Doctor)
                                                .ThenInclude(d => d.user)
                                             .Include(a => a.Patient)
                                                .ThenInclude(p => p.User)
                                             .ToListAsync();

            return appointments.Select(a => new AppointmentReadDto
            {
                Id = a.Id,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                DoctorName = a.Doctor?.user?.FullName,
                PatientName = a.Patient?.User?.FullName
            });
        }

        public async Task<AppointmentReadDto> GetByIdAsync(int id)
        {
            var a = await _context.Appointments
                                  .Include(a => a.Doctor).ThenInclude(d => d.user)
                                  .Include(a => a.Patient).ThenInclude(p => p.User)
                                  .FirstOrDefaultAsync(x => x.Id == id);

            if (a == null) return null;

            return new AppointmentReadDto
            {
                Id = a.Id,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                DoctorName = a.Doctor?.user?.FullName,
                PatientName = a.Patient?.User?.FullName
            };
        }

        public async Task<AppointmentReadDto> CreateAsync(AppointmentCreateDto dto)
        {
            var appointment = new Appointment
            {
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                AppointmentDate = dto.AppointmentDate,
                Status = "Pending"
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            var doctor = await _context.Doctors.Include(d => d.user)
                                               .FirstOrDefaultAsync(d => d.Id == dto.DoctorId);
            var patient = await _context.Patients.Include(p => p.User)
                                                 .FirstOrDefaultAsync(p => p.Id == dto.PatientId);

            return new AppointmentReadDto
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                DoctorName = doctor?.user?.FullName,
                PatientName = patient?.User?.FullName
            };
        }

        public async Task<bool> UpdateAsync(int id, AppointmentUpdateDto dto)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return false;

            appointment.AppointmentDate = dto.AppointmentDate;
            appointment.Status = dto.Status;

            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return false;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}