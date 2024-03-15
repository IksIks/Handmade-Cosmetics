using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandmadeСosmetics.DataCotnext.Configuration
{
    internal class IngridietsConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).UseIdentityAlwaysColumn();
            builder.HasMany(r => r.Recipe).WithMany(e => e.Ingredients);
            builder.HasMany(i => i.AmountInRecipe).WithOne(a => a.Ingredient);
        }
    }
}