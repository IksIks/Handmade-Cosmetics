﻿using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageCatalogViewModel : ViewModelBase
    {
        public static event Action ActivateResponseToRecipeTableEvent;

        public static event Action<Product> UpdateProductEvent;

        private readonly QueryProductTable queryProductTable;
        private List<Product> productCatalog;
        private string section = "КАТАЛОГ";

        public List<Product> ProductCatalog
        {
            get => productCatalog;
            set => Set(ref productCatalog, value);
        }

        public PageCatalogViewModel()
        {
            queryProductTable = new QueryProductTable(new DataDBContex());
            MainWindowViewModel.SetResponseToBase += GetProductsFromDb;
            productCatalog = new();
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

        private async void OnAddNewProductCommandExecuted(object p)
        {
            AddProductView addProductView = new AddProductView();
            ActivateResponseToRecipeTableEvent?.Invoke();
            addProductView.ShowDialog();
            await GetProductsFromDb(section);
        }

        #endregion Команда добавления нового продукта

        #region Команда редактирования данных о продукте

        public ICommand EditRowCommand { get; }

        private bool CanEditRowCommandExecute(object p)
        {
            return p is Product;
        }

        private async void OnEditRowCommandExecuted(object p)
        {
            AddProductView updateProduct = new();
            ActivateResponseToRecipeTableEvent?.Invoke();
            UpdateProductEvent?.Invoke(p as Product);
            updateProduct.ShowDialog();
            await GetProductsFromDb(section);
        }

        #endregion Команда редактирования данных о продукте

        #region Команда удаления продукта

        public ICommand DeleteProductCommand { get; }

        private bool CanDeleteProductCommandExecute(object p) => p is Product;

        private async void OnDeleteProductCommandExecuted(Object p)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.OK)
            {
                await queryProductTable.DeleteProduct((p as Product).Id);
                await GetProductsFromDb(section);
            }
            //TODO при удалении рецепта сделать удаление и картинки
        }

        #endregion Команда удаления продукта

        private async Task GetProductsFromDb(string b)
        {
            if (b.Equals(section))
                ProductCatalog = await queryProductTable.GetProducts();
        }
    }
}