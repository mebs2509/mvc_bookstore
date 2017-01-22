
using System.Collections.Generic;
using System.ComponentModel;

namespace Bookstore.Entities
{
    public class Book
    {
        public Book()
        {
            Tags = new HashSet<Tag>();
        }

        public int BookId { get; set; }

        public int AuthorId { get; set; }

        [DisplayName("Author")]
        public Author Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public byte BookLevelId { get; set; }

        [DisplayName("Book Level")]
        public BookLevel BookLevel { get; set; }

        public byte BookStateId { get; set; }

        [DisplayName("Book State")]
        public BookState BookState { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public int PageNumbers { get; set; }

        public int BookCoverId { get; set; }

        [DisplayName("Book Cover")]
        public BookCover BookCover { get; set; }

        public int BookFormatId { get; set; }


        [DisplayName("Book Format")]
        public BookFormat BookFormat { get; set; }

        public int PublisherId { get; set; }

        [DisplayName("Publisher")]
        public Publisher Publisher { get; set; }

        public int LanguageId { get; set; }

        [DisplayName("Language")]
        public Language Language { get; set; }

        public string ISBN10 { get; set; }

        public string ISBB13 { get; set; }

        public string Dimensions { get; set; }

        public decimal Weight { get; set; }

        public decimal ReviewRate { get; set; }

        public int RankTop100 { get; set; }

        public int StockMin { get; set; }

        public int Stock { get; set; }
    }
}
