using API_PRODUCT.Infrastructure.Repositories;
using API_PRODUCT.Application.Services;
using API_PRODUCT.Application.DTOs;

namespace API_PRODUCT.Tests.TestsUnit;

public class OrderServiceTests
{
    [Fact]
    public void CreateOrder_ShouldCreateOrder_WhenValid()
    {
        var repo = new InMemoryOrderRepository();
        var service = new OrderService(repo);

        var dto = new CreateOrderRequest
        {
            Lines =
            {
                new CreateOrderLineDto
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Produit A",
                    UnitPrice = 10,
                    Quantity = 2
                }
            }
        };

        var id = service.CreateOrder(dto);

        Assert.NotEqual(Guid.Empty, id);
    }
}



