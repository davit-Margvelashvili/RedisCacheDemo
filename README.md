
# Redis Base output caching
### იმისათვის რომ პროექტში Redis Base output caching-ი გამოვიყენოთ შემდეგი ნაბიჯები უნდა გადავდგათ

დავაინსტალიროთ Redis Cache-ი Docker-ზე. ტერმინალში გავუშვათ შემდეგი ბრძანებები
```
docker pull redis
```
```
docker run -d -p 6379:6379 --name local-redis  redis
```
გადმოვწეროთ nuget პაკეტი  `Microsoft.AspNetCore.OutputCaching.StackExchangeRedis`. ამისათვის Package Manager Console-ში გავუშვათ შემდეგი ბრძანება
```
Install-Package Microsoft.AspNetCore.OutputCaching.StackExchangeRedis -Version 8.0.2
```
`appsettings.json` ფაილში გავწეროთ რედისის მისამართი
 
```
	"RedisCacheUrl": "127.0.0.1:6379"
```

`Program.cs`-ში DI კონტეინერში დავარეგისტრიროთ რედისის ქეში და განვსაზღვროთ ქეშირების პოლისი

```
builder.Services.AddStackExchangeRedisOutputCache(options => options.Configuration = builder.Configuration["RedisCacheUrl"]);
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder =>
        builder.Expire(TimeSpan.FromSeconds(10)));
});
```
HttpsRedirection middleware-სა და Authorization ან/და MapControllers middleware-ებს შორის დავარეგისტრიროთ OutputCache middleware-ი

```
app.UseOutputCache();
```
ენდპოინტს რომლის ქეშირებაც გვინდა დავადოთ  `[OutputCache]` ატრიბუტი
```
[HttpGet(Name = "GetWeatherForecast")]
[OutputCache]
public IEnumerable<WeatherForecast> Get()
{
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })
    .ToArray();
}
```

