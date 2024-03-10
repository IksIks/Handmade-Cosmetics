﻿using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.ViewModels.PagesViewModels;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Image = NetVips.Image;

namespace HandmadeСosmetics.ViewModels.WindowsViewModel
{
    internal class AddProductViewModel : ViewModelBase
    {
        private List<Recipe> recipes;
        private QueryRecipeTable queryRecipeTable;
        private QueryProductTable queryProductTable;
        private Product product;

        public Product Product
        {
            get => product;
            set => Set(ref product, value);
        }

        public List<Recipe> Recipes
        {
            get => recipes;
            set => Set(ref recipes, value);
        }

        public AddProductViewModel()
        {
            product = new Product();
            recipes = new List<Recipe>();
            queryRecipeTable = new QueryRecipeTable(new DataDBContex());
            queryProductTable = new QueryProductTable(new DataDBContex());
            PageCatalogViewModel.ActivateResponseToRecipeTable += GetAllRecipes;
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted);
            AddCommand = new LambdaCommand(OnAddCommandExecuted, CanAddCommandExecute);
            SelectFileCommand = new LambdaCommand(OnSelectFileCommandExecuted);
        }

        //------------------------------------------------------------------------------------------------------------------------------

        public ICommand SelectFileCommand { get; }

        private void OnSelectFileCommandExecuted(object p)
        {
            OpenFileDialog dialog = new();
            dialog.Title = "Выбор фото";
            dialog.DefaultDirectory = Directory.GetCurrentDirectory();
            dialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == true)
            {
                Product.Photo = ResizeImage(dialog);
            }
        }

        private string ResizeImage(OpenFileDialog dialog)
        {
            Image addedImage = Image.Thumbnail(dialog.FileName, 50, 50);
            string path = Directory.GetCurrentDirectory() + $@"\Images\Thumb_{dialog.SafeFileName}";
            if (File.Exists(path))
            {
                MessageBox.Show("Такой файл уже существует", "!", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
            addedImage.WriteToFile(path + "[Q=50]");
            return path;
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public ICommand CancelCommand { get; }

        private void OnCancelCommandExecuted(object p)
        {
            Application.Current.Windows[1].Close();
            PageCatalogViewModel.ActivateResponseToRecipeTable -= GetAllRecipes;
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public ICommand AddCommand { get; }

        private bool CanAddCommandExecute(object p)
        {
            if (String.IsNullOrEmpty(Product.Name) ||
                Product.Recipe == null ||
                String.IsNullOrEmpty(Product.Photo))
                return false;
            return true;
        }

        private void OnAddCommandExecuted(object p)
        {
            queryProductTable?.AddProduct(Product);
            Application.Current.Windows[1].Close();
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private async Task GetAllRecipes()
        {
            Recipes = await queryRecipeTable.GetRecipes();
        }
    }
}