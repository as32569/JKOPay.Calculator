using JKOPay.Calculator.Application.Constracts.Infrastructure.Weather;
using JKOPay.Calculator.Application.Features.CalculateWeatherCoins;
using JKOPay.Calculator.Infrastructure.Weather;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JKOPay.Calculator.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountCalculatorController : ControllerBase
    {
        private readonly ILogger<DiscountCalculatorController> _logger;
        private readonly IMediator _mediator;

        public DiscountCalculatorController(ILogger<DiscountCalculatorController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator=mediator;
        }


        [HttpGet("CalculateWeatherCoins")]
        public async Task<IActionResult> CalculateWeatherCoins([FromQuery] CalculateWeatherCoinsQuery calculateWeatherCoinsQuery)
        {
            var result = await _mediator.Send(calculateWeatherCoinsQuery);
            return Ok(result);
        }
    }
}
