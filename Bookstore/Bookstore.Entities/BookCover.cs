using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Entities
{
    public class BookCover
    {
        public BookCover()
        {
            Books = new List<Book>();
        }

        public List<Book> Books { get; set; }

        [DisplayName("Book Cover")]
        public string Description { get; set; }
        
        public int BookCoverId { get; set; }

        
    }
}
