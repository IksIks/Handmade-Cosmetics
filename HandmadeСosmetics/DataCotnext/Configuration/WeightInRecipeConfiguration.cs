using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HandmadeСosmetics.DataCotnext.Configuration
{
    internal class WeightInRecipeConfiguration : IEntityTypeConfiguration<WeightInRecipe>
    {
        public void Configure(EntityTypeBuilder<WeightInRecipe> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityAlwaysColumn();
            builder.HasOne(w => w.Ingredient).WithMany(i => i.WeightInRecipes).HasForeignKey(w => w.IngredientId);//
            builder.HasOne(w => w.Recipes).WithMany(i => i.WeightInRecipes).HasForeignKey(w => w.RecipesId);//
            //builder.HasMany(w => w.Recipes).WithMany(r => r.WeightInRecipes);
        }
    }
}