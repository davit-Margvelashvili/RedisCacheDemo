using RedisCacheDemo.Models;
using RedisCacheDemo.Services.Abstractions;

namespace RedisCacheDemo.Services.Implementations;

public class InMemoryBalanceService : IBalanceService
{
    private static readonly Random Random = new();

    public Balance? GetBalanceForCustomer(int customerId) => customerId switch
    {
        1 => new Balance(Random.Next(99999, 999999) * 0.01m, "GEL"),
        2 => new Balance(Random.Next(99999, 999999) * 0.01m, "USD"),
        3 => new Balance(Random.Next(99999, 999999) * 0.01m, "EUR"),
        _ => null
    };
}