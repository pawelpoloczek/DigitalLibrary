using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DigitalLibraryAPI.ViewModels
{
    public class BorrowerForPublicationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
