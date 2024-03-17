namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
        public List<AmountInRecipe> Amounts { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        //public Recipe(int id, string name, Product product, List<Ingredient> ingredients)
        //{
        //    Id = id;
        //    Name = name;
        //    Product = product;
        //    Ingredients = ingredients;
        //}
    }
}