using System.Net;
using API_PRODUCT.Application.DTOs;
using API_PRODUCT.Application.Services;
using API_PRODUCT.Domain.Entities;
using API_PRODUCT.Tests.Fakes;
using Xunit;

namespace API_PRODUCT.Tests.TestsUnit;

public class ProductServiceTests
{
    private readonly FakeProductRepository _repository;
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _repository = new FakeProductRepository();
        _service = new ProductService(_repository);
    }

    [Fact]
    public void CreateProduct_ShouldAddProduct()
    {
        // Arrange
        var request = new CreateProductRequest
        {
            Name = "Produit Test",
            Price = 10,
            IsActive = true
        };

        // Act
        _service.CreateProduct(request);

        // Assert
        var products = _repository.GetAll();
        Assert.Single(products);
    }
    
    [Fact]
    public void GetProductById_ShouldReturnProduct_WhenExists()
    {
        // Arrange
        var product = new Product(Guid.NewGuid(), "Produit A", 20, true);
        _repository.Add(product);

        // Act
        var result = _service.GetProductById(product.Id);

        // Assert
        Assert.Equal(product.Id, result.Id);
        Assert.Equal(product.Name, result.Name);
        Assert.Equal(product.Price, result.Price);
        Assert.True(result.IsActive);
    }
    
    [Fact]
    public void GetProductById_ShouldThrowException_WhenNotFound()
    {
        // Act & Assert
        var exception = Assert.Throws<ApplicationException>(() =>
            _service.GetProductById(Guid.NewGuid()));

        Assert.Equal(HttpStatusCode.NotFound, exception.StatusCode);
    }

    [Fact]
    public void GetAllProducts_ShouldReturnAllProducts()
    {
        // Arrange
        _repository.Add(new Product(Guid.NewGuid(), "P1", 5, true));
        _repository.Add(new Product(Guid.NewGuid(), "P2", 15, false));

        // Act
        var result = _service.GetAllProducts();

        // Assert
        Assert.Equal(2, result.Count());
    }
    
    [Fact]
    public void ChangeProductPrice_ShouldUpdatePrice()
    {
        // Arrange
        var product = new Product(Guid.NewGuid(), "Produit Prix", 10, true);
        _repository.Add(product);

        var request = new ChangePriceRequest
        {
            NewPrice = 25
        };

        // Act
        _service.ChangeProductPrice(product.Id, request);

        // Assert
        var updatedProduct = _repository.GetById(product.Id);
        Assert.Equal(25, updatedProduct!.Price);
    }
    
    [Fact]
    public void DeleteProduct_ShouldRemoveProduct()
    {
        // Arrange
        var product = new Product(Guid.NewGuid(), "Produit Supprimé", 30, true);
        _repository.Add(product);

        // Act
        _service.DeleteProduct(product.Id);

        // Assert
        Assert.Empty(_repository.GetAll());
    }
}