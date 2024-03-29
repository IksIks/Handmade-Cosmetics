using HandmadeСosmetics.Models.MaterialsAndProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandmadeСosmetics.Models.DTO
{
    internal class DTO_Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IngredientName { get; set; }
        public double IngredientWeight { get; set; }

        public List<string> IngredientNames { get; set; }
        public List<WeightInRecipe> IngredientWeights { get; set; }

        public DTO_Recipe()
        {
        }

        public DTO_Recipe(int id, string name, string ingredientName, double ingredientWeight)
        {
            Id = id;
            Name = name;
            IngredientName = ingredientName;
            IngredientWeight = ingredientWeight;
        }

        public DTO_Recipe(int id, string name, List<WeightInRecipe> ingredientWeights /*string ingredientName*/ )
        {
            Id = id;
            Name = name;
            IngredientWeights = ingredientWeights;
            //IngredientName = ingredientName;
        }
    }
}