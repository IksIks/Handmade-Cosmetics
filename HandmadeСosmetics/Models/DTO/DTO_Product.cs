using HandmadeСosmetics.Models.MaterialsAndProducts;

namespace HandmadeСosmetics.Models.DTO
{
    internal class DTO_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
        public double NetCost { get; set; }
        public string RecipeName { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }

        public DTO_Product()
        {
        }

        public DTO_Product(int id, string name, string photo, double netCost, string recipeName, double price, double weight)
        {
            Id = id;
            Name = name;
            Photo = photo;
            NetCost = netCost;
            RecipeName = recipeName;
            Price = price;
            Weight = weight;
        }

        //public DTO_Product(Product product, string recipeName)
        //{
        //    Id = product.Id;
        //    Name = product.Name;
        //    Photo = product.Photo;
        //    NetCost = product.NetCost;
        //    RecipeName = recipeName;
        //    Price = product.Price;
        //    Weight = product.Weight;
        //}

        //public Product ConverteDTO_ProductToProduct(DTO_Product prod)
        //{
        //    return new Product { Id = prod.Id, Name = prod.Name, Photo = prod.Photo, NetCost = prod.NetCost };
        //}
    }
}