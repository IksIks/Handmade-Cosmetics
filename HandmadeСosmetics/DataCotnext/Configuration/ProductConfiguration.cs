using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandmadeСosmetics.DataCotnext.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityAlwaysColumn();
            //builder.HasOne(p => p.Recipe).WithOne(r => r.Product).HasForeignKey<Product>(r => r.RecipeId);
            builder.HasOne(p => p.Recipe).WithMany(r => r.Products);
        }
    }
}