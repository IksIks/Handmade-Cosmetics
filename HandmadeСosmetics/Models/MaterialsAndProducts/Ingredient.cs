using HandmadeСosmetics.ViewModel;

namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Ingredient : ViewModelBase
    {
        public int Id { get; set; }
        public double IngridientCost { get; set; }
        public string UnitMeasurement { get; set; }
        public double PackageWeight { get; set; }
        public string Name { get; set; }
        public double CostPerUnitMeasurement { get; set; }
        public int AmountInRecipeId { get; set; }
        public List<WeightInRecipe> AmountInRecipe { get; set; }
        public List<Recipe>? Recipe { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(string name, double packageWeight, string unitMeasurement, double ingridientCost, int id = 0)
        {
            Id = id;
            Name = name;
            PackageWeight = packageWeight;
            UnitMeasurement = unitMeasurement;
            IngridientCost = ingridientCost;
            CostPerUnitMeasurement = ingridientCost / packageWeight;
        }

        public Ingredient(string name, double packageWeight, string unitMeasurement, double ingridientCost, List<WeightInRecipe> amountInRecipe, int id = 0)
        {
            Id = id;
            Name = name;
            PackageWeight = packageWeight;
            UnitMeasurement = unitMeasurement;
            IngridientCost = ingridientCost;
            CostPerUnitMeasurement = ingridientCost / packageWeight;
            AmountInRecipe = amountInRecipe;
        }
    }
}