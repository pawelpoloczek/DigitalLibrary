using DigitalLibraryAPI.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalLibraryAPI.Models
{
    public class PublicationAddViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Language { get; set; }
        public bool Status { get; set; }
        public int PublicationYear { get; set; }
        public ICollection<int> AuthorIds { get; set; }
        public int CategoryId { get; set; }
        public int? LectorId { get; set; }
        public int PublishingHouseId { get; set; }
        public int PublicationTypeId { get; set; }
        public int FormatId { get; set; }
        public int? BorrowerId { get; set; }
    }
}
