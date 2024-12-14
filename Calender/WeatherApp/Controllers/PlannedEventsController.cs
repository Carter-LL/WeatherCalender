using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Models.SQL.Tables;
using WeatherApp.Services.Database;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlannedEventsController : ControllerBase
    {
        private readonly PlannedEventContext _context;

        // Inject the DbContext via constructor
        public PlannedEventsController(PlannedEventContext context)
        {
            _context = context;
        }

        // GET: api/PlannedEvents
        [HttpGet]
        public async Task<IActionResult> GetPlannedEvents()
        {
            var plannedEventsList = await _context.PlannedEvent.ToListAsync();
            return Ok(plannedEventsList);
        }

        // GET: api/PlannedEvents/{desktop}
        [HttpGet("{desktop}")]
        public async Task<IActionResult> GetPlannedEvent(string desktop)
        {
            var plannedEvent = await _context.PlannedEvent
                                              .FirstOrDefaultAsync(pe => pe.Desktop == desktop);
            if (plannedEvent == null)
            {
                return NotFound();
            }

            return Ok(plannedEvent);
        }

        // New GET: api/PlannedEvents/desktop/{desktop}
        [HttpGet("desktop/{desktop}")]
        public async Task<IActionResult> GetAllPlannedEventsByDesktop(string desktop)
        {
            var plannedEvents = await _context.PlannedEvent
                                              .Where(pe => pe.Desktop == desktop)
                                              .ToListAsync();
            if (plannedEvents == null || !plannedEvents.Any())
            {
                return NotFound();
            }

            return Ok(plannedEvents);
        }

        // POST: api/PlannedEvents
        [HttpPost]
        public async Task<IActionResult> CreatePlannedEvent(PlannedEventModel plannedEvent)
        {
            _context.PlannedEvent.Add(plannedEvent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlannedEvent), new { desktop = plannedEvent.Desktop }, plannedEvent);
        }

        // PUT: api/PlannedEvents/{desktop}
        [HttpPut("{desktop}")]
        public async Task<IActionResult> UpdatePlannedEvent(string desktop, PlannedEventModel plannedEvent)
        {
            if (desktop != plannedEvent.Desktop)
            {
                return BadRequest();
            }

            _context.Entry(plannedEvent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/PlannedEvents/{desktop}
        [HttpDelete("{desktop}")]
        public async Task<IActionResult> DeletePlannedEvent(string desktop)
        {
            var plannedEvent = await _context.PlannedEvent.FindAsync(desktop);
            if (plannedEvent == null)
            {
                return NotFound();
            }

            _context.PlannedEvent.Remove(plannedEvent);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
