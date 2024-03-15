namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class AmountInRecipe
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}