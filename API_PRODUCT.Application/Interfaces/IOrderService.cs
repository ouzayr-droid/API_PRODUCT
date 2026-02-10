using API_PRODUCT.Application.DTOs;
using API_PRODUCT.Domain.Entities;

namespace API_PRODUCT.Application.Interfaces;

public interface IOrderService
{
    Guid CreateOrder(CreateOrderRequest dto);
    Order? GetById(Guid id);
}