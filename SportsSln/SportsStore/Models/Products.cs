using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models;

public class Product
{
    public long? ProductID { get; set; }
    [Required(ErrorMessage = "Please enter a product name")]
    public string Name { get; set; } = String.Empty;
    [Required(ErrorMessage = "Please enter a description")]
    public string Description { get; set; } = String.Empty;
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
    public decimal Price { get; set; }
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive quantity")]
    public int Quantity { get; set; }
    [Required(ErrorMessage = "Please specify a category")]
    public string Category { get; set; } = String.Empty;
}