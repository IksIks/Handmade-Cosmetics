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

        private double costPerUnitMeasurement;

        public double CostPerUnitMeasurement
        {
            get { return costPerUnitMeasurement; }
            set { costPerUnitMeasurement = IngridientCost / PackageWeight; }
        }

        public Ingredient()
        {
        }

        public Ingredient(int id, string name, double packageWeight, string unitMeasurement, double ingridientCost, List<Recipe>? recipe)
        {
            Id = id;
            Name = name;
            PackageWeight = packageWeight;
            UnitMeasurement = unitMeasurement;
            IngridientCost = ingridientCost;
            Recipe = recipe;
        }

        public Ingredient(string name, double packageWeight, string unitMeasurement, double ingridientCost)
        {
            //Id = id;
            Name = name;
            PackageWeight = packageWeight;
            UnitMeasurement = unitMeasurement;
            IngridientCost = ingridientCost;
            //Recipe = recipe;
        }
    }
}