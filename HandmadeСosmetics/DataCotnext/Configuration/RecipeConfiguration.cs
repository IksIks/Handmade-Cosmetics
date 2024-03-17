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
            builder.Property(x => x.Id).UseIdentityAlwaysColumn();
            builder.HasMany(e => e.Ingredients).WithMany(r => r.Recipe);
            builder.HasMany(p => p.Products).WithOne(r => r.Recipe);
            builder.HasMany(r => r.WeightInRecipes).WithOne(a => a.Recipes);
        }
    }
}