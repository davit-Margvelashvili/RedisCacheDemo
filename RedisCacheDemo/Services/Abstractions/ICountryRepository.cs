using RedisCacheDemo.Models;

namespace RedisCacheDemo.Services.Abstractions;

public interface ICountryRepository
{
    List<Country> GetCountries();

    List<string> GetCountryCodes();

    List<string> GetCountryNames();

    string? GetCapital(string countryCode);
}