using API_PRODUCT.Domain.Entities;
using API_PRODUCT.Domain.Interfaces;

namespace API_PRODUCT.Tests.Fakes;

public class FakeProductRepository: IProductRepository
{
    private readonly List<Product> _products = new();

    public void Add(Product product)
        => _products.Add(product);

    public Product? GetById(Guid id)
        => _products.FirstOrDefault(p => p.Id == id);

    public IEnumerable<Product> GetAll()
        => _products;

    public void Update(Product product)
    {
        var index = _products.FindIndex(p => p.Id == product.Id);
        if (index >= 0)
            _products[index] = product;
    }

    public void Delete(Guid id)
        => _products.RemoveAll(p => p.Id == id);
}