using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.DTO;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageCatalogViewModel : ViewModelBase
    {
        public static event Func<Task> ActivateResponseToRecipeTableEvent;

        public static event Action<DTO_Product> UpdateProductEvent;

        private QueryProductTable query { get; }
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
            //TODO перенести запрос продуктов в Основное окно VM
            EditRowCommand = new LambdaCommand(OnEditRowCommandExecuted, CanEditRowCommandExecute);
            AddNewProductCommand = new LambdaCommand(OnAddNewProductCommandExecuted, CanAddNewProductCommandExecete);
            DeleteProductCommand = new LambdaCommand(OnDeleteProductCommandExecuted, CanDeleteProductCommandExecute);
        }

        #region Команда добавления нового продукта

        public ICommand AddNewProductCommand { get; }

        private bool CanAddNewProductCommandExecete(object p)
        {
            if (ProductCatalog.Count >= 0)
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

        #endregion Команда добавления нового продукта

        #region Команда редактирования данных о продукте

        public ICommand EditRowCommand { get; }

        private bool CanEditRowCommandExecute(object p)
        {
            return p is DTO_Product;
        }

        private async void OnEditRowCommandExecuted(object p)
        {
            UpdateProductView updateProduct = new();
            ActivateResponseToRecipeTableEvent?.Invoke();
            UpdateProductEvent?.Invoke(p as DTO_Product);
            updateProduct.ShowDialog();
            ProductCatalog = query.GetProducts();
        }

        #endregion Команда редактирования данных о продукте

        #region Команда удаления продукта

        public ICommand DeleteProductCommand { get; }

        private bool CanDeleteProductCommandExecute(object p) => p is DTO_Product;

        private void OnDeleteProductCommandExecuted(Object p)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                query.DeleteProduct((p as DTO_Product).Id);
                ProductCatalog = query.GetProducts();
            }
        }

        #endregion Команда удаления продукта
    }
}