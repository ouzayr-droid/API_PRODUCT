using API_PRODUCT.Application.DTOs;
using API_PRODUCT.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_PRODUCT.Controllers;

[Authorize]
[ApiController]
[Route("api/orders")]
public class OrderController: ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(CreateOrderRequest dto)
    {
        var id = _service.CreateOrder(dto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var order = _service.GetById(id);
        return order is null ? NotFound() : Ok(order);
    }
}