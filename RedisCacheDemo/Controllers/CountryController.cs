using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using RedisCacheDemo.Models;
using RedisCacheDemo.Services.Abstractions;
using RedisCacheDemo.Utils;

namespace RedisCacheDemo.Controllers;

[ApiController]
[Route("countries")]
[OutputCache(PolicyName = Constants.LongTimeCache)]
public class CountryController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;

    public CountryController(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    [HttpGet("list")]
    public List<Country> GetCountries() => _countryRepository.GetCountries();

    [HttpGet("list-codes")]
    public List<string> GetCountryCodes() => _countryRepository.GetCountryCodes();

    [HttpGet("list-names")]
    public List<string> GetCountryNames() => _countryRepository.GetCountryNames();

    [HttpGet("{countryCode}/capital")]
    public string? GetCapital(string countryCode) => _countryRepository.GetCapital(countryCode);
}