namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double PackageWeight { get; set; }
        public string? UnitMeasurement { get; set; }
        public double IngridientCost { get; set; }
        public List<Recipe>? Recipe { get; set; }
        public double CostPerUnitMeasurement { get => IngridientCost / PackageWeight; }

        public Ingredient(int id, string name, double packageWeight, string unitMeasurement, double ingridientCost, List<Recipe>? recipe)
        {
            Id = id;
            Name = name;
            PackageWeight = packageWeight;
            UnitMeasurement = unitMeasurement;
            IngridientCost = ingridientCost;
            Recipe = recipe;
        }
    }
}