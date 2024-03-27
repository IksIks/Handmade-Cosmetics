using HandmadeСosmetics.Models.MaterialsAndProducts;

namespace HandmadeСosmetics.Models.DTO
{
    internal class DTO_Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public double IngredientWeight { get; set; }

        public DTO_Ingredient()
        {
        }

        public DTO_Ingredient(Ingredient ingredient, double weight)
        {
            Id = ingredient.Id;
            IngredientName = ingredient.Name;
            IngredientWeight = weight;
        }
    }
}