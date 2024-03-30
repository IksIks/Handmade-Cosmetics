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

        public async Task<List<Recipe>> Get()
        {
            using (dbContext = new DataDBContex())
            {
                return await dbContext.Recipes.Join(dbContext.Ingredients, r => r.Id, i => i.Id,
                                                    (r, i) => new Recipe
                                                        (
                                                            r.Id,
                                                            r.Name,
                                                            r.WeightInRecipes.Where(x => x.RecipesId == r.Id).ToList(),
                                                            r.Ingredients
                                                        )).ToListAsync();
            }
        }

        public async Task<List<Recipe>> GetRecipesNamesOnly()
        {
            return await dbContext.Recipes.AsNoTracking().ToListAsync();
        }

        public async Task AddRecipe(string recipeName, ObservableCollection<IngredientDto> dtoIngredients)
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
                        break;
                    }
                }
            }

            //var ingrIds = dtoIngredients.Select(x => x.Id).ToList();

            //var ingrs = dbContext.Ingredients.Where(x => ingrIds.Contains(x.Id)).ToList();

            await dbContext.Recipes.AddAsync(new Recipe
            {
                Name = recipeName,
                Ingredients = ingr,
                WeightInRecipes = weight
            });
            await dbContext.SaveChangesAsync();
            //TODO перенести весь код поиска элементов в модель Recipe
        }

        public async Task Delete(Recipe recipe)
        {
            using (dbContext = new())
            {
                dbContext.Recipes.Remove(recipe);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}