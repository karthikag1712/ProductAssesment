using ProductAssesment.ClientModel;

namespace ProductAssesment.Interface
{
    public interface ILocationService
    {
        Task<List<LocationModel>> GetLocations();
        Task<LocationModel> GetLocationById(long id);
        Task<bool> AddLocation(LocationModel location);
        Task<bool> UpdateLocation(LocationModel location);
        Task<bool> RemoveLocation(long id);
    }
}
