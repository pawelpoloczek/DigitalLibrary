using System.ComponentModel.DataAnnotations;

namespace DigitalLibraryAPI.Models
{
    public class PublicationAuthor
    {
        public int IdPublication { get; set; }
        public virtual Publication ?Publication { get; set; }
 
        public int IdAuthor { get; set; }
        public virtual Author ?Author { get; set; }

    }
}
