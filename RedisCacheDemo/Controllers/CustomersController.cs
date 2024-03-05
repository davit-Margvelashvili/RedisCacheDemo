using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using RedisCacheDemo.Models;
using RedisCacheDemo.Services.Abstractions;
using RedisCacheDemo.Utils;

namespace RedisCacheDemo.Controllers;

[Route("customers")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomersController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpPost("add")]
    public void AddCustomer(Customer customer)
    {
        _customerRepository.AddCustomer(customer);
    }

    [HttpGet("{customerId}")]
    [OutputCache(PolicyName = Constants.ShortTimeCache)] // ატრიბუტი უზრუნველყოფს ენდპოინტის ქეიშირება
    public Customer? GetCustomerById(int customerId)
    {
        return _customerRepository.GetCustomerById(customerId);
    }

    [HttpPost("update")]
    public void UpdateCustomer(Customer updatedCustomer)
    {
        _customerRepository.UpdateCustomer(updatedCustomer);
    }

    [HttpDelete("{customerId}")]
    public void DeleteCustomer(int customerId)
    {
        _customerRepository.DeleteCustomer(customerId);
    }

    [HttpGet("list")]
    [OutputCache] // ატრიბუტი უზრუნველყოფს ენდპოინტის ქეიშირება
    public List<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAllCustomers();
    }
}