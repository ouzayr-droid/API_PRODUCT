using API_PRODUCT.Domain.Exceptions;
namespace API_PRODUCT.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } // Identité
    public string Name { get; set; }
    public decimal Price { get; private set; }
    public bool IsActive { get; private set; } // false par défaut

    // constructeur par défaut
    public Product()
    {
        Id = Guid.NewGuid();
        Price = 0;
        IsActive = true;
    }

    // constructeur avec validation
    public Product(Guid id, string name, decimal price, bool isActive = true)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name cannot be empty");
        
        if (price <= 0)
            throw new DomainException("Price must be greater than 0");

        Id = id;
        Name = name;
        Price = price;
        IsActive = isActive;
    }
    
    // Changer le prix d'un produit
    public void ChangePrice(decimal newPrice)
    {
        if (!IsActive)
            throw new DomainException("Cannot change price of inactive product");

        if (newPrice <= 0)
            throw new DomainException("Price must be greater than 0");

        Price = newPrice;
    }

    // Appliquer une remise sur le produit
    public void ApplyDiscount(decimal discount)
    {
        if (!IsActive)
            throw new DomainException("Cannot apply discount to inactive product");

        if (discount <= 0)
            throw new DomainException("Discount must be greater than 0");

        if (discount >= Price)
            throw new DomainException("Discount cannot be greater than or equal to the price");

        Price -= discount;
    }
    
    // Activer le produit
    public void Activate()
    {
        IsActive = true;
    }

    // Désactiver le produit
    public void Deactivate()
    {
        IsActive = false;
    }
}