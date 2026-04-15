using ManagementSystemAPI.Core.Models;
using ManagementSystemAPI.Core.Models.Domain;

namespace ManagementSystemAPI.Data.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task<Product> Create(Product product);
        Task<Product?> Update(Product product);
        Task<bool> Delete(int id);
    }
}