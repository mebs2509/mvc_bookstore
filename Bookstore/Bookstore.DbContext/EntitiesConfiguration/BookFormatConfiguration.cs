using Bookstore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Context.EntitiesConfiguration
{
    class BookFormatConfiguration : EntityTypeConfiguration<BookFormat>
    {
        public BookFormatConfiguration()
        {
            HasKey(bl => bl.BookFormatId);

            Property(bl => bl.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
