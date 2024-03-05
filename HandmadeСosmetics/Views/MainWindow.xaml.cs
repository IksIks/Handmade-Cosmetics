using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using System.Windows;

namespace HandmadeСosmetics.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataDBContex dDbCon = new DataDBContex();
            //dDbCon.Ingredients.Add(new Ingredient()
            //{
            //    Name = "Кислота UUUUU",
            //    IngridientCost = 500,
            //    PackageWeight = 1.5,
            //    UnitMeasurement = "кг"
            //});
            //dDbCon.SaveChanges();

            //dDbCon.Recipes.Add(new Recipe()
            //{
            //    Name = "Рецепт5",
            //    Ingredients = new List<Ingredient>()
            //    {
            //        new Ingredient( "Игридиент1", 0.8, "ry", 1500),
            //        new Ingredient( "Игридиент2", 0.9, "ry", 1500),
            //        new Ingredient( "Игридиент3", 0.5, "ry", 1500),
            //        new Ingredient( "Игридиент4", 1.2, "ry", 1500),
            //        new Ingredient( "Игридиент5", 5, "ry", 1500)
            //    },
            //    Products = new List<Product>()
            //    {
            //        new Product()
            //        {
            //            Name = "Test",
            //            Recipe = new Recipe()
            //            {
            //                Name = "Рецепт8",
            //                Ingredients = new List<Ingredient>()
            //                {
            //                    new Ingredient( "Игридиент9", 0.8, "ry", 1500),
            //                    new Ingredient( "Игридиент7", 0.9, "ry", 1500)
            //                }
            //            }
            //        }
            //    }
            //});
            //dDbCon.SaveChanges();

            //dDbCon.Products.Add(new Product()
            //{
            //    Name = "Коты",
            //    Recipe = new Recipe()
            //    {
            //        Name = "Рецепт5",
            //        Ingredients = new List<Ingredient>()
            //        {
            //            new Ingredient( "Игридиент1", 0.8, "ry", 1500),
            //            new Ingredient( "Игридиент2", 0.9, "ry", 1500),
            //            new Ingredient( "Игридиент3", 0.5, "ry", 1500),
            //            new Ingredient( "Игридиент4", 1.2, "ry", 1500),
            //            new Ingredient( "Игридиент5", 5, "ry", 1500)
            //        },
            //    },

            //    NetCost = 150,
            //});
            //dDbCon.SaveChanges();
        }
    }
}