using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;
using DigitalLibraryAPI.ViewModels;
using System.Collections.ObjectModel;

namespace DigitalLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly DigitalLibraryAPIContext _context;

        public AuthorController(DigitalLibraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorViewModel>>> GetAuthor()
        {
            if (_context.Author == null)
            {
                return NotFound();
            }

            var authorList = await _context.Author.ToListAsync();

            var authorsViewList = new Collection<AuthorViewModel>();

            foreach (var author in authorList)
            {
                var authorPublicationsView = new Collection<PublicationForAutorViewModel>();
                var authorPublications = author.PublicationAuthors;
                if (null != authorPublications)
                {
                    foreach (var authorPublication in authorPublications.ToList())
                    {
                        if (_context.Publication == null)
                        {
                            continue;
                        }

                        var publication = _context.Publication.Find(authorPublication.IdPublication);
                        if (null == publication)
                        {
                            continue;
                        }

                        var publicationView = new PublicationForAutorViewModel
                        {
                            Id = publication.Id,
                            Title = publication.Title
                        };

                        authorPublicationsView.Add(publicationView);
                    }
                }

                var authorView = new AuthorViewModel
                {
                    Id = author.Id,
                    IsActive = author.IsActive,
                    Name = author.Name,
                    CreatedDate = author.CreatedDate,
                    ModifiedDate = author.ModifiedDate,
                    Surname = author.Surname,
                    Publications = authorPublicationsView
                };

                authorsViewList.Add(authorView);
            }

            return authorsViewList;
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorViewModel>> GetAuthor(int id)
        {
            if (_context.Author == null)
            {
                return NotFound();
            }
            var author = await _context.Author.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }


            var authorPublicationsView = new Collection<PublicationForAutorViewModel>();
            var authorPublications = author.PublicationAuthors;
            if (null != authorPublications)
            {
                foreach (var authorPublication in authorPublications.ToList())
                {
                    if (_context.Publication == null)
                    {
                        continue;
                    }

                    var publication = _context.Publication.Find(authorPublication.IdPublication);
                    if (null == publication)
                    {
                        continue;
                    }

                    var publicationView = new PublicationForAutorViewModel
                    {
                        Id = publication.Id,
                        Title = publication.Title
                    };

                    authorPublicationsView.Add(publicationView);
                }
            }

            var authorView = new AuthorViewModel
            {
                Id = author.Id,
                IsActive = author.IsActive,
                Name = author.Name,
                CreatedDate = author.CreatedDate,
                ModifiedDate = author.ModifiedDate,
                Surname = author.Surname,
                Publications = authorPublicationsView
            };

            return authorView;
        }

        // PUT: api/Author/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorAddViewModel author)
        {
            var authorEntity = await _context.Author.FindAsync(id);
            if (authorEntity == null)
            {
                return NotFound();
            }

            authorEntity.Name = author.Name;
            authorEntity.Surname = author.Surname;
            authorEntity.CreatedDate = author.CreatedDate;
            authorEntity.ModifiedDate = author.ModifiedDate;
            authorEntity.IsActive = author.IsActive;

            _context.Update(authorEntity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Author
        [HttpPost]
        public async Task<ActionResult<AuthorAddViewModel>> PostAuthor(AuthorAddViewModel author)
        {
            if (_context.Author == null)
            {
                return Problem("Entity set 'DigitalLibraryAPIContext.Author'  is null.");
            }

            var authorEntity = new Author
            {
                IsActive = author.IsActive,
                Name = author.Name,
                Surname = author.Surname,
                CreatedDate = author.CreatedDate,
                ModifiedDate = author.ModifiedDate,
                PublicationAuthors = new Collection<PublicationAuthor>()
            };

            _context.Author.Add(authorEntity);
            await _context.SaveChangesAsync();

            author.Id = authorEntity.Id;

            return Ok(author);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (_context.Author == null)
            {
                return NotFound();
            }
            var author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return (_context.Author?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
