﻿using HandmadeСosmetics.DataCotnext;
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
                return await dbContext.Recipes.Include(i => i.Ingredients)
                                              .Include(w => w.WeightInRecipes)
                                              .OrderBy(r => r.Name)
                                              .ToListAsync();
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

        public async Task Update(int recipeId, ObservableCollection<IngredientDto> ingredientsDto)
        {
            var ingredientsFromWeightInRecipesTable = dbContext.WeightInRecipes
                                                      .Where(x => x.RecipesId == recipeId).ToList();

            var addedIngredientsId = ingredientsDto
                                     .Where(x => ingredientsFromWeightInRecipesTable
                                     .All(a => a.IngredientId != x.Id)).Select(a => a.Id).ToList();

            var addedIngredients = dbContext.Ingredients.Where(i => addedIngredientsId.Contains(i.Id)).ToList();

            var removedIngredientsId = ingredientsFromWeightInRecipesTable
                                       .Where(x => ingredientsDto
                                       .All(a => a.Id != x.IngredientId)).Select(i => i.IngredientId).ToList();

            var removedIngredients = dbContext.Ingredients
                                     .Where(i => removedIngredientsId.Contains(i.Id)).ToList();

            var updatedRecipe = dbContext.Recipes
                                .Include(x => x.Ingredients)
                                .Include(a => a.WeightInRecipes)
                                .Where(a => a.Id == recipeId).Single();

            if (addedIngredients.Count > 0)
                foreach (var ingredient in addedIngredients)
                {
                    updatedRecipe.Ingredients.Add(ingredient);
                    updatedRecipe.WeightInRecipes.Add
                        (
                            new WeightInRecipe
                                (
                                    recipeId,
                                    ingredient,
                                    ingredientsDto.First(x => x.Id == ingredient.Id)
                                )
                        );
                }

            if (removedIngredients.Count > 0)
                foreach (var item in removedIngredients)
                {
                    updatedRecipe.Ingredients.Remove(item);
                }

            dbContext.WeightInRecipes.RemoveRange(ingredientsFromWeightInRecipesTable
                                                 .Where(w => removedIngredientsId
                                                 .Contains(w.IngredientId)));


            foreach (IngredientDto iDto in ingredientsDto)
            {
                foreach (var ingr in ingredientsFromWeightInRecipesTable)
                {
                    if (ingr.IngredientId == iDto.Id)
                        ingr.Weight = iDto.IngredientWeight;
                }
            }
            await dbContext.SaveChangesAsync();
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