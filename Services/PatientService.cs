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
            var patients = await _context.Patients.ToListAsync();
            return patients.Select(p => new PatientReadDto
            {
                Id = p.Id,

                Gender = p.Gender,
                Address = p.Address,
                DateOfAdmit = p.DateOfAdmit,
                FullName = p.FullName,
                PhoneNumber = p.PhoneNumber
            });
            
        }

        public async Task<PatientReadDto> GetByIdAsync(int id)
        {
            var p = await _context.Patients.FirstOrDefaultAsync(e => e.Id == id);
            if (p == null) return null;

            return new PatientReadDto
            { 
                Gender = p.Gender,
                Address = p.Address,
                DateOfAdmit = p.DateOfAdmit,
                FullName = p.FullName,
                PhoneNumber = p.PhoneNumber
            };
            
        }

        public async Task<PatientReadDto> CreateAsync(PatientCreateDto dto)
        {
            var patient = new Patient
            {
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender,
                Address = dto.Address,
                DateOfAdmit = dto.DateOfAdmit
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var user = await _context.Patients.FindAsync(patient.Id);

            return new PatientReadDto
            {
                Id = patient.Id,
                Gender = patient.Gender,
                Address = patient.Address,
                DateOfAdmit = patient.DateOfAdmit,
                FullName = user?.FullName,
                PhoneNumber = patient.PhoneNumber
            };
          
        }

        public async Task<bool> UpdateAsync(int id, PatientUpdateDto dto)
        {
            var p = await _context.Patients.FindAsync(id);
            if (p == null) return false;
            p.FullName = dto.FullName;
            p.PhoneNumber = dto.PhoneNumber;
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