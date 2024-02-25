namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public double NetCost { get; set; }
        public Recipe? Recipe { get; set; }
        public int RecipeId { get; set; }
    }
}