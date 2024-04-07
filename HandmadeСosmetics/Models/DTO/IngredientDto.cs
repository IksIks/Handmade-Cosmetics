using HandmadeСosmetics.Models.MaterialsAndProducts;

namespace HandmadeСosmetics.Models.DTO
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public double IngredientWeight { get; set; }

        public IngredientDto()
        {
        }

        public IngredientDto(Ingredient ingredient, double weight)
        {
            Id = ingredient.Id;
            IngredientName = ingredient.Name;
            IngredientWeight = weight;
        }
    }
}