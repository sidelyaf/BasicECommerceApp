using BasicEcommerce.Domain.Entities;

namespace BasicEcommerce.Domain.Interfaces;

public interface IOrderRepository
{
    Task CreateOrderAsync(Order order);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
}

