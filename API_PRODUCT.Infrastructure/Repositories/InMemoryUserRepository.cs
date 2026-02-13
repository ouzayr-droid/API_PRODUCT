using API_PRODUCT.Domain.Entities;
using API_PRODUCT.Domain.Interfaces;

namespace API_PRODUCT.Infrastructure.Repositories;

public class InMemoryUserRepository: IUserRepository
{
    private static readonly List<User> Users = new();

    public void Add(User user)
        => Users.Add(user);

    public User? GetByEmail(string email)
        => Users.FirstOrDefault(u => u.Email == email);
}