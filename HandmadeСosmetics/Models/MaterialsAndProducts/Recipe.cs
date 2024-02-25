namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
    }
}