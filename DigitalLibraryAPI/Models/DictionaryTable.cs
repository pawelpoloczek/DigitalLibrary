using System.ComponentModel.DataAnnotations;

namespace DigitalLibraryAPI.Models
{
    public class DictionaryTable: BaseDatabase
    {
        [Required(ErrorMessage = "This element should have a name.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
