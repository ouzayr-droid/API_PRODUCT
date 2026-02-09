using System.ComponentModel.DataAnnotations;

namespace API_PRODUCT.Application.DTOs;

public class ChangePriceRequest
{
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal NewPrice { get; set; }
}