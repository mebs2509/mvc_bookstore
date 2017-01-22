using Bookstore.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Context.EntitiesConfiguration
{
    class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            ToTable("Books");

            HasKey(b => b.BookId);

            Property(b => b.BookId).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(b => b.Title)
                .HasMaxLength(255);

            Property(b => b.Description)
                .HasMaxLength(8000);

            HasRequired(b => b.Author)
                .WithMany( b => b.Books)
                .HasForeignKey( b=> b.AuthorId);

            HasRequired(b => b.BookState)
                .WithMany( bs => bs.Books)
                .HasForeignKey(b => b.BookStateId);

            HasRequired(b => b.BookLevel)
                .WithMany(bl => bl.Books)
                .HasForeignKey(b => b.BookLevelId);

            HasRequired(b => b.BookCover)
                .WithMany(bl => bl.Books)
                .HasForeignKey(b => b.BookCoverId);

            HasRequired(b => b.BookFormat)
                .WithMany(bl => bl.Books)
                .HasForeignKey(b => b.BookFormatId);

            HasRequired(b => b.Publisher)
                .WithMany(bl => bl.Books)
                .HasForeignKey(b => b.PublisherId);

            HasRequired(b => b.Language)
                .WithMany(bl => bl.Books)
                .HasForeignKey(b => b.LanguageId);

            HasMany(b => b.Tags)
                .WithMany(t => t.Books)
                .Map(m =>
                {
                    m.ToTable("BookTags");
                    m.MapLeftKey("BookId");
                    m.MapRightKey("TagId");
                });

            

        }
    }
}
