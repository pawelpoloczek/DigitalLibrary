using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;

namespace DigitalLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
        private readonly DigitalLibraryAPIContext _context;

        public FormatController(DigitalLibraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/Format
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Format>>> GetFormat()
        {
            if (_context.Format == null)
            {
                return NotFound();
            }
            return await _context.Format.ToListAsync();
        }

        // GET: api/Format/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Format>> GetFormat(int id)
        {
            if (_context.Format == null)
            {
                return NotFound();
            }
            var format = await _context.Format.FindAsync(id);

            if (format == null)
            {
                return NotFound();
            }

            return format;
        }

        // PUT: api/Format/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormat(int id, Format format)
        {
            if (id != format.Id)
            {
                return BadRequest();
            }

            _context.Entry(format).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormatExists(id))
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

        // POST: api/Format
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Format>> PostFormat(Format format)
        {
            if (_context.Format == null)
            {
                return Problem("Entity set 'DigitalLibraryAPIContext.Format'  is null.");
            }
            _context.Format.Add(format);
            await _context.SaveChangesAsync();

            return Ok(format);
        }

        // DELETE: api/Format/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormat(int id)
        {
            if (_context.Format == null)
            {
                return NotFound();
            }
            var format = await _context.Format.FindAsync(id);
            if (format == null)
            {
                return NotFound();
            }

            _context.Format.Remove(format);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormatExists(int id)
        {
            return (_context.Format?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
