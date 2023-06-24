using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;

namespace DigitalLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationTypeController : ControllerBase
    {
        private readonly DigitalLibraryAPIContext _context;

        public PublicationTypeController(DigitalLibraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/PublicationType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicationType>>> GetType()
        {
          if (_context.Type == null)
          {
              return NotFound();
          }
            return await _context.Type.ToListAsync();
        }

        // GET: api/PublicationType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicationType>> GetPublicationType(int id)
        {
          if (_context.Type == null)
          {
              return NotFound();
          }
            var publicationType = await _context.Type.FindAsync(id);

            if (publicationType == null)
            {
                return NotFound();
            }

            return publicationType;
        }

        // PUT: api/PublicationType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicationType(int id, PublicationType publicationType)
        {
            if (id != publicationType.Id)
            {
                return BadRequest();
            }

            _context.Entry(publicationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationTypeExists(id))
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

        // POST: api/PublicationType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PublicationType>> PostPublicationType(PublicationType publicationType)
        {
          if (_context.Type == null)
          {
              return Problem("Entity set 'DigitalLibraryAPIContext.Type'  is null.");
          }
            _context.Type.Add(publicationType);
            await _context.SaveChangesAsync();

            return Ok(publicationType);
        }

        // DELETE: api/PublicationType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicationType(int id)
        {
            if (_context.Type == null)
            {
                return NotFound();
            }
            var publicationType = await _context.Type.FindAsync(id);
            if (publicationType == null)
            {
                return NotFound();
            }

            _context.Type.Remove(publicationType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicationTypeExists(int id)
        {
            return (_context.Type?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
