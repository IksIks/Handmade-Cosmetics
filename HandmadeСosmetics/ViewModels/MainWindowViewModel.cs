using HandmadeСosmetics.Views.Pages;
using System.Windows.Controls;

namespace HandmadeСosmetics.ViewModels
{
    internal class MainWindowViewModel
    {
        private Page currentContent;
        private Page pageRecipes;
        private Page pageCatalog;
        private Page pageClients;
        private Page pageComponents;

        public Page CurrentContent
        {
            get { return currentContent; }
            set { currentContent = value; }
        }

        public Page PageCatalog
        {
            get { return pageCatalog; }
            set { pageCatalog = value; }
        }

        public Page PageClients
        {
            get { return pageClients; }
            set { pageClients = value; }
        }

        public Page PageComponents
        {
            get { return pageComponents; }
            set { pageComponents = value; }
        }

        public Page PageRecipes
        {
            get { return pageRecipes; }
            set { pageRecipes = value; }
        }

        public MainWindowViewModel()
        {
        }
    }
}