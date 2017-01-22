using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Entities
{
    public class BookState
    {
        public BookState()
        {
            Books = new List<Book>();
        }
        public byte BookStateId { get; set; }

        [DisplayName("Book State")]
        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}
