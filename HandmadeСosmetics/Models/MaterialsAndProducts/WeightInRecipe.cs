using HandmadeСosmetics.Models.DTO;

namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class WeightInRecipe
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public int IngredientId { get; set; }// проверить
        public Ingredient Ingredient { get; set; }
        public int RecipesId { get; set; }// проверить
        public Recipe Recipes { get; set; }

        public WeightInRecipe()
        {
        }

        public WeightInRecipe(double weight, Ingredient ingredient)
        {
            Weight = weight;
            Ingredient = ingredient;
        }

        public WeightInRecipe(int recipeId, Ingredient ingredient, IngredientDto ingredientDto)
        {
            RecipesId = recipeId;
            Ingredient = ingredient;
            Weight = ingredientDto.IngredientWeight;
        }
    }
}