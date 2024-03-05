namespace RedisCacheDemo.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
}