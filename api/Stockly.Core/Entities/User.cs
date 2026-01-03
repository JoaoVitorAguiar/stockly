using Stockly.Core.Enums;

namespace Stockly.Core.Entities;

public class User: BaseEntity
{
    public User(string name, string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("PasswordHash is required");

        Name = name;
        Email = email;
        Role = Role.CUSTOMER;
        PasswordHash = passwordHash;
    }

    public string Name { get; set; }
    public string Email { get; private set; } 
    public Role Role { get; private set; } 
    public string PasswordHash { get; private set; } 
}
