using JKOPay.Calculator.Application.Constracts.Infrastructure.Weather;
using JKOPay.Calculator.Application.Responses;
using JKOPay.Calculator.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKOPay.Calculator.Application.Features.CalculateWeatherCoins;

public class CalculateWeatherCoinsQuery : IRequest<BaseResponse<CalculateWeatherCoinsQueryDTO>>
{
    public decimal JKOSRedeemAmount { get; set; }
}

public class CalculateWeatherCoinsQueryDTO
{
    public decimal SourceJKOSRedeemAmount { get; set; }
    public decimal RainPercentage { get; set; }
    public decimal WeatherCoinsGains { get; set; }
}

public class CalculateWeatherCoinsQueryHandler : IRequestHandler<CalculateWeatherCoinsQuery, BaseResponse<CalculateWeatherCoinsQueryDTO>>
{
    private readonly IWeatherService _weatherService;
    private readonly DiscounService _discounService;

    public CalculateWeatherCoinsQueryHandler(IWeatherService weatherService)
    {
        _weatherService=weatherService;
        _discounService = new DiscounService();
    }
    public async Task<BaseResponse<CalculateWeatherCoinsQueryDTO>> Handle(CalculateWeatherCoinsQuery request, CancellationToken cancellationToken)
    {
        //驗證Client傳入
        if (request.JKOSRedeemAmount<0)
        {
            throw new Exception("傳入街口幣異常 不得小於0");
        }

        //打三方服務取得降雨機率 EX:50
        var rainPercent = await _weatherService.取得近期下雨機率();

        //由輸入的街口幣 算出天氣幣金額
        var 獲取天氣幣金額 = _discounService.GetWeatherDiscoun(request.JKOSRedeemAmount, rainPercent);

        //組裝回傳DTO
        var returnDto = new CalculateWeatherCoinsQueryDTO
        {
            SourceJKOSRedeemAmount = request.JKOSRedeemAmount,
            RainPercentage = rainPercent,
            WeatherCoinsGains = 獲取天氣幣金額
        };

        //組裝回傳結果
        var response = new BaseResponse<CalculateWeatherCoinsQueryDTO>
        {
            Message="SUCCESS",
            Result = "00-AA-0000",
            ResultObject = returnDto
        };

        return response;
    }
}
