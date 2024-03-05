using RedisCacheDemo.Models;

namespace RedisCacheDemo.Services.Abstractions;

public interface IBalanceService
{
    Balance? GetBalanceForCustomer(int customerId);
}