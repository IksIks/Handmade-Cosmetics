using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;

namespace HandmadeСosmetics.Models.DB
{
    internal class QueryIngredientsTable(DataDBContex dbContext)
    {
        private DataDBContex dbContext = dbContext;

        public List<Ingredient> Get()
        {
            using (dbContext = new())
            {
                return dbContext.Ingredients.ToList();
            }
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            await dbContext.Ingredients.AddAsync(ingredient);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateIngredient(Ingredient ingredient)
        {
            await dbContext.Ingredients.Where(e => e.Id == ingredient.Id)
                .ExecuteUpdateAsync(e =>
                e.SetProperty(e => e.Name, ingredient.Name)
                .SetProperty(e => e.PackageWeight, ingredient.PackageWeight)
                .SetProperty(e => e.UnitMeasurement, ingredient.UnitMeasurement)
                .SetProperty(e => e.IngridientCost, ingredient.IngridientCost)
                .SetProperty(e => e.CostPerUnitMeasurement, ingredient.CostPerUnitMeasurement));
        }

        public async Task DeleteIngredient(int id)
        {
            using (dbContext = new())
            {
                await dbContext.Ingredients.Where(e => e.Id == id).ExecuteDeleteAsync();
            }
        }
    }
}