using Microsoft.EntityFrameworkCore;
using ManagementSystemAPI.Core.Models;
using System;

namespace ManagementSystemAPI.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAll()
            => await _context.Orders.ToListAsync();

        public async Task<Order?> GetById(int id)
            => await _context.Orders.FindAsync(id);

        public async Task<Order> Create(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> Update(Order order)
        {
            var existing = await _context.Orders.FindAsync(order.Id);
            if (existing == null) return null;

            existing.UserId = order.UserId;
            existing.Total = order.Total;
            existing.Status = order.Status;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}