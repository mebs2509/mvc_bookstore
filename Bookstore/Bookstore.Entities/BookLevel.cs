using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Entities
{
    public class BookLevel
    {
        public BookLevel()
        {
            Books = new List<Book>();
        }

        public List<Book> Books { get; set; }

        public byte BookLevelId { get; set; }

        [DisplayName("Book Level")]
        public string Description { get; set; }

        

    }
}
