using RedisCacheDemo.Models;
using RedisCacheDemo.Services.Abstractions;

namespace RedisCacheDemo.Services.Implementations;

public class InMemoryCountryRepository : ICountryRepository
{
    private static readonly List<Country> Countries = new List<Country>
    {
        new Country("US", "United States", "Washington, D.C.", "North America"),
        new Country("CA", "Canada", "Ottawa", "North America"),
        new Country("GB", "United Kingdom", "London", "Europe"),
        new Country("FR", "France", "Paris", "Europe"),
    };

    public List<Country> GetCountries() => Countries.ToList();

    public List<string> GetCountryCodes() => Countries.Select(x => x.IsoCode).ToList();

    public List<string> GetCountryNames() => Countries.Select(x => x.Name).ToList();

    public string? GetCapital(string countryCode) => Countries.Find(x => x.IsoCode == countryCode)?.Capital;
}