using HMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        internal bool IsDelete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
