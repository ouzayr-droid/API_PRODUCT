namespace API_PRODUCT.Application.DTOs;

public class CreateProductRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
}