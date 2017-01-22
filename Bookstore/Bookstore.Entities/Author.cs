
using System.Collections.Generic;
using System.ComponentModel;

namespace Bookstore.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public int AuthorId { get; set; }

        [DisplayName("Author")]
        public string Name { get; set; }

        public List<Book> Books { get; set; }

    }
}
