using Bookstore.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.Context.EntitiesConfiguration
{
    class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            ToTable("Tags");

            HasKey(t => t.TagId);

            Property(t => t.Name).HasMaxLength(50);
        }
    }
}
