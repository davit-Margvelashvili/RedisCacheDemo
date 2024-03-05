using RedisCacheDemo.Models;
using Swashbuckle.AspNetCore.Filters;

namespace RedisCacheDemo.Examples;

public class CreateCustomerExamples : IExamplesProvider<CreateCustomerRequest>
{
    public CreateCustomerRequest GetExamples() => new()
    {
        Name = "John Smith",
        Email = "John@mail.com"
    };
}

public class UpdateCustomerExamples : IExamplesProvider<Customer>
{
    public Customer GetExamples() => new()
    {
        CustomerId = 1,
        Name = "Martin Smith",
        Email = "Martin@mail.com",
        RegistrationDate = DateTime.Today.AddDays(-3)
    };
}