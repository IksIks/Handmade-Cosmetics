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

        public async Task AddProduct(Product product)
        {
            await dbContext.Products.AddAsync(new Product(product.Name, product.Photo, product.NetCost, product.Recipe.Id));
            dbContext.SaveChanges();
        }

        //public void UpdateProduct(DTO_Product dto_product)
        //{
        //    dbContext.Products.Where(p => p.Id == dto_product.Id)
        //                        .ExecuteUpdateAsync(s =>
        //                        s.SetProperty(p => p.Name, dto_product.Name)
        //                        .SetProperty(p => p.Recipe.Id, dto_product.R)
        //                        .SetProperty(p => p.NetCost, dto_product.NetCost));
        //}

        public async Task AddRecipe(DTO_Product dto_Product)
        {
            //await dbContext.Products.AddAsync(dto_Product);
        }
    }
}