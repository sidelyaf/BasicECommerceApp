namespace BasicEcommerce.Application.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(Order order);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
}
