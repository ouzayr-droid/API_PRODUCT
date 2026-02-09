using Microsoft.EntityFrameworkCore;
using API_PRODUCT.Domain.Interfaces;
using API_PRODUCT.Domain.Entities;
using API_PRODUCT.Infrastructure.Persistence;

namespace API_PRODUCT.Infrastructure.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public Product GetById(Guid id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }
    
    public void Delete(Guid id)
    {
        var product = GetById(id);
        if (product == null) return;

        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}