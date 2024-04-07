using Moq;
using System;
using Xunit;

namespace JKOPay.Calculator.Domain.Tests
{
    public class DiscounServiceTests
    {
        [Fact]
        public void GetWeatherDiscount_輸入正常數值_回傳正確天氣幣回饋()
        {
            //Arrange
            DiscounService discounService = new DiscounService();
            decimal jkosRedeemAmount = 10;
            decimal rainPercentage = 50;
            decimal expectedResult = 5;

            //Act
            var actureResult = discounService.GetWeatherDiscoun(jkosRedeemAmount, rainPercentage);

            //Assert
            Assert.Equal(expectedResult, actureResult);
        }

        [Fact]
        public void GetWeatherDiscount_輸入街口幣小於0_噴Exception()
        {
            //Arrange
            DiscounService discounService = new DiscounService();

            //Act
            var exp = Assert.Throws<Exception>(() =>
            {
                discounService.GetWeatherDiscoun(-1, It.IsAny<decimal>());
            });

            //Assert
            Assert.Equal("街口幣 不得小於0", exp.Message);
        }

        [Fact]
        public void GetWeatherDiscount_輸入降雨機率小於0_噴Exception()
        {
            //Arrange
            DiscounService discounService = new DiscounService();

            //Act
            var exp = Assert.Throws<Exception>(() =>
            {
                discounService.GetWeatherDiscoun(It.Is<decimal>(x => x>=0), -1);
            });

            //Assert
            Assert.Equal("降雨機率 不得小於0", exp.Message);
        }

        [Fact]
        public void GetWeatherDiscount_輸入降雨機率大於100_噴Exception()
        {
            //Arrange
            DiscounService discounService = new DiscounService();

            //Act
            var exp = Assert.Throws<Exception>(() =>
            {
                discounService.GetWeatherDiscoun(It.Is<decimal>(x => x>=0), 101);
            });

            //Assert
            Assert.Equal("降雨機率 不得大於100", exp.Message);
        }
    }
}