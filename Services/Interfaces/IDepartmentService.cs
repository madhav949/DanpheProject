
using HospitalMangement.API.DTOs.Departments;
namespace HospitalMangement.API.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentReadDto>> GetAllAsync();
        Task<DepartmentReadDto> GetByIdAsync(int id);
        Task<DepartmentReadDto> CreateAsync(DepartmentCreateDto dto);
        Task<bool> UpdateAsync(int id, DepartmentUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
