using System.Threading;
using System;
using Xunit;
using JKOPay.Calculator.Application.Features.CalculateWeatherCoins;
using Moq;
using System.Threading.Tasks;
using JKOPay.Calculator.Application.Constracts.Infrastructure.Weather;
using JKOPay.Calculator.Domain;
using JKOPay.Calculator.Application.Constracts.Infrastructure.Message;

namespace JKOPay.Calculator.Application.Tests.Features.CalculateWeatherCoins
{
    public class CalculateWeatherCoinsQueryTests
    {
        [Fact]
        public async Task CalculateWeatherCoinsQuery_輸入小於0街口幣_噴Exception()
        {
            //Arrange
            var query = new CalculateWeatherCoinsQuery
            {
                JKOSRedeemAmount = -1
            };

            // Mock流程中使用到的Class&Method
            var mockWeatherService = new Mock<IWeatherService>();
            var mockDiscounService = new Mock<IDiscounService>();
            var mockAlertService = new Mock<IAllertService>();

            var handler = new CalculateWeatherCoinsQueryHandler(mockWeatherService.Object, mockDiscounService.Object, mockAlertService.Object);

            //Act
            var exception = await Assert.ThrowsAsync<Exception>(async () =>
            {
                await handler.Handle(query, new CancellationToken());
            });

            //Assert
            Assert.Equal("傳入街口幣異常 不得小於0", exception.Message);
        }

        [Fact]
        public async Task CalculateWeatherCoinsQuery_輸入正確_計算出天氣幣回饋()
        {
            //Arrange
            var query = new CalculateWeatherCoinsQuery
            {
                JKOSRedeemAmount = 10                       //輸入街口幣10
            };
            decimal expectedWeatherCoinsGains = 5;          //預期天氣幣回饋為5

            // Mock流程中使用到的Class&Method
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(x => x.取得近期下雨機率()).ReturnsAsync(50);       //模擬取得近期下雨機率為50

            var mockDiscounService = new Mock<IDiscounService>();
            mockDiscounService.Setup(x => x.GetWeatherDiscoun(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(5);       //模擬計算天氣幣回饋為5

            var mockAlertService = new Mock<IAllertService>();

            var handler = new CalculateWeatherCoinsQueryHandler(mockWeatherService.Object, mockDiscounService.Object, mockAlertService.Object);

            //Act
            var actureResult = await handler.Handle(query, new CancellationToken());

            //Assert
            Assert.Equal(expectedWeatherCoinsGains, actureResult.ResultObject.WeatherCoinsGains);
        }

        [Fact]
        public async Task CalculateWeatherCoinsQuery_天氣幣回饋大於5000_需觸發Allert()
        {
            //Arrange
            var query = new CalculateWeatherCoinsQuery
            {
                JKOSRedeemAmount = It.IsAny<decimal>()                       //輸入街口幣10
            };
            decimal discountServiceReturn = 5001;          //設定折扣服務回傳值

            // Mock流程中使用到的Class&Method
            var mockWeatherService = new Mock<IWeatherService>();
            var mockDiscounService = new Mock<IDiscounService>();
            mockDiscounService.Setup(x => x.GetWeatherDiscoun(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(discountServiceReturn);
            var mockAlertService = new Mock<IAllertService>();

            var handler = new CalculateWeatherCoinsQueryHandler(mockWeatherService.Object, mockDiscounService.Object, mockAlertService.Object);

            //Act
            var actureResult = await handler.Handle(query, new CancellationToken());

            //Assert
            mockAlertService.Verify(x => x.SendAlertToQueue("有大額天氣幣產生!請注意"), Times.Once);
        }

        [Fact]
        public async Task CalculateWeatherCoinsQuery_天氣幣回饋不大於5000_不能觸發Allert()
        {
            //Arrange
            var query = new CalculateWeatherCoinsQuery
            {
                JKOSRedeemAmount = It.IsAny<decimal>()                       //輸入街口幣10
            };
            decimal discountServiceReturn = 5000;          //設定折扣服務回傳值

            // Mock流程中使用到的Class&Method
            var mockWeatherService = new Mock<IWeatherService>();
            var mockDiscounService = new Mock<IDiscounService>();
            mockDiscounService.Setup(x => x.GetWeatherDiscoun(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(discountServiceReturn);
            var mockAlertService = new Mock<IAllertService>();

            var handler = new CalculateWeatherCoinsQueryHandler(mockWeatherService.Object, mockDiscounService.Object, mockAlertService.Object);

            //Act
            var actureResult = await handler.Handle(query, new CancellationToken());

            //Assert
            mockAlertService.Verify(x => x.SendAlertToQueue("有大額天氣幣產生!請注意"), Times.Never);
        }
    }
}