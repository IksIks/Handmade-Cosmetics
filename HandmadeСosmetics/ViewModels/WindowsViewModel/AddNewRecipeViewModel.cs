using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.DTO;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
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
        private double parseWeight;

        public string Weight
        {
            get => weight;
            set => Set(ref weight, value);
        }

        public List<Ingredient> Ingredients { get; set; } = new();
        public Ingredient SelectedItem { get; set; } = new();
        public DTO_Ingredient DTO_SelectedItem { get; set; }

        //public ObservableCollection<Ingredient> IngredientsWeights { get; set; } = new();
        public ObservableCollection<DTO_Ingredient> IngredientsWeights { get; set; } = new();

        public string RecipeName { get; set; }

        public AddNewRecipeViewModel()
        {
            queryRecipeTable = new(new DataDBContex());
            queryIngredientsTable = new(new DataDBContex());
            Ingredients = queryIngredientsTable.Get();
            AddIngredientToCollectionCommand = new LambdaCommand(OnAddIngredientToCollectionCommandExecuted, CanAddIngredientToCollectionCommandExecute);
            DeleteIngredientFromCollectionCommand = new LambdaCommand(OnDeleteIngredientFromCollectionCommandExecuted, CanDeleteIngredientFromCollectionCommandExecute);
            AddRecipeCommand = new LambdaCommand(OnAddRecipeCommandExecuted, CanAddRecipeCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted);
        }

        #region Команда Добавление ингредиентов к рецепту

        public ICommand AddIngredientToCollectionCommand { get; }

        private bool CanAddIngredientToCollectionCommandExecute(object p)
        {
            if (!double.TryParse(Weight, out parseWeight))
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
            IngredientsWeights.Add(new DTO_Ingredient(SelectedItem, parseWeight));
            Weight = default;
        }

        #endregion Команда Добавление ингредиентов к рецепту

        #region Команда удаление ингредиентов из рецепта

        public ICommand DeleteIngredientFromCollectionCommand { get; }

        private bool CanDeleteIngredientFromCollectionCommandExecute(object p)
        {
            return DTO_SelectedItem is DTO_Ingredient;
        }

        private void OnDeleteIngredientFromCollectionCommandExecuted(object p)
        {
            IngredientsWeights.Remove(DTO_SelectedItem);
        }

        #endregion Команда удаление ингредиентов из рецепта

        #region Команда создания рецепта

        public ICommand AddRecipeCommand { get; }

        private bool CanAddRecipeCommandExecute(object p)
        {
            if (IngredientsWeights.Count <= 0 || String.IsNullOrEmpty(RecipeName))
                return false;
            return true;
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
    }
}