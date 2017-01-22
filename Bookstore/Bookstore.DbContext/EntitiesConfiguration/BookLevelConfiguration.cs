using Bookstore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Context.EntitiesConfiguration
{
    class BookLevelConfiguration : EntityTypeConfiguration<BookLevel>
    {
        public BookLevelConfiguration()
        {
            HasKey(bs => bs.BookLevelId);

            Property(b => b.BookLevelId).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(bs => bs.Description)
                .IsRequired()
                .HasMaxLength(25);
        }
    }
}
