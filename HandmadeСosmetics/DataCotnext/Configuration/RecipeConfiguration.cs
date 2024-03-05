using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandmadeСosmetics.DataCotnext.Configuration
{
    internal class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Ingredients).WithMany(r => r.Recipe);
            //builder.HasMany(e => e.Ingredients);
            //builder.HasOne(p => p.Product).WithOne(r => r.Recipe).HasForeignKey<Recipe>(p => p.ProductId);
            builder.HasMany(p => p.Products).WithOne(r => r.Recipe);
        }
    }
}