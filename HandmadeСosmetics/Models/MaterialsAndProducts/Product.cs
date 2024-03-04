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

        public Product(int id, string name, string photo, double netCost, Recipe? recipe)
        {
            Id = id;
            Name = name;
            Photo = photo;
            NetCost = netCost;
            Recipe = recipe;
        }

        //public Product(int id, string name, string photo, double netCost)
        //{
        //    Id = id;
        //    Name = name;
        //    Photo = photo;
        //    NetCost = netCost;
        //}
    }
}