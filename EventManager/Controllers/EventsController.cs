using EventManager.Data;
using EventManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
namespace EventManager.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public EventsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index(string? category, DateTime? startDate)
        {
            List<Event> events = null;
            if (!string.IsNullOrEmpty(category))
            {
                events = dbContext.Events.Include(e => e.Category).Where(e => e.Category!.Name == category).ToList();
                
            }
            if (startDate.HasValue)
            {
                events = events.IsNullOrEmpty() 
                    ? dbContext.Events.Include(e => e.Category).Where(e => e.StartDate.Date == startDate.Value.Date).ToList()
                    : events.Where(e => e.StartDate.Date == startDate.Value.Date).ToList();
                
            }
            events = events ?? dbContext.Events.Include(e => e.Category).ToList();
            return View(events);
        }
        public IActionResult Details(int id)
        {
            var theEvent = dbContext.Events.Include(e => e.Category).Include(e => e.Registrations).FirstOrDefault(e => e.Id == id);
            return View(theEvent);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = dbContext.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Event @event)
        {
            
            dbContext.Events.Add(@event);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
