using ProductAssesment.ClientModel;
using ProductAssesment.Models;

namespace ProductAssesment.Interface
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> GetProductById(long id);
        Task<bool> AddProduct(ProductModel product);
        Task<bool> UpdateProduct(ProductModel product);
        Task<bool> RemoveProduct(long id);
    }
}
