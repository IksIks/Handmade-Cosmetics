using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.Views.Pages;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
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

        public static event Func<string, Task> SetResponseToBase;

        public MainWindowViewModel()
        {
            pageCatalog = new PageCatalog();
            pageIngredients = new PageIngredients();
            pageRecipes = new PageRecipes();
            pageClients = new PageClients();
            SetCurrentPageCommand = new LambdaCommand(OnSetCurrentPageCommandExecuted);
            СalculatorCommand = new LambdaCommand(OnСalculatorCommandExecuted);
            CreareFolderForImages();
        }

        public ICommand СalculatorCommand { get; }

        private void OnСalculatorCommandExecuted(object p)
        {
            Process.Start("win32calc.exe");
        }

        public ICommand SetCurrentPageCommand { get; }

        private void OnSetCurrentPageCommandExecuted(object p)
        {
            var b = p as TextBlock;
            switch (b.Text)
            {
                case "КАТАЛОГ":
                    CurrentPage = PageCatalog;
                    SetResponseToBase?.Invoke(b.Text);
                    break;

                case "КЛИЕНТЫ":
                    CurrentPage = PageClients;
                    break;

                case "РЕЦЕПТЫ":
                    CurrentPage = PageRecipes;
                    SetResponseToBase?.Invoke(b.Text);
                    break;

                case "КОМПОНЕНТЫ":
                    CurrentPage = PageIngredients;
                    SetResponseToBase?.Invoke(b.Text);
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