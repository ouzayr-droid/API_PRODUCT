using API_PRODUCT.Application.DTOs;
using API_PRODUCT.Application.Interfaces;
using API_PRODUCT.Domain.Entities;
using API_PRODUCT.Domain.Interfaces;

namespace API_PRODUCT.Application.Services;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public Guid CreateOrder(CreateOrderRequest dto)
    {
        var order = new Order();

        foreach (var line in dto.Lines)
        {
            order.AddProduct(
                line.ProductId,
                line.ProductName,
                line.UnitPrice,
                line.Quantity);
        }

        order.Confirm();
        _repository.Add(order);

        return order.Id;
    }

    public Order? GetById(Guid id)
        => _repository.GetById(id);
}