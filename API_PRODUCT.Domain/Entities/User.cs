namespace API_PRODUCT.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Nom {get; private set;}
    public string Prenom {get; private set;}
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }

    public User(Guid id, string nom, string prenom, string email, string passwordHash)
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        Email = email;
        PasswordHash = passwordHash;
    }
}