using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalLibraryAPI.Models
{
    public class Publication: BaseDatabase
    {
        public string Title { get; set; }
        public string Language { get; set; }
        /* status false - niedostępny, true - dostepny */
        public bool Status { get; set; }
        public int PublicationYear { get; set; }
        public virtual ICollection<PublicationAuthor> PublicationAuthors { get; set; }
        public int IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Category Category { get; set; }
        public int? IdLector { get; set; }
        [ForeignKey("IdLector")]
        public virtual Lector? Lector { get; set; }
        public int IdPublishingHouse { get; set; }
        [ForeignKey("IdPublishingHouse")]
        public virtual PublishingHouse PublishingHouse { get; set; }
        public int IdPublicationType { get; set; }
        [ForeignKey("IdPublicationType")]
        public virtual PublicationType PublicationType { get; set; }
        public int IdFormat { get; set; }
        [ForeignKey("IdFormat")]
        public virtual Format Format { get; set; }
        public int? IdBorrower { get; set; }
        [ForeignKey("IdBorrower")]
        public virtual Borrower? Borrower { get; set; }
    }
}
