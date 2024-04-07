using Moq;
using System;
using Xunit;

namespace JKOPay.Calculator.Domain.Tests
{
    public class DiscounServiceTests
    {
        [Fact]
        public void GetWeatherDiscount_��J���`�ƭ�_�^�ǥ��T�Ѯ���^�X()
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
        public void GetWeatherDiscount_��J��f���p��0_�QException()
        {
            //Arrange
            DiscounService discounService = new DiscounService();

            //Act
            var exp = Assert.Throws<Exception>(() =>
            {
                discounService.GetWeatherDiscoun(-1, It.IsAny<decimal>());
            });

            //Assert
            Assert.Equal("��f�� ���o�p��0", exp.Message);
        }

        [Fact]
        public void GetWeatherDiscount_��J���B���v�p��0_�QException()
        {
            //Arrange
            DiscounService discounService = new DiscounService();

            //Act
            var exp = Assert.Throws<Exception>(() =>
            {
                discounService.GetWeatherDiscoun(It.Is<decimal>(x => x>=0), -1);
            });

            //Assert
            Assert.Equal("���B���v ���o�p��0", exp.Message);
        }

        [Fact]
        public void GetWeatherDiscount_��J���B���v�j��100_�QException()
        {
            //Arrange
            DiscounService discounService = new DiscounService();

            //Act
            var exp = Assert.Throws<Exception>(() =>
            {
                discounService.GetWeatherDiscoun(It.Is<decimal>(x => x>=0), 101);
            });

            //Assert
            Assert.Equal("���B���v ���o�j��100", exp.Message);
        }
    }
}