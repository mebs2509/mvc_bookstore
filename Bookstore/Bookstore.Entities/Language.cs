using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Entities
{
    public class Language
    {
        public Language()
        {
            Books = new List<Book>();
        }

        public List<Book> Books { get; set; }

        [DisplayName("Language")]
        public string Description { get; set; }
        
        public int LanguageId { get; set; }

        
    }
}
