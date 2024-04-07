using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKOPay.Calculator.Application.Constracts.Infrastructure.Weather;

public interface IWeatherService
{
    public Task<decimal> 取得近期下雨機率();
}
