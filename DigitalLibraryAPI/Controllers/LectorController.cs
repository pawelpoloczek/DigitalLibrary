using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;

namespace DigitalLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorController : ControllerBase
    {
        private readonly DigitalLibraryAPIContext _context;

        public LectorController(DigitalLibraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/Lector
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lector>>> GetLector()
        {
            if (_context.Lector == null)
            {
                return NotFound();
            }
            return await _context.Lector.ToListAsync();
        }

        // GET: api/Lector/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lector>> GetLector(int id)
        {
            if (_context.Lector == null)
            {
                return NotFound();
            }
            var lector = await _context.Lector.FindAsync(id);

            if (lector == null)
            {
                return NotFound();
            }

            return lector;
        }

        // PUT: api/Lector/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLector(int id, Lector lector)
        {
            if (id != lector.Id)
            {
                return BadRequest();
            }

            _context.Entry(lector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectorExists(id))
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

        // POST: api/Lector
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lector>> PostLector(Lector lector)
        {
            if (_context.Lector == null)
            {
                return Problem("Entity set 'DigitalLibraryAPIContext.Lector'  is null.");
            }
            _context.Lector.Add(lector);
            await _context.SaveChangesAsync();

            return Ok(lector);
        }

        // DELETE: api/Lector/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLector(int id)
        {
            if (_context.Lector == null)
            {
                return NotFound();
            }
            var lector = await _context.Lector.FindAsync(id);
            if (lector == null)
            {
                return NotFound();
            }

            _context.Lector.Remove(lector);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LectorExists(int id)
        {
            return (_context.Lector?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
