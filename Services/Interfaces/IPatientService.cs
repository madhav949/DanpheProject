using HospitalMangement.API.DTOs.Patient;

namespace HospitalMangement.API.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientReadDto>> GetAllAsync();
        Task<PatientReadDto> GetByIdAsync(int id);
        Task<PatientReadDto> CreateAsync(PatientCreateDto dto);
        Task<bool> UpdateAsync(int id, PatientUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}