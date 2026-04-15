using ManagementSystemAPI.Core.Models;

namespace ManagementSystemAPI.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order?> GetById(int id);
        Task<Order> Create(Order order);
        Task<Order?> Update(Order order);
        Task<bool> Delete(int id);
    }
}