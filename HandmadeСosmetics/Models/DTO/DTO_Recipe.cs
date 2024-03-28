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
    }
}