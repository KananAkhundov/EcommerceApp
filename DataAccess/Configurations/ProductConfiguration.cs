using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("Stores name of Product");

            builder.Property(x => x.Description)
                .HasMaxLength(5000)
                .IsRequired()
                .HasComment("Stores description of Product");

            builder.Property(x => x.PhotoUrl).HasMaxLength(500).IsRequired();

            builder.Property(x=>x.Deleted).HasDefaultValue<int>(0);

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_Product_Name_Deleted");

            builder.HasIndex(x => x.Name)
                .HasDatabaseName("idx_ProductName_Deleted");

            builder.HasOne(x=>x.Category)
                .WithMany(x=>x.Products)
                .HasForeignKey(x=>x.CategoryId)
                .HasConstraintName("fk_Product_CategoryId");
        }
    }
}
