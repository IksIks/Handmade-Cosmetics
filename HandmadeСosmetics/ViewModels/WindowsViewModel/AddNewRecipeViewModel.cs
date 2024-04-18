using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.DTO;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.ViewModels.PagesViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.WindowsViewModel
{
    internal class AddNewRecipeViewModel : ViewModelBase
    {
        private readonly QueryIngredientsTable queryIngredientsTable;
        private readonly QueryRecipeTable queryRecipeTable;
        private string weight;
        private double parsedWeight;
        private string recipeName;
        private int recipeId;

        public string Weight
        {
            get => weight;
            set => Set(ref weight, value);
        }

        public string RecipeName
        {
            get => recipeName;
            set => Set(ref recipeName, value);
        }

        public List<Ingredient> Ingredients { get; set; } = new();
        public Ingredient SelectedItem { get; set; } = new();
        public IngredientDto SelectedItemDto { get; set; }
        public ObservableCollection<IngredientDto> IngredientsWeights { get; set; } = new();

        public AddNewRecipeViewModel()
        {
            queryRecipeTable = new(new DataDBContex());
            queryIngredientsTable = new(new DataDBContex());
            PageRecipesViewModel.UpdateRecipeEvent += FillDataUpdateView;
            Ingredients = queryIngredientsTable.Get();
            //TODO перенести в отдельный метод и сделать асинхронным вызов

            #region Команды

            AddIngredientToCollectionCommand = new LambdaCommand(OnAddIngredientToCollectionCommandExecuted, CanAddIngredientToCollectionCommandExecute);
            DeleteIngredientFromCollectionCommand = new LambdaCommand(OnDeleteIngredientFromCollectionCommandExecuted, CanDeleteIngredientFromCollectionCommandExecute);
            AddRecipeCommand = new LambdaCommand(OnAddRecipeCommandExecuted, CanAddRecipeCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted);
            UpdateRecipeCommand = new LambdaCommand(OnUpdateRecipeCommandExecuted, CanUpdateRecipeCommandExecute);

            #endregion Команды
        }

        private void FillDataUpdateView(Recipe recipe)
        {
            recipeId = recipe.Id;
            RecipeName = recipe.Name;
            foreach (var item in recipe.WeightInRecipes)
            {
                IngredientsWeights.Add(new IngredientDto(item.Ingredient, item.Weight));
            }
        }

        #region Команда Добавление ингредиентов к рецепту

        public ICommand AddIngredientToCollectionCommand { get; }

        private bool CanAddIngredientToCollectionCommandExecute(object p)
        {
            if (!double.TryParse(Weight, out parsedWeight))
                return false;
            return true;
        }

        private void OnAddIngredientToCollectionCommandExecuted(object p)
        {
            if (IngredientsWeights.FirstOrDefault(a => a.IngredientName == SelectedItem.Name) != null)
            {
                MessageBox.Show("такой ингредиент уже добавлен");
                return;
            }
            IngredientsWeights.Add(new IngredientDto(SelectedItem, parsedWeight));
            Weight = default;
        }

        #endregion Команда Добавление ингредиентов к рецепту

        #region Команда обновления рецепта

        public ICommand UpdateRecipeCommand { get; }

        private bool CanUpdateRecipeCommandExecute(object p)
        {
            return IsLinesFilledCorrectly();
        }

        private void OnUpdateRecipeCommandExecuted(object p)
        {
            queryRecipeTable.Update(recipeId, IngredientsWeights);
            Application.Current.Windows[1].Close();
        }

        #endregion Команда обновления рецепта

        #region Команда удаление ингредиентов из рецепта

        public ICommand DeleteIngredientFromCollectionCommand { get; }

        private bool CanDeleteIngredientFromCollectionCommandExecute(object p)
        {
            return SelectedItemDto is IngredientDto;
        }

        private void OnDeleteIngredientFromCollectionCommandExecuted(object p)
        {
            IngredientsWeights.Remove(SelectedItemDto);
        }

        #endregion Команда удаление ингредиентов из рецепта

        #region Команда создания рецепта

        public ICommand AddRecipeCommand { get; }

        private bool CanAddRecipeCommandExecute(object p)
        {
            return IsLinesFilledCorrectly();
            //return IngredientsWeights.Count > 0 ? true : false && !String.IsNullOrEmpty(RecipeName);
        }

        private void OnAddRecipeCommandExecuted(object p)
        {
            queryRecipeTable.AddRecipe(RecipeName, IngredientsWeights);
            Application.Current.Windows[1].Close();
        }

        #endregion Команда создания рецепта

        #region Команда закрытия окна

        public ICommand CancelCommand { get; }

        private void OnCancelCommandExecuted(object p)
        {
            Application.Current.Windows[1].Close();
        }

        #endregion Команда закрытия окна

        private bool IsLinesFilledCorrectly()
        {
            if (IngredientsWeights.Count <= 0 || String.IsNullOrEmpty(RecipeName))
                return false;
            return true;
        }
    }
}