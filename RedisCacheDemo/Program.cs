var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// რედისის დაკონფიგურირება
builder.Services.AddStackExchangeRedisOutputCache(options => options.Configuration = builder.Configuration["RedisCacheUrl"]);

// პოლისის განსაზღვრა.
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder =>
        builder.Expire(TimeSpan.FromSeconds(10)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware-ი უნდა იყოს UseHttpsRedirection-ის შემდეგ და UseAuthorization ან/და MapControllers-Middleware-ებს შორის
app.UseOutputCache();

app.UseAuthorization();
app.MapControllers();

app.Run();