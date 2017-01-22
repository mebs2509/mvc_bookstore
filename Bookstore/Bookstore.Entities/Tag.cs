using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Entities
{
    public class Tag
    {
        public Tag()
        {
            Books = new List<Book>();
        }

        public int TagId { get; set; }

        [DisplayName("Tag")]
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
