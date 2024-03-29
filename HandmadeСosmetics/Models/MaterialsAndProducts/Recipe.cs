﻿namespace HandmadeСosmetics.Models.MaterialsAndProducts
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
        public List<WeightInRecipe> WeightInRecipes { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
        }

        public Recipe(int id, string name, List<WeightInRecipe> weightInRecipes, List<Ingredient> ingredients)
        {
            Id = id;
            Name = name;
            WeightInRecipes = weightInRecipes;
            Ingredients = ingredients;
        }
    }
}