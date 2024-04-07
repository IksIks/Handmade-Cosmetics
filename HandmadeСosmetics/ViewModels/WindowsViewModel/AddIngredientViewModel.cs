using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.ViewModels.PagesViewModels;
using System.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.WindowsViewModel
{
    internal class AddIngredientViewModel : ViewModelBase
    {
        private Ingredient ingredient;
        private readonly QueryIngredientsTable queryIngredientTable;

        public Ingredient Ingredient
        {
            get => ingredient;
            set => Set(ref ingredient, value);
        }

        public List<string> UnitMeasurement { get; set; } = new List<string> { "кг.", "гр.", "мл." };

        public AddIngredientViewModel()
        {
            ingredient = new Ingredient();
            queryIngredientTable = new QueryIngredientsTable(new DataDBContex());
            PageIngredientsViewModel.UpdateIngredientEvent += UpdateIngredient;
            AddCommand = new LambdaCommand(OnAddCommandExecute, CanAddCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted);
            UpdateCommand = new LambdaCommand(OnUpdateCommandExecuted, CanUpdateCommandExecute);
        }

        #region Команда добавления нового ингридиента

        public ICommand AddCommand { get; }

        private bool CanAddCommandExecute(object p)
        {
            return IsLinesFilledCorrectly();
        }

        private void OnAddCommandExecute(object p)
        {
            queryIngredientTable.AddIngredient(new Ingredient(Ingredient.Name, Ingredient.PackageWeight, Ingredient.UnitMeasurement, Ingredient.IngridientCost, Ingredient.Id));
            Application.Current.Windows[1].Close();
        }

        #endregion Команда добавления нового ингридиента

        #region Команда обновления ингредиента

        public ICommand UpdateCommand { get; }

        private bool CanUpdateCommandExecute(object p)
        {
            return IsLinesFilledCorrectly();
        }

        private void OnUpdateCommandExecuted(object p)
        {
            queryIngredientTable.UpdateIngredient(new Ingredient(Ingredient.Name, Ingredient.PackageWeight, Ingredient.UnitMeasurement, Ingredient.IngridientCost, Ingredient.Id));
            Application.Current.Windows[1].Close();
        }

        #endregion Команда обновления ингредиента

        #region Команда отмены

        public ICommand CancelCommand { get; }

        private void OnCancelCommandExecuted(object p)
        {
            Application.Current.Windows[1].Close();
        }

        #endregion Команда отмены

        private void UpdateIngredient(Ingredient ingredient)
        {
            Ingredient = ingredient;
            PageIngredientsViewModel.UpdateIngredientEvent -= UpdateIngredient;
        }

        private bool IsLinesFilledCorrectly()
        {
            if (String.IsNullOrEmpty(Ingredient.Name) ||
                Ingredient.PackageWeight <= 0 ||
                String.IsNullOrEmpty(Ingredient.UnitMeasurement) ||
                Ingredient.IngridientCost <= 0)
                return false;
            return true;
        }
    }
}