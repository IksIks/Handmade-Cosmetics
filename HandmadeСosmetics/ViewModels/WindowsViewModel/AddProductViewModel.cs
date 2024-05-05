using HandmadeСosmetics.Command;
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
    public class AddProductViewModel : ViewModelBase
    {
        private List<Recipe> recipes;
        private readonly QueryRecipeTable queryRecipeTable;
        private readonly QueryProductTable queryProductTable;
        private Product product;
        private string addedImagePath = default;
        private string buttonContext = "Добавить";

        public string ButtonContext
        {
            get => buttonContext;
            set => Set(ref buttonContext, value);
        }

        private int selectedIndex;

        public int SelectedIndex
        {
            get => selectedIndex;
            set => Set(ref selectedIndex, value);
        }

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
            PageCatalogViewModel.ActivateResponseToRecipeTableEvent += GetAllRecipes;
            PageCatalogViewModel.UpdateProductEvent += UpdateProduct;
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted);
            AddOrUpdateCommand = new LambdaCommand(OnAddOrUpdateCommandExecuted, CanAddOrUpdateCommandExecute);
            SelectFileCommand = new LambdaCommand(OnSelectFileCommandExecuted);
            //UpdateCommand = new LambdaCommand(OnUpdateCommandExecuted, CanUpdateCommandExecute);
        }

        #region Команда добавления продукта

        public ICommand AddOrUpdateCommand { get; }

        private bool CanAddOrUpdateCommandExecute(object p)
        {
            return IsLinesFilledCorrectly();
        }

        private void OnAddOrUpdateCommandExecuted(object p)
        {
            if (ButtonContext.Equals("Добавить"))
                queryProductTable?.AddProduct(Product);
            if (ButtonContext.Equals("Изменить"))
                queryProductTable.UpdateProduct(Product);
            Application.Current.Windows[1].Close();
        }

        #endregion Команда добавления продукта

        //#region Команда обновления продукта

        //public ICommand UpdateCommand { get; }

        //private bool CanUpdateCommandExecute(object p)
        //{
        //    return IsLinesFilledCorrectly();
        //}

        //private void OnUpdateCommandExecuted(object p)
        //{
        //    queryProductTable.UpdateProduct(Product);
        //    Application.Current.Windows[1].Close();
        //}

        //#endregion Команда обновления продукта

        #region Команда выбора файла

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
                Product.Photo = GetPathCreatedImage(dialog);
            }
        }

        #endregion Команда выбора файла

        private string GetPathCreatedImage(OpenFileDialog dialog)
        {
            Image addedImage = Image.Thumbnail(dialog.FileName, 50, 50);
            addedImagePath = Directory.GetCurrentDirectory() + $@"\Images\Thumb_{dialog.SafeFileName}";
            if (File.Exists(addedImagePath))
            {
                MessageBox.Show("Такой файл уже существует", "!", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
            addedImage.WriteToFile(addedImagePath + "[Q=50]");
            addedImage.Close();
            return addedImagePath;
        }

        #region Команда отмены

        public ICommand CancelCommand { get; }

        private void OnCancelCommandExecuted(object p)
        {
            // TODO : Сделать удаление файла после отмены создания Продукта
            //Product.Photo = "";
            //File.Delete(addedImagePath);
            Application.Current.Windows[1].Close();
            PageCatalogViewModel.ActivateResponseToRecipeTableEvent -= GetAllRecipes;
        }

        #endregion Команда отмены

        private void GetAllRecipes()
        {
            Recipes = queryRecipeTable.GetRecipesNamesOnly();
        }

        private bool IsLinesFilledCorrectly()
        {
            if (String.IsNullOrEmpty(Product.Name) ||
                Product.Recipe == null ||
                Product.Weight < 0 ||
                Product.Price < 0)
                return false;
            return true;
        }

        private void UpdateProduct(Product product)
        {
            ButtonContext = "Изменить";
            SelectedIndex = Recipes.FindIndex(r => r.Name == product.Recipe.Name);
            Product.Id = product.Id;
            Product.Name = product.Name;
            Product.Photo = product.Photo;
            Product.NetCost = product.NetCost;
            Product.Price = product.Price;
            Product.Weight = product.Weight;
            PageCatalogViewModel.UpdateProductEvent -= UpdateProduct;
        }
    }
}