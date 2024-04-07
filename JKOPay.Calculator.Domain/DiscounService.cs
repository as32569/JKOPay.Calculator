namespace JKOPay.Calculator.Domain;

public class DiscounService
{
    public decimal GetWeatherDiscoun(decimal jkosRedeemAmount, decimal rainPercentage)
    {
        //計算天氣因素回饋金額
        var _finalAmount = jkosRedeemAmount * (rainPercentage/100);

        //四捨五入
        var finalAmount = Math.Round(_finalAmount, 0, MidpointRounding.AwayFromZero);

        return finalAmount;
    }
}
