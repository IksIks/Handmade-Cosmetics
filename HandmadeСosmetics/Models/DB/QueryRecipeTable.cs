using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;

namespace HandmadeСosmetics.Models.DB
{
    internal class QueryRecipeTable(DataDBContex dbContext)
    {
        private DataDBContex dbContext { get; set; } = dbContext;

        public List<Recipe> GetRecipes()
        {
            return dbContext.Recipes.AsNoTracking().ToList();
        }

        //public async Task<List<Ingredient>> GetByRecipeId(int recipeId)
        //{
        //}
    }
}