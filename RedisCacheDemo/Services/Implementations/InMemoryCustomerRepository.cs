using RedisCacheDemo.Models;
using RedisCacheDemo.Services.Abstractions;

namespace RedisCacheDemo.Services.Implementations;

public class InMemoryCustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers;
    private int _nextCustomerId;

    public InMemoryCustomerRepository()
    {
        _customers = new List<Customer>();
        _nextCustomerId = 1; // Initial CustomerId

        AddCustomer(new Customer { Name = "John Doe", Email = "john@example.com", RegistrationDate = DateTime.Now });
        AddCustomer(new Customer { Name = "Jane Smith", Email = "jane@example.com", RegistrationDate = DateTime.Now });
    }

    // Create operation
    public void AddCustomer(Customer customer)
    {
        customer.CustomerId = _nextCustomerId++;
        _customers.Add(customer);
    }

    // Read operation
    public Customer? GetCustomerById(int customerId)
    {
        return _customers.Find(c => c.CustomerId == customerId);
    }

    // Update operation
    public void UpdateCustomer(Customer updatedCustomer)
    {
        int index = _customers.FindIndex(c => c.CustomerId == updatedCustomer.CustomerId);
        if (index != -1)
        {
            _customers[index] = updatedCustomer;
        }
        else
        {
            throw new ArgumentException("Customer not found.");
        }
    }

    // Delete operation
    public void DeleteCustomer(int customerId)
    {
        var customerToRemove = _customers.Find(c => c.CustomerId == customerId);
        if (customerToRemove is not null)
        {
            _customers.Remove(customerToRemove);
        }
        else
        {
            throw new ArgumentException("Customer not found.");
        }
    }

    // Get all customers
    public List<Customer> GetAllCustomers() => _customers.ToList();
}