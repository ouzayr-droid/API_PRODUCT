using API_PRODUCT.Domain.Exceptions;

namespace API_PRODUCT.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public OrderStatus Status { get; private set; }

    private readonly List<OrderLine> _lines = new();
    public IReadOnlyCollection<OrderLine> Lines => _lines;

    public decimal Total => _lines.Sum(l => l.Total);

    public Order()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Status = OrderStatus.Created;
    }

    public void AddProduct(Guid productId, string name, decimal unitPrice, int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("La quantité doit être supérieure à zéro.");

        _lines.Add(new OrderLine(productId, name, unitPrice, quantity));
    }
    
    public void Validate()
    {
        if (!_lines.Any())
            throw new DomainException("Une commande doit contenir au moins un produit.");
    }

    public void Confirm()
    {
        Validate();
        Status = OrderStatus.Confirmed;
    }
}