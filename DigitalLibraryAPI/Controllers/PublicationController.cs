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
    public class PublicationController : ControllerBase
    {
        private readonly DigitalLibraryAPIContext _context;

        public PublicationController(DigitalLibraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/Publication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicationViewModel>>> GetPublication()
        {
            if (_context.Publication == null)
            {
                return NotFound();
            }

            var publicationList = await _context.Publication.ToListAsync();
            var publicationViewList = new Collection<PublicationViewModel>();

            foreach (var publication in publicationList)
            {
                var publicationAuthorViewModels = new Collection<AuthorForPublicationViewModel>();
                var publicationAuthors = publication.PublicationAuthors;
                if (null != publicationAuthors)
                {
                    foreach (var publicationAuthor in publicationAuthors.ToList())
                    {
                        if (_context.Author == null)
                        {
                            continue;
                        }

                        var author = _context.Author.Find(publicationAuthor.IdAuthor);
                        if (null == author)
                        {
                            continue;
                        }

                        var authorView = new AuthorForPublicationViewModel
                        {
                            Id = author.Id,
                            Name = author.Name,
                            Surname = author.Surname,
                        };

                        publicationAuthorViewModels.Add(authorView);
                    }
                }

                LectorForPublicationViewModel? lectorForPublication = null;
                if (null != publication.Lector)
                {
                    lectorForPublication = new LectorForPublicationViewModel
                    {
                        Id = publication.Lector.Id,
                        Name = publication.Lector.Name,
                        Surname = publication.Lector.Surname,
                    };
                }

                BorrowerForPublicationViewModel? borrowerForPublication = null;
                if (null != publication.Borrower)
                {
                    borrowerForPublication = new BorrowerForPublicationViewModel
                    {
                        Id = publication.Borrower.Id,
                        Name = publication.Borrower.Name,
                        Surname = publication.Borrower.Surname,
                    };
                }

                var publicationViewModel = new PublicationViewModel
                {
                    Id = publication.Id,
                    IsActive = publication.IsActive,
                    CreatedDate = publication.CreatedDate,
                    ModifiedDate = publication.ModifiedDate,
                    Title = publication.Title,
                    Language = publication.Language,
                    Status = publication.Status,
                    PublicationYear = publication.PublicationYear,
                    Authors = publicationAuthorViewModels,
                    Category = new CategoryForPublicationViewModel
                    {
                        Id = publication.Category.Id,
                        Name = publication.Category.Name,
                    },
                    Lector = lectorForPublication,
                    PublishingHouse = new PublishingHouseForPublicationViewModel
                    {
                        Id = publication.PublishingHouse.Id,
                        Name = publication.PublishingHouse.Name,
                    },
                    PublicationType = new PublicationTypeForPublicationViewModel
                    {
                        Id = publication.PublicationType.Id,
                        Name = publication.PublicationType.Name,
                    },
                    Format = new FormatForPublicationViewModel
                    {
                        Id = publication.Format.Id,
                        Name = publication.Format.Name,
                    },
                    Borrower = borrowerForPublication,
                };


                publicationViewList.Add(publicationViewModel);
            }

            return publicationViewList;
        }

        // GET: api/Publication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicationViewModel>> GetPublication(int id)
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

            var publicationAuthorViewModels = new Collection<AuthorForPublicationViewModel>();
            var publicationAuthors = publication.PublicationAuthors;
            if (null != publicationAuthors)
            {
                foreach (var publicationAuthor in publicationAuthors.ToList())
                {
                    if (_context.Author == null)
                    {
                        continue;
                    }

                    var author = _context.Author.Find(publicationAuthor.IdAuthor);
                    if (null == author)
                    {
                        continue;
                    }

                    var authorView = new AuthorForPublicationViewModel
                    {
                        Id = author.Id,
                        Name = author.Name,
                        Surname = author.Surname,
                    };

                    publicationAuthorViewModels.Add(authorView);
                }
            }

            LectorForPublicationViewModel? lectorForPublication = null;
            if (null != publication.Lector)
            {
                lectorForPublication = new LectorForPublicationViewModel
                {
                    Id = publication.Lector.Id,
                    Name = publication.Lector.Name,
                    Surname = publication.Lector.Surname,
                };
            }

            BorrowerForPublicationViewModel? borrowerForPublication = null;
            if (null != publication.Borrower)
            {
                borrowerForPublication = new BorrowerForPublicationViewModel
                {
                    Id = publication.Borrower.Id,
                    Name = publication.Borrower.Name,
                    Surname = publication.Borrower.Surname,
                };
            }

            var publicationViewModel = new PublicationViewModel
            {
                Id = publication.Id,
                IsActive = publication.IsActive,
                CreatedDate = publication.CreatedDate,
                ModifiedDate = publication.ModifiedDate,
                Title = publication.Title,
                Language = publication.Language,
                Status = publication.Status,
                PublicationYear = publication.PublicationYear,
                Authors = publicationAuthorViewModels,
                Category = new CategoryForPublicationViewModel
                {
                    Id = publication.Category.Id,
                    Name = publication.Category.Name,
                },
                Lector = lectorForPublication,
                PublishingHouse = new PublishingHouseForPublicationViewModel
                {
                    Id = publication.PublishingHouse.Id,
                    Name = publication.PublishingHouse.Name,
                },
                PublicationType = new PublicationTypeForPublicationViewModel
                {
                    Id = publication.PublicationType.Id,
                    Name = publication.PublicationType.Name,
                },
                Format = new FormatForPublicationViewModel
                {
                    Id = publication.Format.Id,
                    Name = publication.Format.Name,
                },
                Borrower = borrowerForPublication,
            };


            return publicationViewModel;
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
