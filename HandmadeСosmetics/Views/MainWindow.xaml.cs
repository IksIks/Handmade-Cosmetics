using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace HandmadeСosmetics.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataDBContex dBCon = new DataDBContex();
            //Random r = new Random();

            //for (int i = 0; i < 10; i++)
            //{
            //    double r1 = r.Next(100, 600);
            //    double r2 = r.Next(100, 600);
            //    dBCon.Add(new Ingredient()
            //    {
            //        Name = $"Ингредиент-{i}",
            //        IngridientCost = r1,
            //        PackageWeight = r2,
            //        UnitMeasurement = "гр.",
            //        CostPerUnitMeasurement = r1 / r2
            //    });
            //    dBCon.SaveChanges();
            //}
        }
    }
}