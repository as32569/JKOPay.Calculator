using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKOPay.Calculator.Infrastructure.Weather;

public class WeatherForecastResponse
{
    public bool Success { get; set; }
    public ResultData Result { get; set; }
    public RecordsData Records { get; set; }
}

public class ResultData
{
    public string ResourceId { get; set; }
    public List<FieldData> Fields { get; set; }
}

public class FieldData
{
    public string Id { get; set; }
    public string Type { get; set; }
}

public class RecordsData
{
    public string DatasetDescription { get; set; }
    public List<LocationData> Location { get; set; }
}

public class LocationData
{
    public string LocationName { get; set; }
    public List<WeatherElementData> WeatherElement { get; set; }
}

public class WeatherElementData
{
    public string ElementName { get; set; }
    public List<TimeData> Time { get; set; }
}

public class TimeData
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ParameterData Parameter { get; set; }
}

public class ParameterData
{
    public string ParameterName { get; set; }
    public string ParameterUnit { get; set; }
}