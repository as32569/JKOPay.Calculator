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
        public void GetWeatherDiscount_��J���`�ƭ�_�^�ǥ��T�Ѯ���^�X(decimal jkosRedeemAmount, decimal rainPercentage, decimal expectedResult)
        {
            //Arrange
            DiscounService discounService = new DiscounService();

            //Act
            var actureResult = discounService.GetWeatherDiscoun(jkosRedeemAmount, rainPercentage);

            //Assert
            Assert.Equal(expectedResult, actureResult);
        }

        [Theory]
        [InlineData(-1, 50, "��f�� ���o�p��0")]
        [InlineData(10, -1, "���B���v ���o�p��0")]
        [InlineData(10, 101, "���B���v ���o�j��100")]
        public void GetWeatherDiscount_��J���`_�QException(decimal jkosRedeemAmount, decimal rainPercentage, string errorMessage)
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
        //public void GetWeatherDiscount_��J��f���p��0_�QException()
        //{
        //    //Arrange
        //    DiscounService discounService = new DiscounService();

        //    //Act
        //    var exp = Assert.Throws<Exception>(() =>
        //    {
        //        discounService.GetWeatherDiscoun(-1, It.IsAny<decimal>());
        //    });

        //    //Assert
        //    Assert.Equal("��f�� ���o�p��0", exp.Message);
        //}

        //[Fact]
        //public void GetWeatherDiscount_��J���B���v�p��0_�QException()
        //{
        //    //Arrange
        //    DiscounService discounService = new DiscounService();

        //    //Act
        //    var exp = Assert.Throws<Exception>(() =>
        //    {
        //        discounService.GetWeatherDiscoun(It.Is<decimal>(x => x>=0), -1);
        //    });

        //    //Assert
        //    Assert.Equal("���B���v ���o�p��0", exp.Message);
        //}

        //[Fact]
        //public void GetWeatherDiscount_��J���B���v�j��100_�QException()
        //{
        //    //Arrange
        //    DiscounService discounService = new DiscounService();

        //    //Act
        //    var exp = Assert.Throws<Exception>(() =>
        //    {
        //        discounService.GetWeatherDiscoun(It.Is<decimal>(x => x>=0), 101);
        //    });

        //    //Assert
        //    Assert.Equal("���B���v ���o�j��100", exp.Message);
        //}
    }
}