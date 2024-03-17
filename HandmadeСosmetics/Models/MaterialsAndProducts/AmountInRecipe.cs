namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class AmountInRecipe
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        //public int? RecipeId { get; set; }

        public Ingredient Ingredient { get; set; }
        public List<Recipe> Recipes { get; set; }

        public AmountInRecipe(double weight)
        {
            Weight = weight;
        }
    }
}