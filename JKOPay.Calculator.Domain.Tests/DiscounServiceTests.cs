using Moq;
using System;
using Xunit;

namespace JKOPay.Calculator.Domain.Tests
{
    public class DiscounServiceTests
    {
        [Theory]
        [InlineData(10, 10, 1)]
        [InlineData(10, 20, 2)]
        [InlineData(10, 30, 3)]
        [InlineData(10, 40, 4)]
        [InlineData(10, 50, 5)]
        [InlineData(10, 60, 6)]
        [InlineData(10, 70, 7)]
        [InlineData(10, 80, 8)]
        [InlineData(10, 90, 9)]
        [InlineData(10, 100, 10)]
        public void GetWeatherDiscount_輸入正常數值_回傳正確天氣幣回饋(decimal jkosRedeemAmount, decimal rainPercentage, decimal expectedResult)
        {
            //Arrange
            DiscounService discounService = new DiscounService();

            //Act
            var actureResult = discounService.GetWeatherDiscoun(jkosRedeemAmount, rainPercentage);

            //Assert
            Assert.Equal(expectedResult, actureResult);
        }

        [Theory]
        [InlineData(-1, 50, "街口幣 不得小於0")]
        [InlineData(10, -1, "降雨機率 不得小於0")]
        [InlineData(10, 101, "降雨機率 不得大於100")]
        public void GetWeatherDiscount_輸入異常_噴Exception(decimal jkosRedeemAmount, decimal rainPercentage, string errorMessage)
        {
            //Arrange
            DiscounService discounService = new DiscounService();

            //Act
            var exp = Assert.Throws<Exception>(() =>
            {
                discounService.GetWeatherDiscoun(jkosRedeemAmount, rainPercentage);
            });

            //Assert
            Assert.Equal(errorMessage, exp.Message);
        }

        //[Fact]
        //public void GetWeatherDiscount_輸入街口幣小於0_噴Exception()
        //{
        //    //Arrange
        //    DiscounService discounService = new DiscounService();

        //    //Act
        //    var exp = Assert.Throws<Exception>(() =>
        //    {
        //        discounService.GetWeatherDiscoun(-1, It.IsAny<decimal>());
        //    });

        //    //Assert
        //    Assert.Equal("街口幣 不得小於0", exp.Message);
        //}

        //[Fact]
        //public void GetWeatherDiscount_輸入降雨機率小於0_噴Exception()
        //{
        //    //Arrange
        //    DiscounService discounService = new DiscounService();

        //    //Act
        //    var exp = Assert.Throws<Exception>(() =>
        //    {
        //        discounService.GetWeatherDiscoun(It.Is<decimal>(x => x>=0), -1);
        //    });

        //    //Assert
        //    Assert.Equal("降雨機率 不得小於0", exp.Message);
        //}

        //[Fact]
        //public void GetWeatherDiscount_輸入降雨機率大於100_噴Exception()
        //{
        //    //Arrange
        //    DiscounService discounService = new DiscounService();

        //    //Act
        //    var exp = Assert.Throws<Exception>(() =>
        //    {
        //        discounService.GetWeatherDiscoun(It.Is<decimal>(x => x>=0), 101);
        //    });

        //    //Assert
        //    Assert.Equal("降雨機率 不得大於100", exp.Message);
        //}
    }
}