using System.Security.Cryptography;
using System.Text;
using API_PRODUCT.Application.DTOs;
using API_PRODUCT.Domain.Entities;
using API_PRODUCT.Domain.Interfaces;

namespace API_PRODUCT.Application.Services;

public class AuthService
{
    private readonly IUserRepository _repository;

    public AuthService(IUserRepository repository)
    {
        _repository = repository;
    }

    public void Register(RegisterRequest request)
    {
        var existingUser = _repository.GetByEmail(request.Email);
        if (existingUser != null)
            throw new Exception("Utilisateur déjà existant");

        var hashedPassword = HashPassword(request.Password);

        var user = new User(Guid.NewGuid(), request.Nom, request.Prenom, request.Email, hashedPassword);
        _repository.Add(user);
    }
    
    public User Login(LoginRequest request)
    {
        var user = _repository.GetByEmail(request.Email)
                   ?? throw new Exception("Utilisateur introuvable");

        var hashedPassword = HashPassword(request.Password);

        if (user.PasswordHash != hashedPassword)
            throw new Exception("Mot de passe invalide");

        return user;
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}