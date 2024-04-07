using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKOPay.Calculator.Application.Responses;

public class BaseResponse
{
    public string Result { get; set; } = "";
    public string Message { get; set; } = "";
    public object? ResultObject { get; set; }
}

public class BaseResponse<T> : BaseResponse
{
    public new T? ResultObject { get; set; }
}
