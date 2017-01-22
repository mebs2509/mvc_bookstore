using Bookstore.Entities;
using System.Collections.Generic;

namespace Bookstore.MVC.ViewModels
{
    public class BookViewModel
    {
        public Author Author { get; set; }

        public BookState Bookstate { get; set; }

        public BookLevel BookLevel { get; set; }

        public BookLevel BookFormat { get; set; }

        public BookLevel BookCover { get; set; }

        public Language Language { get; set; }

        public Publisher Publisher { get; set; }

        public List<Tag> Tags { get; set; }

    }
}