﻿using RedisCacheDemo.Models;

namespace RedisCacheDemo.Services.Abstractions;

public interface ICustomerRepository
{
    void AddCustomer(CreateCustomerRequest customer);

    Customer? GetCustomerById(int customerId);

    void UpdateCustomer(Customer updatedCustomer);

    void DeleteCustomer(int customerId);

    List<Customer> GetAllCustomers();
}