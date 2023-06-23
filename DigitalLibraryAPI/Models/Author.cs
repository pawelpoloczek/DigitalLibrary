namespace DigitalLibraryAPI.Models
{
    public class Author: BaseDatabase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<PublicationAuthor> PublicationAuthors { get; set; }
    }
}
