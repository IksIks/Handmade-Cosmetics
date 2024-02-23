namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double PackageWeight { get; set; }
        public string UnitMeasurement { get; set; }
        public double IngridientCost { get; set; }
        public Recipe RecipeId { get; set; }
        public double CostPerUnitMeasurement { get => IngridientCost / PackageWeight; }
    }
}