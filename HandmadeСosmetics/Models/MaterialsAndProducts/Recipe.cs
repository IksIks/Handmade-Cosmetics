using System.ComponentModel;

namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Product ProductId { get; set; }
        public List<Component> Components { get; set; }
    }
}