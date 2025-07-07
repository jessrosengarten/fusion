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

        // Endpoint to get the status of the ticket (by its id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketStatus(int id) {
            // Look up the ticket and include the status from the Lookup table
            var ticket = await _context.Tickets
                .Include(t => t.StatusLookup) 
                .FirstOrDefaultAsync(t => t.TicketID == id);

            // If the ticket wasn't found, return a 404 response
            if (ticket == null)
            {
                return NotFound(new { Message = $"Ticket with ID {id} not found." });
            }

            // If the ticket is found, return the ticket ID and status
            var result = new
            {
                TicketID = ticket.TicketID,
                Status = ticket.StatusLookup?.Value ?? "Unknown" // If no status is found, return "Unknown"
            };

            return Ok(result);
        }
    }
}
