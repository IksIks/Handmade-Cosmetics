using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageRecipesViewModel
    {
        private List<Recipe> recipes;

        private readonly QueryRecipeTable queryRecipeTable;

        public List<Recipe> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }

        public PageRecipesViewModel()
        {
            //queryRecipeTable = new QueryRecipeTable(new DataCotnext.DataDBContex());
            //Recipes = queryRecipeTable.GetRecipes();
        }
    }
}