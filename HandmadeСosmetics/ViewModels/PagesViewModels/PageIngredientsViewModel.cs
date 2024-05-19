using HandmadeСosmetics.Command;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageIngredientsViewModel : ViewModelBase
    {
        public static Action<Ingredient> UpdateIngredientEvent;
        private List<Ingredient> ingredients;
        private readonly QueryIngredientsTable queryIngredientsTable;
        private string section = "КОМПОНЕНТЫ";

        public List<Ingredient> Ingredients
        {
            get => ingredients;
            set => Set(ref ingredients, value);
        }

        public PageIngredientsViewModel()
        {
            queryIngredientsTable = new QueryIngredientsTable(new DataCotnext.DataDBContex());
            ingredients = new();
            MainWindowViewModel.SetResponseToBase += GetIngredientsFromDb;
            AddNewIngredientCommand = new LambdaCommand(OnAddNewIngredientCommandExecuted, CanAddNewIngredientCommandWxwcute);
            EditIngredientCommand = new LambdaCommand(OnEditIngredientCommandExecuted, CanEditIngredientCommandExecute);
            DeleteIngredientCommand = new LambdaCommand(OnDeleteIngredientCommandExecuted, CanDeleteIngredientCommandExwcute);
        }

        #region Команда добавления ингридиента

        public ICommand AddNewIngredientCommand { get; }

        private bool CanAddNewIngredientCommandWxwcute(object p)
        {
            if (Ingredients.Count >= 0) return true;
            return false;
        }

        private async void OnAddNewIngredientCommandExecuted(object p)
        {
            AddIngredientView addIngridientView = new();
            addIngridientView.ShowDialog();
            await GetIngredientsFromDb(section);
            //Ingredients = queryIngredientsTable.Get();
        }

        #endregion Команда добавления ингридиента

        #region Команда редактирования ингридиента

        public ICommand EditIngredientCommand { get; }

        private bool CanEditIngredientCommandExecute(object p)
        {
            return p is Ingredient;
        }

        private async void OnEditIngredientCommandExecuted(Object p)
        {
            AddIngredientView updateIngridientView = new();
            UpdateIngredientEvent?.Invoke(p as Ingredient);
            updateIngridientView.ShowDialog();
            await GetIngredientsFromDb(section);
        }

        #endregion Команда редактирования ингридиента

        #region Команда удаления ингредиента

        public ICommand DeleteIngredientCommand { get; }

        private bool CanDeleteIngredientCommandExwcute(object p)
        {
            return p is Ingredient;
        }

        private async void OnDeleteIngredientCommandExecuted(object p)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                await queryIngredientsTable.DeleteIngredient((p as Ingredient).Id);
                await GetIngredientsFromDb(section);
            }
        }

        #endregion Команда удаления ингредиента

        private async Task GetIngredientsFromDb(string b)
        {
            if (b.Equals(section))
                Ingredients = await queryIngredientsTable.Get();
        }
    }
}