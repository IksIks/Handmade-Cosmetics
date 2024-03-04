using HandmadeСosmetics.Command;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageCatalogViewModel
    {
        public ObservableCollection<Product> ProductCatalog { get; set; } = new();

        public PageCatalogViewModel()
        {
            EditRowCommand = new LambdaCommand(OnEditRowCommandExecuted, CanEditRowCommandExecute);
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

        private void OnEditRowCommandExecuted(object p)
        {
            if (p is Product prod)
            {
                MessageBox.Show($"{prod.Name}");
            }
        }
    }
}