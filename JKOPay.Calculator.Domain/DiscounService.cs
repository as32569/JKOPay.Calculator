namespace JKOPay.Calculator.Domain;

public class DiscounService : IDiscounService
{
    public decimal GetWeatherDiscoun(decimal jkosRedeemAmount, decimal rainPercentage)
    {
        if (jkosRedeemAmount<0) throw new Exception("街口幣 不得小於0");

        if (rainPercentage<0) throw new Exception("降雨機率 不得小於0");

        if (rainPercentage>100) throw new Exception("降雨機率 不得大於100");

        //計算天氣因素回饋金額
        var _finalAmount = jkosRedeemAmount * (rainPercentage/100);

        //四捨五入
        var finalAmount = Math.Round(_finalAmount, 0, MidpointRounding.AwayFromZero);

        return finalAmount;
    }
}
