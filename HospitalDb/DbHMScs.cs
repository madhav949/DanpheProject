using HMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.HospitalDb
{
    public class DbHMScs : DbContext
    {
        public DbHMScs(DbContextOptions<DbHMScs> options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
