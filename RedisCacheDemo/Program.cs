﻿using Microsoft.OpenApi.Models;
using RedisCacheDemo.Services.Abstractions;
using RedisCacheDemo.Services.Implementations;
using RedisCacheDemo.Utils;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Redis Cache Demo API", Version = "v1" });
    c.ExampleFilters();
});
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
builder.Services.AddSingleton<ICountryRepository, InMemoryCountryRepository>();
builder.Services.AddSingleton<IBalanceService, InMemoryBalanceService>();

// რედისის დაკონფიგურირება
builder.Services.AddStackExchangeRedisOutputCache(options =>
{
    //// მარტივი კონფიგურაცია connection string-ის გამოყენებით
    //options.Configuration = builder.Configuration["RedisCacheUrl"];

    // კომპლექსური კონფიგურაცია
    options.ConfigurationOptions = new ConfigurationOptions
    {
        EndPoints = { builder.Configuration["RedisCacheUrl"] },
        ConnectTimeout = 100,
        SyncTimeout = 100
    };
});

// პოლისის განსაზღვრა.
builder.Services.AddOutputCache(options =>
{
    // Default policy
    options.AddBasePolicy(policyBuilder => policyBuilder.Expire(TimeSpan.FromSeconds(20)));

    // Named policies
    options.AddPolicy(Constants.ShortTimeCache, policyBuilder => policyBuilder.Expire(TimeSpan.FromSeconds(5)));
    options.AddPolicy(Constants.LongTimeCache, policyBuilder => policyBuilder.Expire(TimeSpan.FromMinutes(30)));
    options.AddPolicy(Constants.NoCache, policyBuilder => policyBuilder.NoCache());
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