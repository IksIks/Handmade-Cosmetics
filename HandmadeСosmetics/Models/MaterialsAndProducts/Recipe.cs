namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product>? Products { get; set; }

        //public int WeightInRecipesId { get; set; }//
        public List<WeightInRecipe> WeightInRecipes { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
        }
       
    }
}