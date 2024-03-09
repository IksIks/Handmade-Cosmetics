using HandmadeСosmetics.Command;
using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.DTO;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.ViewModels.PagesViewModels;
using System.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.WindowsViewModel
{
    internal class AddProductViewModel : ViewModelBase
    {
        private List<Recipe> recipes;
        private QueryRecipeTable queryRecipeTable;
        private QueryProductTable queryProductTable;

        public DTO_Product DTO_Product { get; set; }

        public List<Recipe> Recipes
        {
            get => recipes;
            set => Set(ref recipes, value);
        }

        public string FilePath { get; set; } = "Здесь будет указанный путь к файлу";

        public AddProductViewModel()
        {
            DTO_Product = new DTO_Product();
            DTO_Product.Photo = "fdfdff";
            recipes = new List<Recipe>();
            queryRecipeTable = new QueryRecipeTable(new DataDBContex());
            PageCatalogViewModel.ActivateResponseToRecipeTable += GetAllRecipes;
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted);
            AddCommand = new LambdaCommand(OnAddCommandExecuted, CanAddCommandExecute);
        }

        public ICommand CancelCommand { get; }

        private void OnCancelCommandExecuted(object p)
        {
            Application.Current.Windows[1].Close();
            PageCatalogViewModel.ActivateResponseToRecipeTable -= GetAllRecipes;
        }

        public ICommand AddCommand { get; }

        private bool CanAddCommandExecute(object p)
        {
            if (String.IsNullOrEmpty(DTO_Product.Name) ||
                String.IsNullOrEmpty(DTO_Product.RecipeName) ||
                String.IsNullOrEmpty(DTO_Product.Photo))
                return false;
            return true;
        }

        private void OnAddCommandExecuted(object p)
        {
            queryProductTable.AddRecipe(DTO_Product);
        }

        private async Task GetAllRecipes()
        {
            Recipes = await queryRecipeTable.GetRecipes();
        }
    }
}