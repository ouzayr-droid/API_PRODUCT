using API_PRODUCT.Domain.Entities;

namespace API_PRODUCT.Domain.Interfaces;

public interface IUserRepository
{
    void Add(User user);
    User? GetByEmail(string email);
}