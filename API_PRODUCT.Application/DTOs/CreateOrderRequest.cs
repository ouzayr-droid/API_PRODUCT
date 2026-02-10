namespace API_PRODUCT.Application.DTOs;

public class CreateOrderRequest
{
    public List<CreateOrderLineDto> Lines { get; set; } = new();
}

public class CreateOrderLineDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}