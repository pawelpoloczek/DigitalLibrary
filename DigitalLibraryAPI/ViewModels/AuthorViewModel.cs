using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DigitalLibraryAPI.ViewModels
{
    public class AuthorViewModel
    {
        public virtual ICollection<PublicationForAutorViewModel> ?Publications { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Imię jest wymagane")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Surname { get; set; }
    }
}
