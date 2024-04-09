using ProductAssesment.ClientModel;

namespace ProductAssesment.Interface
{
    public interface IStkAllocationService
    {
        Task<bool> AddStocktoLocation(StockAllocationModel model);
        Task<bool> UpdateStocktoLocation(StockAllocationModel model);
        Task<bool> RemoveStocktoLocation(StockAllocationModel model);
        Task<List<StockAllocationModel>> GetAllStockAllocationDetails();
    }
}
