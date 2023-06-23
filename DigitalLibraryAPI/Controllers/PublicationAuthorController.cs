using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;

namespace DigitalLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationAuthorController : ControllerBase
    {
        private readonly DigitalLibraryAPIContext _context;

        public PublicationAuthorController(DigitalLibraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/PublicationAuthor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicationAuthor>>> GetPublicationAuthor()
        {
            if (_context.PublicationAuthor == null)
            {
                return NotFound();
            }
            return await _context.PublicationAuthor.ToListAsync();
        }

        // GET: api/PublicationAuthor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicationAuthor>> GetPublicationAuthor(int id)
        {
            if (_context.PublicationAuthor == null)
            {
                return NotFound();
            }
            var publicationAuthor = await _context.PublicationAuthor.FindAsync(id);

            if (publicationAuthor == null)
            {
                return NotFound();
            }

            return publicationAuthor;
        }

        // PUT: api/PublicationAuthor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicationAuthor(int id, PublicationAuthor publicationAuthor)
        {
            if (id != publicationAuthor.IdPublication)
            {
                return BadRequest();
            }

            _context.Entry(publicationAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationAuthorExists(id))
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

        // POST: api/PublicationAuthor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PublicationAuthor>> PostPublicationAuthor(PublicationAuthor publicationAuthor)
        {
            if (_context.PublicationAuthor == null)
            {
                return Problem("Entity set 'DigitalLibraryAPIContext.PublicationAuthor'  is null.");
            }
            _context.PublicationAuthor.Add(publicationAuthor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PublicationAuthorExists(publicationAuthor.IdPublication))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPublicationAuthor", new { id = publicationAuthor.IdPublication }, publicationAuthor);
        }

        // DELETE: api/PublicationAuthor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicationAuthor(int id)
        {
            if (_context.PublicationAuthor == null)
            {
                return NotFound();
            }
            var publicationAuthor = await _context.PublicationAuthor.FindAsync(id);
            if (publicationAuthor == null)
            {
                return NotFound();
            }

            _context.PublicationAuthor.Remove(publicationAuthor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicationAuthorExists(int id)
        {
            return (_context.PublicationAuthor?.Any(e => e.IdPublication == id)).GetValueOrDefault();
        }
    }
}
