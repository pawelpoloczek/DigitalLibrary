using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;

namespace DigitalLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishingHouseController : ControllerBase
    {
        private readonly DigitalLibraryAPIContext _context;

        public PublishingHouseController(DigitalLibraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/PublishingHouse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublishingHouse>>> GetPublishingHouse()
        {
            if (_context.PublishingHouse == null)
            {
                return NotFound();
            }
            return await _context.PublishingHouse.ToListAsync();
        }

        // GET: api/PublishingHouse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublishingHouse>> GetPublishingHouse(int id)
        {
            if (_context.PublishingHouse == null)
            {
                return NotFound();
            }
            var publishingHouse = await _context.PublishingHouse.FindAsync(id);

            if (publishingHouse == null)
            {
                return NotFound();
            }

            return publishingHouse;
        }

        // PUT: api/PublishingHouse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublishingHouse(int id, PublishingHouse publishingHouse)
        {
            if (id != publishingHouse.Id)
            {
                return BadRequest();
            }

            _context.Entry(publishingHouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublishingHouseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PublishingHouse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PublishingHouse>> PostPublishingHouse(PublishingHouse publishingHouse)
        {
            if (_context.PublishingHouse == null)
            {
                return Problem("Entity set 'DigitalLibraryAPIContext.PublishingHouse'  is null.");
            }
            _context.PublishingHouse.Add(publishingHouse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublishingHouse", new { id = publishingHouse.Id }, publishingHouse);
        }

        // DELETE: api/PublishingHouse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublishingHouse(int id)
        {
            if (_context.PublishingHouse == null)
            {
                return NotFound();
            }
            var publishingHouse = await _context.PublishingHouse.FindAsync(id);
            if (publishingHouse == null)
            {
                return NotFound();
            }

            _context.PublishingHouse.Remove(publishingHouse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublishingHouseExists(int id)
        {
            return (_context.PublishingHouse?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
