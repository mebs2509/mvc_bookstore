using Bookstore.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.Context.EntitiesConfiguration
{
    class BookStateConfiguration : EntityTypeConfiguration<BookState>
    {
        public BookStateConfiguration()
        {
            HasKey(bs => bs.BookStateId);

            Property(b => b.BookStateId).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(bs => bs.Description)
                .IsRequired()
                .HasMaxLength(25);
        }
    }
}
