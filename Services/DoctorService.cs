using HospitalMangement.API.Data;
using HospitalMangement.API.DTOs.Doctor;
using HospitalMangement.API.Models;
using HospitalMangement.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace HospitalMangement.API.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalDbContext _context;

        public DoctorService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorReadDto>> GetAllAsync()
        {
            var doctors = await _context.Doctors.Include(d => d.Department).ToListAsync();
            return doctors.Select(d => new DoctorReadDto
            {
                Id = d.Id,
                UserId = d.UserId,
                DepartmentId = d.DepartmentId,
                Qualification = d.Qualification,
                ExperienceYears = d.ExperienceYears,
                DepartmentName = d.Department?.Name
            });
        }

        public async Task<DoctorReadDto> GetByIdAsync(int id)
        {
            var d = await _context.Doctors.Include(d => d.Department)
                                          .FirstOrDefaultAsync(x => x.Id == id);
            if (d == null) return null;

            return new DoctorReadDto
            {
                Id = d.Id,
                UserId = d.UserId,
                DepartmentId = d.DepartmentId,
                Qualification = d.Qualification,
                ExperienceYears = d.ExperienceYears,
                DepartmentName = d.Department?.Name
            };
        }

        public async Task<DoctorReadDto> CreateAsync(DoctorCreateDto dto)
        {
            var doctor = new Doctor
            {
                UserId = dto.UserId,
                DepartmentId = dto.DepartmentId,
                Qualification = dto.Qualification,
                ExperienceYears = dto.ExperienceYears
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            var department = await _context.Departments.FindAsync(dto.DepartmentId);

            return new DoctorReadDto
            {
                Id = doctor.Id,
                UserId = doctor.UserId,
                DepartmentId = doctor.DepartmentId,
                Qualification = doctor.Qualification,
                ExperienceYears = doctor.ExperienceYears,
                DepartmentName = department?.Name
            };
        }

        public async Task<bool> UpdateAsync(int id, DoctorUpdateDto dto)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return false;

            doctor.DepartmentId = dto.DepartmentId;
            doctor.Qualification = dto.Qualification;
            doctor.ExperienceYears = dto.ExperienceYears;

            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return false;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}