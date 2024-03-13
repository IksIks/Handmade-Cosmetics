using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.MaterialsAndProducts;

namespace HandmadeСosmetics.Models.DB
{
    internal class QueryIngredientsTable(DataDBContex dbContext)
    {
        private DataDBContex dbContext = dbContext;

        public List<Ingredient> Get()
        {
            return dbContext.Ingredients.ToList();
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            await dbContext.Ingredients.AddAsync(ingredient);
        }
    }
}