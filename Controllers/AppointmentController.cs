using Microsoft.AspNetCore.Mvc;
using HMS.Models;
using HMS.HospitalDb;

namespace HMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly DbHMScs _context;

        public AppointmentController(DbHMScs context)
        {
            _context = context;
        }

        [HttpPost("book")]
        public IActionResult Book(Appointment appointment)
        {
            appointment.Id = Guid.NewGuid();
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return View(appointment);
        }

        [HttpGet]
        public IActionResult List()
        {
            var activeAppointments = _context.Appointments.Where(
                a => !a.IsDeleted).ToList();
            return View(activeAppointments);
        }


        [HttpPost("cancle/{id}")]
        public IActionResult Cancle(Guid id)
        {
            var appoint = _context.Appointments.Find(id);
            if (appoint == null) 
            return NotFound("Not Found");
            appoint.IsDeleted = true;
            _context.SaveChanges();
            return View("Appointment cancelled successfully");
        }
    }
}
