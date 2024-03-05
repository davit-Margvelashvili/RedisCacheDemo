namespace RedisCacheDemo.Models;

public class Country
{
    public string IsoCode { get; set; }
    public string Name { get; set; }
    public string Capital { get; set; }
    public string Continent { get; set; }

    public Country(string isoCode, string name, string capital, string continent)
    {
        IsoCode = isoCode;
        Name = name;
        Capital = capital;
        Continent = continent;
    }

    public Country()
    { }
}