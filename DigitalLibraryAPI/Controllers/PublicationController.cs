using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;

namespace DigitalLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly DigitalLibraryAPIContext _context;

        public PublicationController(DigitalLibraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/Publication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publication>>> GetPublication()
        {
            if (_context.Publication == null)
            {
                return NotFound();
            }
            return await _context.Publication.ToListAsync();
        }

        // GET: api/Publication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publication>> GetPublication(int id)
        {
            if (_context.Publication == null)
            {
                return NotFound();
            }
            var publication = await _context.Publication.FindAsync(id);

            if (publication == null)
            {
                return NotFound();
            }

            return publication;
        }

        // PUT: api/Publication/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublication(int id, Publication publication)
        {
            if (id != publication.Id)
            {
                return BadRequest();
            }

            _context.Entry(publication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationExists(id))
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

        // POST: api/Publication
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publication>> PostPublication(Publication publication)
        {
            if (_context.Publication == null)
            {
                return Problem("Entity set 'DigitalLibraryAPIContext.Publication'  is null.");
            }
            _context.Publication.Add(publication);
            await _context.SaveChangesAsync();

            return Ok(publication);
        }

        // DELETE: api/Publication/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublication(int id)
        {
            if (_context.Publication == null)
            {
                return NotFound();
            }
            var publication = await _context.Publication.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }

            _context.Publication.Remove(publication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicationExists(int id)
        {
            return (_context.Publication?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
