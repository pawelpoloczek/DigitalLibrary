using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;
using DigitalLibraryAPI.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

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
            if (false == contextsExists())
            {
                return Problem("Entity set 'DigitalLibraryAPIContext'  has missing context.");
            }

            var publicationList = await _context.Publication.ToListAsync();
            var publicationViewList = new Collection<PublicationViewModel>();

            foreach (var publication in publicationList)
            {
                var publicationAuthorViewModels = new Collection<AuthorForPublicationViewModel>();
                var publicationAuthors = _context.PublicationAuthor.Where(p => p.IdPublication == publication.Id);
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
                if (null != publication.IdLector)
                {
                    var lector = _context.Lector.Find(publication.IdLector);
                    if (null != lector)
                    {
                        lectorForPublication = new LectorForPublicationViewModel
                        {
                            Id = lector.Id,
                            Name = lector.Name,
                            Surname = lector.Surname,
                        };
                    }
                }

                BorrowerForPublicationViewModel? borrowerForPublication = null;
                if (null != publication.IdBorrower)
                {
                    var borrower = _context.Borrower.Find(publication.IdBorrower);
                    if (null != borrower)
                    {
                        borrowerForPublication = new BorrowerForPublicationViewModel
                        {
                            Id = borrower.Id,
                            Name = borrower.Name,
                            Surname = borrower.Surname,
                        };
                    }
                }

                var category = _context.Category.Find(publication.IdCategory);
                var publishingHouse = _context.PublishingHouse.Find(publication.IdPublishingHouse);
                var publicationType = _context.Type.Find(publication.IdPublicationType);
                var format = _context.Format.Find(publication.IdFormat);

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
                        Id = category.Id,
                        Name = category.Name,
                    },
                    Lector = lectorForPublication,
                    PublishingHouse = new PublishingHouseForPublicationViewModel
                    {
                        Id = publishingHouse.Id,
                        Name = publishingHouse.Name,
                    },
                    PublicationType = new PublicationTypeForPublicationViewModel
                    {
                        Id = publicationType.Id,
                        Name = publicationType.Name,
                    },
                    Format = new FormatForPublicationViewModel
                    {
                        Id = format.Id,
                        Name = format.Name,
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
            if (false == contextsExists())
            {
                return Problem("Entity set 'DigitalLibraryAPIContext'  has missing context.");
            }

            var publication = _context.Publication.Find(id);

            if (publication == null)
            {
                return NotFound();
            }

            var publicationAuthorViewModels = new Collection<AuthorForPublicationViewModel>();
            var publicationAuthors = _context.PublicationAuthor.Where(p => p.IdPublication == publication.Id);
            if (null != publicationAuthors)
            {
                foreach (var publicationAuthor in publicationAuthors.ToList())
                {
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

            var category = _context.Category.Find(publication.IdCategory);
            var publishingHouse = _context.PublishingHouse.Find(publication.IdPublishingHouse);
            var publicationType = _context.Type.Find(publication.IdPublicationType);
            var format = _context.Format.Find(publication.IdFormat);

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
                    Id = category.Id,
                    Name = category.Name,
                },
                Lector = lectorForPublication,
                PublishingHouse = new PublishingHouseForPublicationViewModel
                {
                    Id = publishingHouse.Id,
                    Name = publishingHouse.Name,
                },
                PublicationType = new PublicationTypeForPublicationViewModel
                {
                    Id = publicationType.Id,
                    Name = publicationType.Name,
                },
                Format = new FormatForPublicationViewModel
                {
                    Id = format.Id,
                    Name = format.Name,
                },
                Borrower = borrowerForPublication,
            };


            return publicationViewModel;
        }

        // PUT: api/Publication/5
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
        [HttpPost]
        public async Task<ActionResult<PublicationAddViewModel>> PostPublication(PublicationAddViewModel publication)
        {
            if (false == contextsExists())
            {
                return Problem("Entity set 'DigitalLibraryAPIContext'  has missing context.");
            }

            var category = _context.Category.Find(publication.CategoryId);
            if (category == null)
            {
                return NotFound("Category not found.");
            }

            Lector? lector = null;
            int? idLector = null;
            if (publication.LectorId != null)
            {
                lector = _context.Lector.Find(publication.LectorId);
                if (lector != null)
                {
                    idLector = lector.Id;
                }
            }

            var publishingHouse = _context.PublishingHouse.Find(publication.PublishingHouseId);
            if (publishingHouse == null)
            {
                return NotFound("Publishing house not found.");
            }

            var publicationType = _context.Type.Find(publication.PublicationTypeId);
            if (publicationType == null)
            {
                return NotFound("Publication type not found.");
            }

            var format = _context.Format.Find(publication.FormatId);
            if (format == null)
            {
                return NotFound("Format not found.");
            }

            Borrower? borrower = null;
            int? idBorrower = null;
            if (publication.BorrowerId != null)
            {
                borrower = _context.Borrower.Find(publication.BorrowerId);
                if (borrower != null)
                {
                    idBorrower = borrower.Id;
                }
            }

            var publicationEntity = new Publication
            {
                IsActive = publication.IsActive,
                CreatedDate = publication.CreatedDate,
                ModifiedDate = publication.ModifiedDate,
                Title = publication.Title,
                Language = publication.Language,
                Status = publication.Status,
                PublicationYear = publication.PublicationYear,
                PublicationAuthors = new Collection<PublicationAuthor>(),
                Category = category,
                IdCategory = category.Id,
                Lector = lector,
                IdLector = idLector,
                PublishingHouse = publishingHouse,
                IdPublishingHouse = publishingHouse.Id,
                PublicationType = publicationType,
                IdPublicationType = publicationType.Id,
                Format = format,
                IdFormat = format.Id,
                Borrower = borrower,
                IdBorrower = idBorrower,
            };

            _context.Publication.Add(publicationEntity);
            await _context.SaveChangesAsync();


            var publicationAuthors = new Collection<PublicationAuthor>();
            if (publication.AuthorIds.Any())
            {
                foreach (var authorId in publication.AuthorIds)
                {
                    var author = _context.Author.Find(authorId);
                    if (author == null)
                    {
                        continue;
                    }

                    publicationAuthors.Add(new PublicationAuthor
                    {
                        Author = author,
                        IdAuthor = author.Id,
                        Publication = publicationEntity,
                        IdPublication = publicationEntity.Id,
                    });
                }
            }

            publicationEntity.PublicationAuthors = publicationAuthors;
            _context.Update(publicationEntity);
            await _context.SaveChangesAsync();

            publication.Id = publicationEntity.Id;

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

        private bool contextsExists()
        {
            if (_context.Publication == null || _context.Category == null || _context.Lector == null
                || _context.PublishingHouse == null || _context.Type == null || _context.Format == null
                || _context.Borrower == null || _context.Author == null || _context.PublicationAuthor == null)
            {
                return false;
            }

            return true;
        }
    }
}
