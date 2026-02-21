using HospitalMangement.API.DTOs.Appointment;

namespace HospitalMangement.API.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentReadDto>> GetAllAsync();
        Task<AppointmentReadDto> GetByIdAsync(int id);
        Task<AppointmentReadDto> CreateAsync(AppointmentCreateDto dto);
        Task<bool> UpdateAsync(int id, AppointmentUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}