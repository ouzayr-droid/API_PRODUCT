using API_PRODUCT.Application.Services;
using API_PRODUCT.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API_PRODUCT.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController: ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _service.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var product = _service.GetProductById(id);
        return Ok(product);
    }
    [HttpPost]
    public IActionResult Create([FromBody] CreateProductRequest request)
    {
        _service.CreateProduct(request);
        return Ok();
    }

    [HttpPut("{id}/price")]
    public IActionResult ChangePrice(Guid id, [FromBody] ChangePriceRequest request)
    {
        _service.ChangeProductPrice(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _service.DeleteProduct(id);
        return Ok();
    }
}