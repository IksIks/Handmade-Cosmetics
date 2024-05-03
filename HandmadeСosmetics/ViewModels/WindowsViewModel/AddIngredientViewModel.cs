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
        private string ingrUnitMeasurement;
        private readonly QueryIngredientsTable queryIngredientTable;
        private string packageWeight;
        private string name;
        private string cost;
        private double packageWeightTryParse;
        private double costTryParse;
        private int id;
        private string buttonContext = "Добавить";

        public string ButtonContext
        {
            get => buttonContext;
            set => Set(ref buttonContext, value);
        }

        public string Cost
        {
            get => cost;
            set => Set(ref cost, value);
        }

        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }

        public string PackageWeight
        {
            get => packageWeight;
            set => Set(ref packageWeight, value);
        }

        public string IngrUnitMeasurement
        {
            get => ingrUnitMeasurement;
            set => Set(ref ingrUnitMeasurement, value);
        }

        public List<string> UnitMeasurement { get; set; } = new List<string> { "гр.", "мл." };

        public AddIngredientViewModel()
        {
            queryIngredientTable = new QueryIngredientsTable(new DataDBContex());
            PageIngredientsViewModel.UpdateIngredientEvent += UpdateIngredient;
            AddOrUpdateCommand = new LambdaCommand(OnAddOrUpdateCommandExecute, CanAddOrUpdateCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted);
            //UpdateCommand = new LambdaCommand(OnUpdateCommandExecuted, CanUpdateCommandExecute);
        }

        #region Команда добавления нового ингридиента

        public ICommand AddOrUpdateCommand { get; }

        private bool CanAddOrUpdateCommandExecute(object p)
        {
            return IsLinesFilledCorrectly();
        }

        private void OnAddOrUpdateCommandExecute(object p)
        {
            if (ButtonContext.Equals("Добавить"))
                queryIngredientTable.AddIngredient(new Ingredient(Name, packageWeightTryParse, IngrUnitMeasurement, costTryParse));
            if (ButtonContext.Equals("Изменить"))
                queryIngredientTable.UpdateIngredient(new Ingredient(Name, packageWeightTryParse, IngrUnitMeasurement, costTryParse, id));
            Application.Current.Windows[1].Close();
        }

        #endregion Команда добавления нового ингридиента

        //#region Команда обновления ингредиента

        //public ICommand UpdateCommand { get; }

        //private bool CanUpdateCommandExecute(object p)
        //{
        //    return IsLinesFilledCorrectly();
        //}

        //private void OnUpdateCommandExecuted(object p)
        //{
        //    queryIngredientTable.UpdateIngredient(new Ingredient(Name, packageWeightTryParse, ingrUnitMeasurement, costTryParse, id));
        //    Application.Current.Windows[1].Close();
        //}

        //#endregion Команда обновления ингредиента

        #region Команда отмены

        public ICommand CancelCommand { get; }

        private void OnCancelCommandExecuted(object p)
        {
            Application.Current.Windows[1].Close();
        }

        #endregion Команда отмены

        private void UpdateIngredient(Ingredient ingredient)
        {
            ButtonContext = "Изменить";
            id = ingredient.Id;
            Name = ingredient.Name;
            PackageWeight = ingredient.PackageWeight.ToString();
            IngrUnitMeasurement = ingredient.UnitMeasurement.ToString();
            Cost = ingredient.IngridientCost.ToString();
            PageIngredientsViewModel.UpdateIngredientEvent -= UpdateIngredient;
        }

        private bool IsLinesFilledCorrectly()
        {
            if (String.IsNullOrEmpty(Name) || !double.TryParse(packageWeight, out packageWeightTryParse) ||
                String.IsNullOrEmpty(IngrUnitMeasurement) || !double.TryParse(cost, out costTryParse))
                return false;
            return true;
        }
    }
}