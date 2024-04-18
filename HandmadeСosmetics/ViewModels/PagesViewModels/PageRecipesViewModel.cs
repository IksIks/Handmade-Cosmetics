using HandmadeСosmetics.Command;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageRecipesViewModel : ViewModelBase
    {
        public static Action<Recipe> UpdateRecipeEvent;
        private readonly QueryRecipeTable queryRecipeTable;
        private List<Recipe> recipes;
        private List<Ingredient> ingredients;
        private Recipe selectedRecipe;

        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set => Set(ref selectedRecipe, value);
        }

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
            queryRecipeTable = new QueryRecipeTable(new DataCotnext.DataDBContex());
            AddNewRecipeCommand = new LambdaCommand(OnAddNewRecipeCommandExecuted);
            DeleteRecipeCommand = new LambdaCommand(OnDeleteRecipeCommandExecuted, CanDeleteRecipeCommandExecute);
            EditRecipeCommand = new LambdaCommand(OnEditRecipeCommandExecuted, CanEditRecipeCommandExecute);
            GetRecipes();
        }

        private async Task GetRecipes()
        {
            Recipes = (await queryRecipeTable.Get()).ToList();
        }

        #region Создание рецепта.................................................................................................

        public ICommand AddNewRecipeCommand { get; }

        private void OnAddNewRecipeCommandExecuted(object p)
        {
            AddNewRecipeView addNewRecipeView = new AddNewRecipeView();
            addNewRecipeView.ShowDialog();
            GetRecipes();
        }

        #endregion Создание рецепта.................................................................................................

        #region Команда обновления рецепта.......................................................................................

        public ICommand EditRecipeCommand { get; }

        private bool CanEditRecipeCommandExecute(object p)
        {
            return p is Recipe;
        }

        private void OnEditRecipeCommandExecuted(object p)
        {
            UpdateRecipeView updateRecipeView = new UpdateRecipeView();
            UpdateRecipeEvent?.Invoke(SelectedRecipe);
            updateRecipeView.ShowDialog();
            GetRecipes();
        }

        #endregion Команда обновления рецепта.......................................................................................

        #region Удаление рецепта..................................................................................................

        public ICommand DeleteRecipeCommand { get; }

        private bool CanDeleteRecipeCommandExecute(object p)
        {
            return p is Recipe;
        }

        private void OnDeleteRecipeCommandExecuted(object p)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                queryRecipeTable.Delete(p as Recipe);
                GetRecipes();
            }
        }

        #endregion Удаление рецепта..................................................................................................
    }
}