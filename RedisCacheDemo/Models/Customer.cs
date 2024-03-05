namespace RedisCacheDemo.Models;

public class CreateCustomerRequest
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}

public class Customer
{
    public int CustomerId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
}