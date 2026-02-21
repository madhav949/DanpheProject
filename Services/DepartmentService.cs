using HospitalMangement.API.Data;
using HospitalMangement.API.DTOs.Departments;
using HospitalMangement.API.Models;
using HospitalMangement.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalMangement.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HospitalDbContext _context;

        public DepartmentService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentReadDto>> GetAllAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return departments.Select(d => new DepartmentReadDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            });
        }

        public async Task<DepartmentReadDto> GetByIdAsync(int id)
        {
            var d = await _context.Departments.FindAsync(id);
            if (d == null) return null;

            return new DepartmentReadDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            };
        }

        public async Task<DepartmentReadDto> CreateAsync(DepartmentCreateDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return new DepartmentReadDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };
        }

        public async Task<bool> UpdateAsync(int id, DepartmentUpdateDto dto)
        {
            var d = await _context.Departments.FindAsync(id);
            if (d == null) return false;

            d.Name = dto.Name;
            d.Description = dto.Description;

            _context.Departments.Update(d);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var d = await _context.Departments.FindAsync(id);
            if (d == null) return false;

            _context.Departments.Remove(d);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
