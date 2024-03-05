using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using RedisCacheDemo.Models;
using RedisCacheDemo.Services.Abstractions;
using RedisCacheDemo.Utils;

namespace RedisCacheDemo.Controllers;

[Route("Balance")]
[OutputCache(PolicyName = Constants.NoCache)]
public class BalanceController : ControllerBase
{
    private readonly IBalanceService _balanceService;

    public BalanceController(IBalanceService balanceService)
    {
        _balanceService = balanceService;
    }

    [HttpGet("for-customer")]
    public Balance? GetBalanceForCustomer([FromQuery] int customerId) => _balanceService.GetBalanceForCustomer(customerId);
}