using API_PRODUCT.Domain.Exceptions;

namespace API_PRODUCT.Domain.Entities;

public class OrderLine
{
    public Guid ProductId { get; }
    public string ProductName { get; }
    public decimal UnitPrice { get; }
    public int Quantity { get; }
    public decimal Total => UnitPrice * Quantity;

    public OrderLine(Guid productId, string productName, decimal unitPrice, int quantity)
    {
        if (unitPrice <= 0)
            throw new DomainException("Prix invalide.");

        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}