using API_PRODUCT.Domain.Interfaces;
using API_PRODUCT.Domain.Entities;

namespace API_PRODUCT.Infrastructure.Repositories;

public class InMemoryOrderRepository: IOrderRepository
{
    private static readonly List<Order> Orders = new();

    public void Add(Order order)
        => Orders.Add(order);

    public Order? GetById(Guid id)
        => Orders.FirstOrDefault(o => o.Id == id);

    public IEnumerable<Order> GetAll()
        => Orders;
}