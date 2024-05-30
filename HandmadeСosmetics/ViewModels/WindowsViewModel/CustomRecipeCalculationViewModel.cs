using HandmadeСosmetics.Command;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.DTO;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.WindowsViewModel
{
    internal class CustomRecipeCalculationViewModel : ViewModelBase
    {
        private double customWieght;
        private double percentRatioCustomWieght;
        private List<Recipe> recipes;
        private readonly QueryRecipeTable queryRecipeTable;
        private Recipe selectedRecipe;
        private ObservableCollection<IngredientDto> ingredientsWeights;

        public ObservableCollection<IngredientDto> IngredientsWeights
        {
            get => ingredientsWeights;
            set => Set(ref ingredientsWeights, value);
        }

        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set
            {
                Set(ref selectedRecipe, value);
                IncreasingValuesIngredients(selectedRecipe);
            }
        }

        public double CustomWieght
        {
            get => customWieght;
            set
            {
                Set(ref customWieght, value);
            }
        }

        public List<Recipe> Recipes
        {
            get => recipes;
            set => Set(ref recipes, value);
        }

        public CustomRecipeCalculationViewModel()
        {
            queryRecipeTable = new QueryRecipeTable(new DataCotnext.DataDBContex());
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted);
            GetRecipesFromDb();
        }

        public ICommand CancelCommand { get; }

        private void OnCancelCommandExecuted(object p)
        {
            Application.Current.Windows[1].Close();
        }

        private async Task GetRecipesFromDb()
        {
            Recipes = (await queryRecipeTable.Get()).ToList();
        }

        private async Task IncreasingValuesIngredients(Recipe selectedRecipe)
        {
            IngredientsWeights = new();
            percentRatioCustomWieght = CustomWieght * 100 / selectedRecipe.WeightInRecipes.Sum(a => a.Weight);
            foreach (var w in selectedRecipe.WeightInRecipes)
            {
                IngredientsWeights.Add(new IngredientDto(w.Ingredient, w.Weight * percentRatioCustomWieght / 100));
            }
        }
    }
}