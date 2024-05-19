using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;

namespace HandmadeСosmetics.Models.DB
{
    internal class QueryProductTable(DataDBContex dbContext)
    {
        private DataDBContex dbContext = dbContext;

        public async Task<List<Product>> GetProducts()
        {
            using (dbContext = new())
            {
                //return dbContext.Products.Include(p => p.Recipe).ToList();
                var ingrCollection = dbContext.Ingredients.Select(a => new { a.Id, a.CostPerUnitMeasurement });
                var collection = dbContext.Products.Include(p => p.Recipe.WeightInRecipes).ToList();
                foreach (var product in collection)
                {
                    product.NetCost = product.Recipe.WeightInRecipes.Sum(a => a.Weight * ingrCollection
                                                                    .First(b => b.Id == a.IngredientId).CostPerUnitMeasurement)
                                      / product.Recipe.WeightInRecipes.Sum(b => b.Weight)
                                      * product.Weight;
                }
                await dbContext.SaveChangesAsync();
                return collection;
            }
        }

        public async Task AddProduct(Product product)
        {
            await dbContext.Products.AddAsync(new Product(product.Name, product.Photo, product.NetCost, product.Recipe.Id, product.Price, product.Weight));
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            await dbContext.Products.Where(p => p.Id == product.Id)
                                .ExecuteUpdateAsync(s =>
                                s.SetProperty(p => p.Name, product.Name)
                                .SetProperty(p => p.Photo, product.Photo)
                                .SetProperty(p => p.NetCost, product.NetCost)
                                .SetProperty(p => p.Weight, product.Weight)
                                .SetProperty(p => p.RecipeId, product.Recipe.Id)
                                .SetProperty(p => p.Price, product.Price));
        }

        public async Task DeleteProduct(int id)
        {
            using (dbContext = new())
            {
                await dbContext.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
            }
        }
    }
}