namespace BasicEcommerce.Application.Services;
public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task CreateOrderAsync(Order order)
    {
        // İş mantığı: ürün stok kontrolü vs.
        await _orderRepository.CreateOrderAsync(order);
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllOrdersAsync();
    }
}
