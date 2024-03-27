namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class WeightInRecipe
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public Ingredient Ingredient { get; set; }
        public Recipe Recipes { get; set; }

        public WeightInRecipe()
        {
        }

        public WeightInRecipe(double weight, Ingredient ingredient)
        {
            Weight = weight;
            Ingredient = ingredient;
        }
    }
}