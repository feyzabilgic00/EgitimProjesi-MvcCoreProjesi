using CoreApp102.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreApp102.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("tblCategories");
        }
    }
}
