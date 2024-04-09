using Microsoft.EntityFrameworkCore;
using ProductAssesment.ClientModel;
using ProductAssesment.Components.Pages;
using ProductAssesment.Database;
using ProductAssesment.Interface;
using ProductAssesment.Models;

namespace ProductAssesment.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<bool> AddProduct(ProductModel product)
        {
            try
            {
                var entity = new Models.Product { Name = product.Name,Code=product.Code,StockAvailable=product.StockAvailable,UnitPrice=product.UnitPrice };
                dbContext.Products.Add(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveProduct(long id)
        {
            try
            {
                var isExists = await dbContext.Products.Where(i => i.Id ==id).FirstOrDefaultAsync();
                if (isExists != null)
                {
                    dbContext.Products.Remove(isExists);
                }

                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductModel> GetProductById(long id)
        {
            try
            {
                return await dbContext.Products.Where(a => a.Id == id).Select(t => new ProductModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Code = t.Code,
                    StockAvailable = t.StockAvailable,
                    UnitPrice = t.UnitPrice
                }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            try
            {
                return await dbContext.Products.Select(t=> new ProductModel()
                {
                    Id= t.Id,
                    Name= t.Name,
                    Code= t.Code,
                    StockAvailable= t.StockAvailable,
                    UnitPrice= t.UnitPrice
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateProduct(ProductModel product)
        {
            try
            {
                var entity = await dbContext.Products.FindAsync(product.Id);

                if (entity != null)
                {
                    entity.Name = product.Name;
                    entity.Code = product.Code;
                    entity.StockAvailable = product.StockAvailable;
                    entity.UnitPrice = product.UnitPrice;
                    await dbContext.SaveChangesAsync();

                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
