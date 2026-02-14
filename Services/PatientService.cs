using HMS.HospitalDb;
using HMS.Interfaces;
using HMS.Models;

namespace HMS.Services
{
    public class PatientService : IPatientService
    {
        private readonly DbHMScs _context;
        public PatientService(DbHMScs context)
        {
            _context = context;   
        }
        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }
        public Patient GetById(Guid id)
        {
            return _context.Patients.Find(id);
        }
        public Patient Create(Patient patient)
        {
            patient.Id = Guid.NewGuid();
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }
        public Patient Update(Guid id, Patient UpPat)
        {
            var exPat = _context.Patients.Find(id); 
            if (exPat == null)
            {
                return null;
            }
            exPat.Name = UpPat.Name;
            exPat.disease = UpPat.disease;
            exPat.Description = UpPat.Description;
            _context.SaveChanges();
            return exPat;

        }
        public bool Delete(Guid id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return false;
            }
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return true;
        }

    }
}
