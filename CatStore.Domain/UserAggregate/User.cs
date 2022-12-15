using CatStore.Domain.UserAggregate.Enums;

namespace CatStore.Domain.UserAggregate;

public class User
{
    public Guid Id { get; private set; }
    
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Password { get; private set; }
    
    public Balance Balance { get; private set; }
    
    public Role Role { get; private set; }
    
    public DateTime CreatedDateTime { get; private set; }
    
    public DateTime UpdatedDateTime { get; private set; }
    
    private User(Guid id, string firstName, string lastName, string email, string password, 
        Balance balance, Role role, DateTime createdDateTime, DateTime updatedDateTime)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Balance = balance;
        Role = role;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    
    public static User Create(string firstName, string lastName, string email, string password, Balance balance, Role role) =>
        new(Guid.NewGuid(), firstName, lastName, email, password, balance, role, DateTime.UtcNow, DateTime.UtcNow);
    
    public User Update(string firstName, string lastName, string email, Balance balance)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Balance = balance;
        UpdatedDateTime = DateTime.Now;
        
        return this;
    }
    
}