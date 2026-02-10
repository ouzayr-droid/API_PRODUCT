using API_PRODUCT.Domain.Entities;

namespace API_PRODUCT.Domain.Interfaces;

public interface IOrderRepository
{
    void Add(Order order);
    Order? GetById(Guid id);
    IEnumerable<Order> GetAll();
}