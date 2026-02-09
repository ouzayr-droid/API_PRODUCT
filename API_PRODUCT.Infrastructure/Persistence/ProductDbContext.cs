using Microsoft.EntityFrameworkCore;
using API_PRODUCT.Domain.Entities;

namespace API_PRODUCT.Infrastructure.Persistence;

public class ProductDbContext: DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}