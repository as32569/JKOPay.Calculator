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
        [Given("��f���O (.*) ��")]
        public void GivenTheJKOSRedeemAmount(decimal jkosRedeemAmount)
        {
            //Arrange
            _jkosRedeemAmount = jkosRedeemAmount;
        }

        [Given("���B���v�O (.*) %")]
        public void GivenTheRainPercent(decimal rainPercent)
        {
            //Arrange
            _rainPercent = rainPercent;
        }

        [When("�g�L�Ѯ���޿�p��")]
        public void WhenCalculateWeatherDiscoun()
        {
            //Act
            _result = _discounService.GetWeatherDiscoun(_jkosRedeemAmount, _rainPercent);
        }

        [Then("���o���Ѯ������ (.*) ��")]
        public void ThenTheResultShouldBe(decimal result)
        {
            //Assert
            Assert.Equal(result, _result);
        }
    }
}
