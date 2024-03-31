using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired()
                .HasComment("Stores name of Category");

            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_Category_Name_Deleted");

            builder.HasIndex(x => x.Name)
                .HasDatabaseName("idx_CategoryName_Deleted");
        }
    }
}
