using JKOPay.Calculator.Application.Constracts.Infrastructure.Weather;
using JKOPay.Calculator.Application.Features.CalculateWeatherCoins;
using JKOPay.Calculator.Infrastructure.Weather;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JKOPay.Calculator.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
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
