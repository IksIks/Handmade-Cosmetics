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
                 (dbContext.Recipes, p => p.RecipeId, a => a.Id,
                 (p, a) => new DTO_Product(p.Id, p.Name, p.Photo, p.NetCost, a.Name, p.Price, p.Weight)).ToList();
            //(p, a) => new DTO_Product(p, a.Name)).ToList();
            //TODO  почему то не срабатывает этот конструктор, приходит NULL в строке для Photo
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
                                .SetProperty(p => p.RecipeId, product.Recipe.Id)
                                .SetProperty(p => p.Price, product.Price));
        }

<<<<<<< HEAD
        public async Task DeleteProduct(int id)
=======
        public async void DeleteProduct(int id)
>>>>>>> 43278b2f7620ef892ee2d40667c0e4a5796fc45e
        {
            await dbContext.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
        }
    }
}