
namespace BasicEcommerce.Infrastructure.Repositories;
public class OrderRepository : IOrderRepository
{
    private readonly BasicEcommerceDbContext _context;

    public OrderRepository(BasicEcommerceDbContext context)
    {
        _context = context;
    }

    public async Task CreateOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }
}
