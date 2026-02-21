using HospitalMangement.API.DTOs.Doctor;


namespace HospitalMangement.API.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorReadDto>> GetAllAsync();
        Task<DoctorReadDto> GetByIdAsync(int id);
        Task<DoctorReadDto> CreateAsync(DoctorCreateDto dto);
        Task<bool> UpdateAsync(int id, DoctorUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}