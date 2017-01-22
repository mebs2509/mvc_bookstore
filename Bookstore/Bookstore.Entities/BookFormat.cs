using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Entities
{
    public class BookFormat
    {
        public BookFormat()
        {
            Books = new List<Book>();
        }

        public List<Book> Books { get; set; }

        [DisplayName("Book Format")]
        public string Description { get; set; }
        
        public int BookFormatId { get; set; }

        
    }
}
