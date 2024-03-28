using HandmadeСosmetics.Command;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.DTO;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageRecipesViewModel : ViewModelBase
    {
        private readonly QueryIngredientsTable queryIngredientTable;
        private readonly QueryRecipeTable queryRecipeTable;
        private List<DTO_Recipe> recipes;
        private List<Ingredient> ingredients;
        private Recipe selectedRecipe;

        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set => Set(ref selectedRecipe, value);
        }

        public List<DTO_Recipe> Recipes
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
            AddNewRecipeCommand = new LambdaCommand(OnAddNewRecipeCommandExecuted);
            GetRecipes();
        }

        private async Task GetRecipes()
        {
            await queryRecipeTable.Get();
            //Recipes = new ObservableCollection<Recipe>(await queryRecipeTable.Get());
            //var y = new ObservableCollection<Recipe>(await queryRecipeTable.Get());
        }

        public ICommand AddNewRecipeCommand { get; }

        private void OnAddNewRecipeCommandExecuted(object p)
        {
            AddNewRecipeView addNewRecipeView = new AddNewRecipeView();
            addNewRecipeView.ShowDialog();
            GetRecipes();
        }
    }
}