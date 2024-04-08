using System.Security.Permissions;

namespace JKOPay.Calculator.Domain.Specs.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private IDiscounService _discounService = new DiscounService();
        private decimal _jkosRedeemAmount;
        private decimal _rainPercent;
        private decimal _result;

        public CalculatorStepDefinitions()
        {

        }
        [Given("街口幣是 (.*) 元")]
        public void GivenTheJKOSRedeemAmount(decimal jkosRedeemAmount)
        {
            //Arrange
            _jkosRedeemAmount = jkosRedeemAmount;
        }

        [Given("降雨機率是 (.*) %")]
        public void GivenTheRainPercent(decimal rainPercent)
        {
            //Arrange
            _rainPercent = rainPercent;
        }

        [When("經過天氣幣邏輯計算")]
        public void WhenCalculateWeatherDiscoun()
        {
            //Act
            _result = _discounService.GetWeatherDiscoun(_jkosRedeemAmount, _rainPercent);
        }

        [Then("取得的天氣幣應為 (.*) 元")]
        public void ThenTheResultShouldBe(decimal result)
        {
            //Assert
            Assert.Equal(result, _result);
        }
    }
}
