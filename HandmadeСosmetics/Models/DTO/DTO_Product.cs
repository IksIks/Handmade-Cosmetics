namespace HandmadeСosmetics.Models.DTO
{
    internal class DTO_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
        public double NetCost { get; set; }
        public string RecipeName { get; set; }

        public DTO_Product()
        {
        }

        public DTO_Product(int id, string name, string photo, double netCost, string recipeName)
        {
            Id = id;
            Name = name;
            Photo = photo;
            NetCost = netCost;
            RecipeName = recipeName;
        }

        //public Product ConverteDTO_ProductToProduct(DTO_Product prod)
        //{
        //    return new Product { Id = prod.Id, Name = prod.Name, Photo = prod.Photo, NetCost = prod.NetCost };
        //}
    }
}