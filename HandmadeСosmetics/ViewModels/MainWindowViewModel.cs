using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.Views.Pages;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private readonly DataDBContex dbContext;
        private readonly QueryProductTable queryProductTable;
        private readonly QueryIngredientsTable queryIngredientsTable;
        private readonly QueryRecipeTable queryRecipeTable;

        #region Pages

        private Page currentPage;
        private Page pageRecipes;
        private Page pageCatalog;
        private Page pageClients;
        private Page pageIngredients;

        public Page CurrentPage
        {
            get { return currentPage; }
            set { Set(ref currentPage, value); }
        }

        public Page PageCatalog
        {
            get { return pageCatalog; }
            private set { pageCatalog = value; }
        }

        public Page PageClients
        {
            get { return pageClients; }
            private set { pageClients = value; }
        }

        public Page PageIngredients
        {
            get { return pageIngredients; }
            private set { pageIngredients = value; }
        }

        public Page PageRecipes
        {
            get { return pageRecipes; }
            private set { pageRecipes = value; }
        }

        #endregion Pages

        public MainWindowViewModel()
        {
            dbContext = new DataDBContex();
            queryProductTable = new(dbContext);
            queryIngredientsTable = new(dbContext);
            queryRecipeTable = new(dbContext);
            pageCatalog = new PageCatalog();
            pageIngredients = new PageIngredients();
            pageRecipes = new PageRecipes();
            pageClients = new PageClients();
            SetCurrentPageCommand = new LambdaCommand(OnSetCurrentPageCommandExecuted);
            CreareFolderForImages();
        }

        public ICommand SetCurrentPageCommand { get; }

        private void OnSetCurrentPageCommandExecuted(object p)
        {
            var b = p as Button;
            switch (b.Content)
            {
                case "КАТАЛОГ":
                    CurrentPage = PageCatalog;
                    //queryProductTable.GetProducts();
                    break;

                case "КЛИЕНТЫ":
                    CurrentPage = PageClients;
                    break;

                case "РЕЦЕПТЫ":
                    CurrentPage = PageRecipes;
                    //queryRecipeTable.GetRecipes();
                    break;

                case "КОМПОНЕНТЫ":
                    CurrentPage = PageIngredients;
                    break;

                default: break;
            }
        }

        private void CreareFolderForImages()
        {
            string path = Directory.GetCurrentDirectory() + "\\Images";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}