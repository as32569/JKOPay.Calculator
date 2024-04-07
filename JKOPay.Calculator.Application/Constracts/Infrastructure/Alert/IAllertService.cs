using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKOPay.Calculator.Application.Constracts.Infrastructure.Message
{
    public interface IAllertService
    {
        public Task SendAlertToQueue(string message);
    }
}
