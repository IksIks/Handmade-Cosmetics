using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
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

        public AddIngredientViewModel()
        {
            ingredient = new Ingredient();
            queryIngredientTable = new QueryIngredientsTable(new DataDBContex());
            AddCommand = new LambdaCommand(OnAddCommandExecute, CanAddCommandExecute);
        }

        public ICommand AddCommand { get; }

        private bool CanAddCommandExecute(object p)
        {
            if (String.IsNullOrEmpty(Ingredient.Name)
                && Ingredient.PackageWeight <= 0
                && String.IsNullOrEmpty(Ingredient.UnitMeasurement)
                && Ingredient.IngridientCost <= 0) return false;
            return true;
        }

        private void OnAddCommandExecute(object p)
        {
            //TODO сделать автоматичкский расчет CostPerUnitMeasurement, наверное сделать отдельные поля на каждое поле разметки
            queryIngredientTable.AddIngredient(Ingredient);
        }
    }
}