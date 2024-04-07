using JKOPay.Calculator.Application.Constracts.Infrastructure.Weather;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKOPay.Calculator.Infrastructure.Weather;

public class CWAWeatherService : IWeatherService
{
    public CWAWeatherService()
    {

    }
    public async Task<decimal> 取得近期下雨機率()
    {
        //string host = "https://opendata.cwa.gov.tw/api/v1/rest/datastore/F-C0032-001?Authorization=CWB-0E47D975-C792-4D68-8CA8-F8AB19948089&format=JSON&locationName=%E8%87%BA%E5%8C%97%E5%B8%82&elementName=PoP";
        string host = "https://opendata.cwa.gov.tw";
        string authorization = "CWB-0E47D975-C792-4D68-8CA8-F8AB19948089";
        string format = "JSON";
        string locationName = "臺北市";
        string elementName = "PoP";

        string api = "/api/v1/rest/datastore/F-C0032-001";

        string url = $"{host}{api}?Authorization={authorization}&format={format}&locationName={locationName}&elementName={elementName}";

        // 建立 HttpClient 物件
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // 發送 GET 請求並取得回應
                HttpResponseMessage response = await client.GetAsync(url);

                // 確認回應是否成功
                response.EnsureSuccessStatusCode();

                // 讀取回應內容
                string responseBody = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<WeatherForecastResponse>(responseBody);

                Console.WriteLine("Response:");
                Console.WriteLine(responseBody);

                var tatgetElement = model.Records.Location[0].WeatherElement.FirstOrDefault(x=>x.ElementName=="PoP");
                var targetTimeRange = tatgetElement.Time.OrderBy(x=>x.StartTime).FirstOrDefault();

                var rainPercentage = decimal.Parse(targetTimeRange.Parameter.ParameterName);
                return rainPercentage;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"出錯啦: {e.Message}");
            }
        }

        return 0;
    }
}
