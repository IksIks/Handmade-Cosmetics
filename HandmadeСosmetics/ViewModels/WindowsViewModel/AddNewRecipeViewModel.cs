using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.WindowsViewModel
{
    internal class AddNewRecipeViewModel : ViewModelBase
    {
        private readonly QueryIngredientsTable queryIngredientsTable;
        public List<Ingredient> Ingredients { get; set; } = new();
        public Ingredient SelectedItem { get; set; } = new();
        public ObservableCollection<Ingredient> IngredientsWeights { get; set; } = new();
        public string Wieght { get; set; }

        public AddNewRecipeViewModel()
        {
            queryIngredientsTable = new(new DataDBContex());
            Ingredients = queryIngredientsTable.Get();
            AddIngredientToCollectionCommand = new LambdaCommand(OnAddIngredientToCollectionCommandExecuted);
        }

        public ICommand AddIngredientToCollectionCommand { get; }

        private bool CanAddIngredientToCollectionCommandExecute(object p)
        {
            return true;
        }

        private void OnAddIngredientToCollectionCommandExecuted(object p)
        {
            SelectedItem.WeightInRecipes = new() { new WeightInRecipe(Convert.ToDouble(Wieght)) };
            IngredientsWeights.Add(SelectedItem);
        }
    }
}