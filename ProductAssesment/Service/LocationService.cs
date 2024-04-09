using Microsoft.EntityFrameworkCore;
using ProductAssesment.ClientModel;
using ProductAssesment.Database;
using ProductAssesment.Interface;
using ProductAssesment.Migrations;

namespace ProductAssesment.Service
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext dbContext;

        public LocationService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<bool> AddLocation(LocationModel location)
        {
            try
            {
                var entity = new Models.Location { Name = location.Name, Code = location.Code };
                dbContext.Locations.Add(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LocationModel> GetLocationById(long id)
        {
            try
            {
                return await dbContext.Locations.Where(a => a.Id == id).Select(t => new LocationModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Code = t.Code
                }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LocationModel>> GetLocations()
        {
            try
            {
                return await dbContext.Locations.Select(t => new LocationModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Code = t.Code
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveLocation(long id)
        {
            try
            {
                var isExists = await dbContext.Locations.Where(i => i.Id == id).FirstOrDefaultAsync();
                if (isExists != null)
                {
                    dbContext.Locations.Remove(isExists);
                }

                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateLocation(LocationModel location)
        {
            try
            {
                var entity = await dbContext.Locations.FindAsync(location.Id);

                if (entity != null)
                {
                    entity.Name = location.Name;
                    entity.Code = location.Code;                    
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
