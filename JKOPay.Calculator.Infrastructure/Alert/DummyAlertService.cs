using JKOPay.Calculator.Application.Constracts.Infrastructure.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKOPay.Calculator.Infrastructure.Alert;

public class DummyAlertService : IAllertService
{
    public Task SendAlertToQueue(string message)
    {
        throw new NotImplementedException();
    }
}
