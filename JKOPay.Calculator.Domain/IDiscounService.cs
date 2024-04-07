namespace JKOPay.Calculator.Domain
{
    public interface IDiscounService
    {
        decimal GetWeatherDiscoun(decimal jkosRedeemAmount, decimal rainPercentage);
    }
}