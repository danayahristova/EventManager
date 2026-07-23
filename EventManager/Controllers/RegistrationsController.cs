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
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), registration);
            }
            var @event = await dbContext.Events
                .Select(e => new { e.MaxParticipants, e.Id, RegistrationsCount = e.Registrations.Count})
                .FirstAsync(e => e.Id == registration.EventId);
            if(@event.MaxParticipants <= @event.RegistrationsCount)
            {
                ModelState.AddModelError(string.Empty, "The event is full. You cannot register for this event.");
                return View(nameof(Create), registration);
            }
            await dbContext.Registrations.AddAsync(registration);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
