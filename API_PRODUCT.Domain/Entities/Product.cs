using API_PRODUCT.Domain.Exceptions;
namespace API_PRODUCT.Domain.Entities;

public class Product
{
    public Guid Id { get; set; } // Identitié
    public decimal Price { get; set; }
    public bool IsActive { get; set; } // false par défaut

    public Product()
    {
        IsActive = true;
    }
    
    // pour l'importation depuis la base
    public Product(Guid id, decimal price, bool isActive)
    {
        Id = id;
        Price = price;
        IsActive = isActive;
    }
    
    public void ChangePrice(decimal newPrice)
    {
        if (newPrice <= 0)
        {
            throw new DomainException("Price cannot be negative");
        }
        
        if (IsActive) throw new DomainException("Product is not active");
        
        Price = newPrice;
        
        
    }
    
    public void applyDiscount(decimal discount)
    {
        if (discount <= 0) throw new DomainException("Discount cannot be negative");
        if (IsActive) throw new DomainException("Product is not active");
    }
}