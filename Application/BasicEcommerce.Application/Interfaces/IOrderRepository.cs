namespace BasicEcommerce.Application.Interfaces;

public interface IOrderRepository
{
    Task CreateOrderAsync(Order order);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
}

