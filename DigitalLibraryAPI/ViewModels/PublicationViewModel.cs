using DigitalLibraryAPI.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalLibraryAPI.Models
{
    public class PublicationViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Language { get; set; }
        /* status false - niedostępny, true - dostepny */
        public bool Status { get; set; }
        public int PublicationYear { get; set; }
        public ICollection<AuthorForPublicationViewModel> Authors { get; set; }
        public CategoryForPublicationViewModel Category { get; set; }
        public LectorForPublicationViewModel? Lector { get; set; }
        public PublishingHouseForPublicationViewModel PublishingHouse { get; set; }
        public PublicationTypeForPublicationViewModel PublicationType { get; set; }
        public FormatForPublicationViewModel Format { get; set; }
        public virtual BorrowerForPublicationViewModel? Borrower { get; set; }
    }
}
