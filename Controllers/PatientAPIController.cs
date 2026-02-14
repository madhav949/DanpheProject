using HMS.Database;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
namespace HMS.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientAPIController(ApplicationDbContext Context)
        {
          this._context = Context;      
        }

        [HttpGet]
        public IActionResult GetAllPat()
        {
            var patients = _context.GetAllPat();
            return View(patients);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var patient = _context.GetById(id);
            if (patient == null) return NotFound();
            return View(patient);
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            var Created = _Context.Create(patient);
            return View(Created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id , Patient patient)
        {
            var updated = _context.Update(id,patient);
            if(updated == null) return NotFound();
            return View(updated);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var Del = _context.IsDelete(id);
            if (!Del) return NotFound();
            return View();
        }

    }
}
