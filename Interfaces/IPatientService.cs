using HMS.Models;

namespace HMS.Interfaces
{
    public class IPatientService
    {
        List<Patient> GetAllPat();
        Patient GetById(Guid id);
        Patient Create(Patient patient);
        Patient Update(Guid id , Patient patient);
        bool Delete(Guid id);
    }
}
