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
        private string section = "РЕЦЕПТЫ";

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
            MainWindowViewModel.SetResponseToBase += GetRecipesFromDb;
            AddNewRecipeCommand = new LambdaCommand(OnAddNewRecipeCommandExecuted);
            DeleteRecipeCommand = new LambdaCommand(OnDeleteRecipeCommandExecuted, CanDeleteRecipeCommandExecute);
            EditRecipeCommand = new LambdaCommand(OnEditRecipeCommandExecuted, CanEditRecipeCommandExecute);
            //GetRecipes();
        }

        #region Создание рецепта.................................................................................................

        public ICommand AddNewRecipeCommand { get; }

        private async void OnAddNewRecipeCommandExecuted(object p)
        {
            AddNewRecipeView addNewRecipeView = new AddNewRecipeView();
            addNewRecipeView.ShowDialog();
            await GetRecipesFromDb(section);
            //GetRecipes();
        }

        #endregion Создание рецепта.................................................................................................

        #region Команда обновления рецепта.......................................................................................

        public ICommand EditRecipeCommand { get; }

        private bool CanEditRecipeCommandExecute(object p)
        {
            return p is Recipe;
        }

        private async void OnEditRecipeCommandExecuted(object p)
        {
            AddNewRecipeView updateRecipeView = new();
            UpdateRecipeEvent?.Invoke(SelectedRecipe);
            updateRecipeView.ShowDialog();
            await GetRecipesFromDb(section);
            //GetRecipes();
        }

        #endregion Команда обновления рецепта.......................................................................................

        #region Удаление рецепта..................................................................................................

        public ICommand DeleteRecipeCommand { get; }

        private bool CanDeleteRecipeCommandExecute(object p)
        {
            return p is Recipe;
        }

        private async void OnDeleteRecipeCommandExecuted(object p)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                queryRecipeTable.Delete(p as Recipe);
                await GetRecipesFromDb(section);
                //GetRecipes();
            }
        }

        #endregion Удаление рецепта..................................................................................................

        private async Task GetRecipesFromDb(string b)
        {
            if (b.Equals("РЕЦЕПТЫ"))
                Recipes = (await queryRecipeTable.Get()).ToList();
        }
    }
}