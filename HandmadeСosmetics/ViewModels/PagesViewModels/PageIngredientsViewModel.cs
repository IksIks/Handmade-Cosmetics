using HandmadeСosmetics.Command;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.Views.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageIngredientsViewModel : ViewModelBase
    {
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
            AddNewIngredientCommand = new LambdaCommand(OnAddNewIngredientCommandExecuted, CanAddNewIngredientCommandWxwcute);
            //TODO перенести запрос ингредиентов в Основное окно VM
        }

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
    }
}