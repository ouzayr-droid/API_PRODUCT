using API_PRODUCT.Domain.Entities;
namespace API_PRODUCT.Domain.Interfaces;

public interface IProductRepository
{
    Product GetById(Guid id);                   // Read a product 
    IEnumerable<Product> GetAll();              // Read many product
    void Add(Product product);                  // Create
    void Update(Product product);               // Update
    void Delete(Guid id);                       // Delete
    
}