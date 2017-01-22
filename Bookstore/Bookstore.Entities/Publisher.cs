using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Entities
{
    public class Publisher
    {

        public Publisher()
        {
            Books = new List<Book>();
        }

         public List<Book> Books { get; set; }
        
        public int PublisherId { get; set; }

        [DisplayName("Publisher")]
        public string Name { get; set; }

        [DisplayName("Contact")]
        public string ContactName { get; set; }
    }
}
