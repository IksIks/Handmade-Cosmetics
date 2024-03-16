using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;

namespace HandmadeСosmetics.Models.DB
{
    internal class QueryRecipeTable(DataDBContex dbContext)
    {
        private DataDBContex dbContext { get; set; } = dbContext;

        public async Task<List<Recipe>> GetRecipes()
        {
            return await dbContext.Recipes.AsNoTracking().ToListAsync();
        }

        //public async Task<List<Ingredient>> GetByRecipeId(int recipeId)
        //{
        //}
    }
}