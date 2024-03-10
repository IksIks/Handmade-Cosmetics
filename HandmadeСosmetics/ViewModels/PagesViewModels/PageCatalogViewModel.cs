using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.DTO;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.Views.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageCatalogViewModel : ViewModelBase
    {
        public static event Func<Task> ActivateResponseToRecipeTableEvent;

        public static event Action<DTO_Product> UpdateProductEvent;

        private QueryProductTable query { get; set; }

        private List<DTO_Product> productCatalog;

        public List<DTO_Product> ProductCatalog
        {
            get => productCatalog;
            set => Set(ref productCatalog, value);
        }

        public PageCatalogViewModel()
        {
            query = new QueryProductTable(new DataDBContex());
            ProductCatalog = query.GetProducts();
            EditRowCommand = new LambdaCommand(OnEditRowCommandExecuted, CanEditRowCommandExecute);
            AddNewProductCommand = new LambdaCommand(OnAddNewProductCommandExecuted, CanAddNewProductCommandExecete);
        }

        public ICommand EditRowCommand { get; }

        private bool CanEditRowCommandExecute(object p)
        {
            return p is DTO_Product;
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
            ActivateResponseToRecipeTableEvent?.Invoke();
            addProductView.ShowDialog();
            ProductCatalog = query.GetProducts();
        }
    }
}