namespace BasicEcommerce.Domain.Entities;
public class Order : BaseEntity
{

    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
}

