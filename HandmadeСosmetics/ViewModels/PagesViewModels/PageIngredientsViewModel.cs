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
        private readonly QueryIngredientsTable query;

        public List<Ingredient> Ingredients
        {
            get => ingredients;
            set => Set(ref ingredients, value);
        }

        public PageIngredientsViewModel()
        {
            query = new QueryIngredientsTable(new DataCotnext.DataDBContex());
            Ingredients = query.Get();
            //TODO перенести запрос ингредиентов в Основное окно VM
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

        private void OnAddNewIngredientCommandExecuted(object p)
        {
            AddIngredientView addIngridientView = new();
            addIngridientView.ShowDialog();
            Ingredients = query.Get();
        }

        #endregion Команда добавления ингридиента

        #region Команда редактирования ингридиента

        public ICommand EditIngredientCommand { get; }

        private bool CanEditIngredientCommandExecute(object p)
        {
            return p is Ingredient;
        }

        private void OnEditIngredientCommandExecuted(Object p)
        {
            UpdateIngredientView updateIngridientView = new();
            UpdateIngredientEvent?.Invoke(p as Ingredient);
            updateIngridientView.ShowDialog();
        }

        #endregion Команда редактирования ингридиента

        public ICommand DeleteIngredientCommand { get; }

        private bool CanDeleteIngredientCommandExwcute(object p)
        {
            return p is Ingredient;
        }

        private void OnDeleteIngredientCommandExecuted(object p)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                query.DeleteIngredient((p as Ingredient).Id);
                Ingredients = query.Get();
            }
        }
    }
}