using System.Net;
using API_PRODUCT.Domain.Interfaces;
using API_PRODUCT.Domain.Entities;
using API_PRODUCT.Application.DTOs;

namespace API_PRODUCT.Application.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    { 
        _repository = repository;
    }

    // CREATE
    public void CreateProduct(CreateProductRequest request)
    { 
        var product = new Product(Guid.NewGuid(), request.Name, request.Price, request.IsActive);
        _repository.Add(product);
    }

    // READ - Get by ID
    public ProductDto GetProductById(Guid productId)
    {
        var product = _repository.GetById(productId) 
            ?? throw new ApplicationException("Produit introuvable", HttpStatusCode.NotFound);

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            IsActive = product.IsActive
        };
    }

    // READ - Get all products
    public IEnumerable<ProductDto> GetAllProducts()
    {
        var products = _repository.GetAll();
        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Price = p.Price,
            IsActive = p.IsActive
        });
    }

    // UPDATE - Change price
    public void ChangeProductPrice(Guid productId, ChangePriceRequest request)
    {
        var product = GetProduct(productId);
        product.ChangePrice(request.NewPrice);
        _repository.Update(product);
    }

    // DELETE
    public void DeleteProduct(Guid productId)
    {
        var product = GetProduct(productId);
        _repository.Delete(product.Id);
    }

    // Méthode privée pour récupérer un produit ou lancer une exception
    private Product GetProduct(Guid productId)
    {
        return _repository.GetById(productId) 
            ?? throw new ApplicationException("Produit introuvable", HttpStatusCode.NotFound);
    }
}