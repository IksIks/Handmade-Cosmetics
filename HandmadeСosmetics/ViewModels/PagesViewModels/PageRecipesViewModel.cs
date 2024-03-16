using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageRecipesViewModel : ViewModelBase
    {
        private readonly QueryIngredientsTable queryIngredientTable;
        private readonly QueryRecipeTable queryRecipeTable;
        private List<Recipe> recipes;
        private List<Ingredient> ingredients;

        public List<Recipe> Recipes
        {
            get => recipes;
            set => Set(ref recipes, value);
        }

        public List<Ingredient> Ingredients
        {
            get => ingredients;
            set => Set(ref ingredients, value);
        }

        public PageRecipesViewModel()
        {
            queryIngredientTable = new QueryIngredientsTable(new DataCotnext.DataDBContex());
            queryRecipeTable = new QueryRecipeTable(new DataCotnext.DataDBContex());
            Recipes = queryRecipeTable.GetRecipes();
        }
    }
}