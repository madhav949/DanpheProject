using HospitalMangement.API.Data;
using HospitalMangement.API.DTOs.Patient;
using HospitalMangement.API.Models;
using HospitalMangement.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalMangement.API.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalDbContext _context;

        public PatientService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientReadDto>> GetAllAsync()
        {
            var patients = await _context.Patients.Include(p => p.User).ToListAsync();
            return patients.Select(p => new PatientReadDto
            {
                Id = p.Id,
                UserId = p.UserId,
                Gender = p.Gender,
                Address = p.Address,
                DateOfAdmit = p.DateOfAdmit,
                UserFullName = p.User?.FullName,
                UserEmail = p.User?.Email
            });
        }

        public async Task<PatientReadDto> GetByIdAsync(int id)
        {
            var p = await _context.Patients.Include(p => p.User)
                                           .FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) return null;

            return new PatientReadDto
            {
                Id = p.Id,
                UserId = p.UserId,
                Gender = p.Gender,
                Address = p.Address,
                DateOfAdmit = p.DateOfAdmit,
                UserFullName = p.User?.FullName,
                UserEmail = p.User?.Email
            };
        }

        public async Task<PatientReadDto> CreateAsync(PatientCreateDto dto)
        {
            var patient = new Patient
            {
                UserId = dto.UserId,
                Gender = dto.Gender,
                Address = dto.Address,
                DateOfAdmit = dto.DateOfAdmit
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var user = await _context.Users.FindAsync(dto.UserId);

            return new PatientReadDto
            {
                Id = patient.Id,
                UserId = patient.UserId,
                Gender = patient.Gender,
                Address = patient.Address,
                DateOfAdmit = patient.DateOfAdmit,
                UserFullName = user?.FullName,
                UserEmail = user?.Email
            };
        }

        public async Task<bool> UpdateAsync(int id, PatientUpdateDto dto)
        {
            var p = await _context.Patients.FindAsync(id);
            if (p == null) return false;

            p.Gender = dto.Gender;
            p.Address = dto.Address;

            _context.Patients.Update(p);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = await _context.Patients.FindAsync(id);
            if (p == null) return false;

            _context.Patients.Remove(p);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}