using Bookstore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Context.EntitiesConfiguration
{
    class PublisherConfiguration : EntityTypeConfiguration<Publisher>
    {
        public PublisherConfiguration()
        {
            ToTable("Publishers");

            HasKey(p => p.PublisherId);

            Property(p => p.Name).HasMaxLength(100);

            Property(p => p.ContactName).HasMaxLength(100);
        }
    }
}
