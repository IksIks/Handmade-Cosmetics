using HandmadeСosmetics.DataCotnext;
using HandmadeСosmetics.Models.DTO;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using Microsoft.EntityFrameworkCore;

namespace HandmadeСosmetics.Models.DB
{
    internal class QueryProductTable(DataDBContex dbContext)
    {
        private DataDBContex dbContext { get; set; } = dbContext;

        public List<DTO_Product> GetProducts()
        {
            return dbContext.Products.Join
                 (dbContext.Recipes, c => c.RecipeId, a => a.Id,
                 (c, a) => new DTO_Product(c.Id, c.Name, c.Photo, c.NetCost, a.Name)).ToList();
        }

        public void AddProduct(Product product)
        {
            dbContext.Products.Add(new Product(product.Id, product.Name, product.Photo, product.NetCost, product.Recipe.Id));
            dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            dbContext.Products.Where(p => p.Id == product.Id)
                                .ExecuteUpdateAsync(s =>
                                s.SetProperty(p => p.Id, product.Id)
                                .SetProperty(p => p.Name, product.Name)
                                .SetProperty(p => p.Recipe, product.Recipe)
                                .SetProperty(p => p.NetCost, product.NetCost));
        }
    }
}