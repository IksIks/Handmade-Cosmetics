using HandmadeСosmetics.ViewModel;

namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Product : ViewModelBase
    {
        private string? photo;
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Photo
        {
            get => photo;
            set => Set(ref photo, value);
        }

        //public string? Photo { get; set; }
        public double NetCost { get; set; }

        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, string photo, double netCost, int recipeId)
        {
            Id = id;
            Name = name;
            Photo = photo;
            NetCost = netCost;
            RecipeId = recipeId;
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