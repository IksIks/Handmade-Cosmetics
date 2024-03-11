using HandmadeСosmetics.ViewModel;

namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Product : ViewModelBase
    {
        private double netCost;
        private string? photo;
        private string name;
        private double price;
        private double weight;

        public int Id { get; set; }

        public double Weight
        {
            get => weight;
            set => Set(ref weight, value);
        }

        public double Price
        {
            get => price;
            set => Set(ref price, value);
        }

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

        public Product(string name, string photo, double netCost, int recipeId, double price, double weight)
        {
            Name = name;
            Photo = photo;
            NetCost = netCost;
            RecipeId = recipeId;
            Price = price;
            Weight = weight;
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