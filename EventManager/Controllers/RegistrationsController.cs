using EventManager.Data;
using EventManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public RegistrationsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var registrations = dbContext.Registrations.ToList();

            return View(registrations);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int eventId)
        {

            var registration = new Registration { EventId = eventId };
            return View(registration);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                return View(nameof(Create));
            }
            
            await dbContext.Registrations.AddAsync(registration);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
