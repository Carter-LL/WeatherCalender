using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherCalender.Models.SQL.Tables;
using WeatherCalender.Services.Database;

namespace WeatherCalender.Controllers
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
        public async Task<List<PlannedEventModel>> GetAllPlannedEventsByDesktop(string desktop)
        {
            var plannedEvents = await _context.PlannedEvent
                                              .Where(pe => pe.Desktop == desktop)
                                              .ToListAsync();
            if (plannedEvents == null || !plannedEvents.Any())
            {
                return null;
            }

            return plannedEvents;
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
        [HttpPut("{desktop}/{index}")]
        public async Task<IActionResult> UpdatePlannedEvent(string desktop, PlannedEventModel currentplannedEvent, PlannedEventModel previousplannedEvent)
        {
            var plannedEvents = await _context.PlannedEvent
                                               .Where(pe => pe.Desktop == desktop).Where(pe => pe.Description == previousplannedEvent.Description)
                                               .ToListAsync();

            if (plannedEvents == null)
            {
                return NotFound();
            }

            // Get the specific planned event by the index
            var eventToUpdate = plannedEvents[0];
            Console.WriteLine(eventToUpdate.Description);

            // Remove the old event
            _context.PlannedEvent.Remove(eventToUpdate);
            await _context.SaveChangesAsync();

            // Add the new event
            _context.PlannedEvent.Add(currentplannedEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/PlannedEvents/{desktop}/{date}
        [HttpDelete("{desktop}/{date}")]
        public async Task<IActionResult> DeletePlannedEvent(PlannedEventModel plannedEventmdl)
        {
            // Find the planned event where both desktop and date match
            var plannedEvent = await _context.PlannedEvent
                                              .FirstOrDefaultAsync(pe => pe.Desktop == plannedEventmdl.Desktop && pe.Date == plannedEventmdl.Date && pe.Description == plannedEventmdl.Description);

            // If no such event is found, return NotFound
            if (plannedEvent == null)
            {
                return NotFound();
            }

            // Remove the found planned event
            _context.PlannedEvent.Remove(plannedEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("desktop/{desktop}")]
        public async Task<IActionResult> DeleteAllPlannedEventsByDesktop(string desktop)
        {
            var plannedEvents = await _context.PlannedEvent
                                              .Where(pe => pe.Desktop == desktop)
                                              .ToListAsync();

            if (plannedEvents == null || !plannedEvents.Any())
            {
                return NotFound();
            }

            _context.PlannedEvent.RemoveRange(plannedEvents);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
