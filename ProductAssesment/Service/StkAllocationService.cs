using Microsoft.EntityFrameworkCore;
using ProductAssesment.ClientModel;
using ProductAssesment.Database;
using ProductAssesment.Interface;

namespace ProductAssesment.Service
{
    public class StkAllocationService : IStkAllocationService
    {
        private readonly ApplicationDbContext dbContext;

        public StkAllocationService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<bool> AddStocktoLocation(StockAllocationModel model)
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var stkEntity = new Models.StockAllocation { AllocatedDate = DateTime.Now,AllocatedQty=model.AllocatedQty,ProductId=model.ProductId,LocationId=model.LocationId };
                    dbContext.StockAllocations.Add(stkEntity);
                    await dbContext.SaveChangesAsync();
                    var prdEntity = await dbContext.Products.FindAsync(model.ProductId);

                    if (prdEntity != null)
                    {
                        prdEntity.StockAvailable = prdEntity.StockAvailable-model.AllocatedQty;
                        await dbContext.SaveChangesAsync();

                    }
                    transaction.Commit(); 
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<List<StockAllocationModel>> GetAllStockAllocationDetails()
        {
            try
            {
                return await dbContext.StockAllocations.Include(t=>t.Location).Include(t=>t.Product).Select(t => new StockAllocationModel()
                {
                    Id = t.Id,
                    ProductId = t.ProductId,
                    LocationId = t.LocationId,
                    AllocatedDate = t.AllocatedDate,
                    AllocatedQty = t.AllocatedQty,
                    ProductModel = new ProductModel
                    {
                        Id = t.Product.Id,
                        Name = t.Product.Name,
                        Code = t.Product.Code,
                        StockAvailable = t.Product.StockAvailable,
                        UnitPrice = t.Product.UnitPrice
                    },
                    LocationModel = new LocationModel
                    {
                        Id = t.Location.Id,
                        Code = t.Location.Code,
                        Name = t.Location.Name,
                    }

                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveStocktoLocation(StockAllocationModel model)
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var isExists = await dbContext.StockAllocations.Where(i => i.Id == model.Id).FirstOrDefaultAsync();
                    if (isExists != null)
                    {
                        dbContext.StockAllocations.Remove(isExists);
                    }

                    await dbContext.SaveChangesAsync();
                    var prdEntity = await dbContext.Products.FindAsync(model.ProductId);

                    if (prdEntity != null)
                    {
                        prdEntity.StockAvailable = prdEntity.StockAvailable + model.AllocatedQty;
                        await dbContext.SaveChangesAsync();

                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<bool> UpdateStocktoLocation(StockAllocationModel model)
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var entity = await dbContext.StockAllocations.FindAsync(model.Id);

                    if (entity != null)
                    {
                        entity.AllocatedQty = model.AllocatedQty;
                        entity.AllocatedDate = model.AllocatedDate;
                        await dbContext.SaveChangesAsync();

                    }
                    var prdEntity = await dbContext.Products.FindAsync(model.ProductId);

                    if (prdEntity != null)
                    {
                        prdEntity.StockAvailable = prdEntity.StockAvailable - model.AllocatedQty;
                        await dbContext.SaveChangesAsync();

                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
