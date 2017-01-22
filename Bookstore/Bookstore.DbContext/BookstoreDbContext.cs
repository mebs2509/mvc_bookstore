using Bookstore.Entities;
using System.Data.Entity;
using Bookstore.Context.EntitiesConfiguration;

namespace Bookstore.Context
{
    public class BookstoreDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<BookLevel> BookLevels { get; set; }

        public DbSet<BookState> BookStates { get; set; }

        public DbSet<BookCover> BookCovers { get; set; }

        public DbSet<BookFormat> BookFormats { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Publisher> Publishers { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Configurations.Add(new AuthorConfiguration());

            modelBuilder.Configurations.Add(new BookLevelConfiguration());

            modelBuilder.Configurations.Add(new BookStateConfiguration());

            modelBuilder.Configurations.Add(new BookCoverConfiguration());

            modelBuilder.Configurations.Add(new BookFormatConfiguration());

            modelBuilder.Configurations.Add(new LanguageConfiguration());

            modelBuilder.Configurations.Add(new PublisherConfiguration());

            modelBuilder.Configurations.Add(new TagConfiguration());

            modelBuilder.Configurations.Add(new BookConfiguration());
        }
    }
}
