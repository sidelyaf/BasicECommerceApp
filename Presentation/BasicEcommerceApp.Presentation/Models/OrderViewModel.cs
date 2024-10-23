using BasicEcommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BasicEcommerceApp.Presentation.Models;
public class OrderViewModel
{
    public IEnumerable<Product>? Products { get; set; }

    [Required]
    [Display(Name = "Product")]
    public Guid ProductId { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Please enter a quantity between 1 and 100")]
    public int Quantity { get; set; }

    [Required]
    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; }
}
