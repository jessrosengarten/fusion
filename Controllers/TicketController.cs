using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketStatusAPI.Data;
using TicketStatusAPI.Models;

namespace TicketStatusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TicketController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ticket
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketStatus(int id) { 
            var ticket = await _context.Tickets
                .Include(t => t.StatusLookup) // Include the related Lookup entity
                .FirstOrDefaultAsync(t => t.TicketID == id);

            if (ticket == null)
            {
                return NotFound();
            }
            var result = new
            {
                TicketID = ticket.TicketID,
                Status = ticket.StatusLookup?.Value ?? "Unknown" // Use the Value from Lookup, or "Unknown" if null
            };

            return Ok(result); // Return the Lookup entity associated with the ticket
        }
    }
}
