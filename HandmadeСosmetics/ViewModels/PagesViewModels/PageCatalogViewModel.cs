using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.DTO;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageCatalogViewModel
    {
        public static event Func<Task> ActivateResponseToRecipeTable;

        private DataDBContex dbContext { get; set; }
        private QueryProductTable query { get; set; }
        public ObservableCollection<DTO_Product> ProductCatalog { get; set; }

        public PageCatalogViewModel()
        {
            query = new QueryProductTable(new DataDBContex());
            ProductCatalog = new ObservableCollection<DTO_Product>((query.GetProducts()));
            EditRowCommand = new LambdaCommand(OnEditRowCommandExecuted, CanEditRowCommandExecute);
            AddNewProductCommand = new LambdaCommand(OnAddNewProductCommandExecuted, CanAddNewProductCommandExecete);
        }

        public ICommand EditRowCommand { get; }

        private bool CanEditRowCommandExecute(object p)
        {
            if (p is Product)
            {
                return true;
            }
            return false;
        }

        private async void OnEditRowCommandExecuted(object p)
        {
        }

        public ICommand AddNewProductCommand { get; }

        private bool CanAddNewProductCommandExecete(object p)
        {
            if (ProductCatalog.Count > 0)
                return true;
            return false;
        }

        private void OnAddNewProductCommandExecuted(object p)
        {
            AddProductView addProductView = new AddProductView();
            ActivateResponseToRecipeTable?.Invoke();
            addProductView.ShowDialog();
        }
    }
}