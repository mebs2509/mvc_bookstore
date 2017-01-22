using Bookstore.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.Context.EntitiesConfiguration
{
    class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            ToTable("Authors");

            HasKey(a => a.AuthorId);

            Property(a => a.Name).HasMaxLength(255);
        }        
    }
}
