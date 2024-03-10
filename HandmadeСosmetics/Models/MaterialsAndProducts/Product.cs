using HandmadeСosmetics.ViewModel;

namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Product : ViewModelBase
    {
        private string? photo;
        public int Id { get; set; }
        private string name;

        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }

        public string? Photo
        {
            get => photo;
            set => Set(ref photo, value);
        }

        private double netCost;

        public double NetCost
        {
            get => netCost;
            set => Set(ref netCost, value);
        }

        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

        public Product()
        {
        }

        public Product(string name, string photo, double netCost, int recipeId)
        {
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