using EventManager.Data;
using EventManager.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace EventManager.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public EventsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var events = dbContext.Events.ToList();
            return View(events);
        }
        public IActionResult Details(int id)
        {
            var theEvent = dbContext.Events.Find(id);
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
