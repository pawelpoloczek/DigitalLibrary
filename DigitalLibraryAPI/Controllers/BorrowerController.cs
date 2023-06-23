using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;

namespace DigitalLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerController : ControllerBase
    {
        private readonly DigitalLibraryAPIContext _context;

        public BorrowerController(DigitalLibraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/Borrower
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrower>>> GetBorrower()
        {
            if (_context.Borrower == null)
            {
                return NotFound();
            }
            return await _context.Borrower.ToListAsync();
        }

        // GET: api/Borrower/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Borrower>> GetBorrower(int id)
        {
            if (_context.Borrower == null)
            {
                return NotFound();
            }
            var borrower = await _context.Borrower.FindAsync(id);

            if (borrower == null)
            {
                return NotFound();
            }

            return borrower;
        }

        // PUT: api/Borrower/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrower(int id, Borrower borrower)
        {
            if (id != borrower.Id)
            {
                return BadRequest();
            }

            _context.Entry(borrower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowerExists(id))
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

        // POST: api/Borrower
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Borrower>> PostBorrower(Borrower borrower)
        {
            if (_context.Borrower == null)
            {
                return Problem("Entity set 'DigitalLibraryAPIContext.Borrower'  is null.");
            }
            _context.Borrower.Add(borrower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrower", new { id = borrower.Id }, borrower);
        }

        // DELETE: api/Borrower/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrower(int id)
        {
            if (_context.Borrower == null)
            {
                return NotFound();
            }
            var borrower = await _context.Borrower.FindAsync(id);
            if (borrower == null)
            {
                return NotFound();
            }

            _context.Borrower.Remove(borrower);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BorrowerExists(int id)
        {
            return (_context.Borrower?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
