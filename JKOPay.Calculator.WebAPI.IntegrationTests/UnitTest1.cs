using JKOPay.Calculator.Application.Features.CalculateWeatherCoins;
using JKOPay.Calculator.Application.Responses;
using JKOPay.Calculator.Infrastructure.Weather;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace JKOPay.Calculator.WebAPI.IntegrationTests
{
    public class UnitTest1 : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program>
            _factory;
        public UnitTest1(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task CalculateWeatherCoins_�I�sAPI_�s�b��EndPoint()
        {
            //Arrange
            string endPoint = "/api/DiscountCalculator/CalculateWeatherCoins";
            var queryBuilder = new QueryBuilder();
            queryBuilder.Add("JKOSRedeemAmount", "100");

            var url = $"{endPoint}{queryBuilder.ToQueryString().Value}";

            //Act
            var response = await _client.GetAsync(url);

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CalculateWeatherCoins_�I�s���\_�^��Json�PModel�w�q�۲�()
        {
            //Arrange
            string endPoint = "/api/DiscountCalculator/CalculateWeatherCoins";
            var queryBuilder = new QueryBuilder();
            queryBuilder.Add("JKOSRedeemAmount", "100");

            var url = $"{endPoint}{queryBuilder.ToQueryString().Value}";

            //Act
            var response = await _client.GetAsync(url);

            //Response �� Model
            string responseBody = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<BaseResponse<CalculateWeatherCoinsQueryDTO>>(responseBody);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async Task CalculateWeatherCoins_�I�s���\_ResultCode���T()
        {
            //Arrange
            string endPoint = "/api/DiscountCalculator/CalculateWeatherCoins";
            var queryBuilder = new QueryBuilder();
            queryBuilder.Add("JKOSRedeemAmount", "100");

            var url = $"{endPoint}{queryBuilder.ToQueryString().Value}";

            //Act
            var response = await _client.GetAsync(url);

            //Response �� Model
            string responseBody = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<BaseResponse<CalculateWeatherCoinsQueryDTO>>(responseBody);

            //Assert 
            Assert.Equal("00-AA-0000", model.Result);
        }
    }
}