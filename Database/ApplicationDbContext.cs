using HMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
    }
}
