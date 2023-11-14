using _30HillsProject.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.DataAccess.Configurations
{
    public class ProductConfiguration : EntityConfiguration<Product>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(x => x.Name);
            builder.Property(x=>x.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Features).IsRequired();
            builder.Property(x => x.Keywords).IsRequired();

        }
    }
}
