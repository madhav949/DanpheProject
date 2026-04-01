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
                                             .Include(a => a.Patient)
                                             .ToListAsync();

            return appointments.Select(a => new AppointmentReadDto
            {
                Id = a.Id,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                AppointmentDate = a.AppointmentDate,
                DoctorName = a.Doctor?.DocFullName,
                PatientName = a.Patient?.FullName
            });
        }

        public async Task<AppointmentReadDto> GetByIdAsync(int id)
        {
            var a = await _context.Appointments
                                  .Include(a => a.Doctor)
                                  .Include(a => a.Patient)
                                  .FirstOrDefaultAsync(x => x.Id == id);

            if (a == null) return null;

            return new AppointmentReadDto
            {
                Id = a.Id,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                Status = a.Status,
                AppointmentDate = a.AppointmentDate,
                DoctorName = a.Doctor?.DocFullName,
                PatientName = a.Patient?.FullName
            };
        }

        public async Task<AppointmentReadDto> CreateAsync(AppointmentCreateDto dto)
        {
            var appointment = new Appointment
            {
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                AppointmentDate = dto.AppointmentDate,
                
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            var doctor = await _context.Doctors
                                               .FirstOrDefaultAsync(d => d.Id == dto.DoctorId);
            var patient = await _context.Patients
                                                 .FirstOrDefaultAsync(p => p.Id == dto.PatientId);

            return new AppointmentReadDto
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                AppointmentDate = appointment.AppointmentDate,
                DoctorName = doctor?.DocFullName,
                PatientName = patient?.FullName
            };
        }

        public async Task<AppointmentReadDto> UpdateAsync(int id, AppointmentUpdateDto dto)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            

            appointment.AppointmentDate = dto.AppointmentDate;



            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();

            var updateAppointment = new AppointmentReadDto
            {
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status

            };
            return updateAppointment;
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