using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DTO;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace HandmadeСosmetics.Models.DB
{
    internal class QueryRecipeTable(DataDBContex dbContext)
    {
        private DataDBContex dbContext { get; set; } = dbContext;

        public async Task<List<Recipe>> GetRecipes()
        {
            return await dbContext.Recipes.AsNoTracking().ToListAsync();
        }

        public async Task AddRecipe(string recipeName, ObservableCollection<DTO_Ingredient> dtoIngredients)
        {
            var query = dbContext.Ingredients.ToList();
            List<WeightInRecipe> weight = new List<WeightInRecipe>();
            List<Ingredient> ingr = new();
            foreach (var dto in dtoIngredients)
            {
                foreach (var ingredient in query)
                {
                    if (dto.Id == ingredient.Id)
                    {
                        ingr.Add(ingredient);
                        weight.Add(new WeightInRecipe(dto.IngredientWeight, ingredient));
                    }
                }
            }
            await dbContext.Recipes.AddAsync(new Recipe
            {
                Name = recipeName,
                Ingredients = ingr,
                WeightInRecipes = weight
            });
            await dbContext.SaveChangesAsync();
        }
    }
}