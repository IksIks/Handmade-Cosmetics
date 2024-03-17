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
            Ingredient ing1 = new Ingredient()
            {
                Name = "Кислота12",
                IngridientCost = 876,
                PackageWeight = 1.5,
                UnitMeasurement = "кг"
            };

            Ingredient ing2 = new Ingredient()
            {
                Name = "Кислота2344",
                IngridientCost = 334,
                PackageWeight = 1.5,
                UnitMeasurement = "кг"
            };

            Ingredient ing3 = new Ingredient()
            {
                Name = "Соль",
                IngridientCost = 200,
                PackageWeight = 1.5,
                UnitMeasurement = "кг"
            };

            //dDbCon.Ingredients.AddRange(ing1, ing2, ing3);
            //dDbCon.SaveChanges();

            //Recipe rec1 = new Recipe()
            //{
            //    Ingredients = { ing1, ing2, ing3 },
            //    WeightInRecipes = { new WeightInRecipe(20), new WeightInRecipe(320), new WeightInRecipe(1000) },
            //    Name = "Рецепт4"
            //};
            //dDbCon.Recipes.Add(rec1);
            //dDbCon.SaveChanges();

            //dDbCon.Recipes.Add(new Recipe()
            //{
            //    Name = "Рецепт4",

            //    Ingredients = new List<Ingredient>()
            //        {
            //            new Ingredient("Игридиент3", 0.5, "ry", 1500),
            //            new Ingredient("Игридиент4", 1.2, "ry", 1500)
            //        },
            //    Products = new List<Product>()
            //        {
            //            new Product()
            //            {
            //                Name = "Test",
            //                Recipe = new Recipe()
            //                {
            //                    Name = "Рецепт8",
            //                    Ingredients = new List<Ingredient>()
            //                    {
            //                        new Ingredient( "Игридиент6", 0.8, "ry", 1500),

            //                        new Ingredient( "Игридиент8", 0.9, "ry", 1500)
            //                    }
            //                }
            //            }
            //        }
            //});
            //dDbCon.SaveChanges();

            //dDbCon.Products.Add(new Product()
            //{
            //    Name = "Коты",
            //    Recipe = new Recipe()
            //    {
            //        Name = "Рецепт5",
            //        Ingredients = new List<Ingredient>()
            //            {
            //                new Ingredient( "Игридиент1", 0.8, "ry", 1500, new List<WeightInRecipe>{new WeightInRecipe(547), new WeightInRecipe(139) }),
            //                new Ingredient( "Игридиент2", 0.9, "ry", 1500, new List<WeightInRecipe>{new WeightInRecipe(459), new WeightInRecipe(341) }),
            //                new Ingredient( "Игридиент5", 0.5, "ry", 1500, new List<WeightInRecipe>{new WeightInRecipe(744), new WeightInRecipe(697) })
            //            },
            //    },

            //    NetCost = 150,
            //});
            //dDbCon.SaveChanges();
        }
    }
}