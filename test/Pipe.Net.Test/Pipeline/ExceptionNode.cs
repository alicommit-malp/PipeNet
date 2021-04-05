using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Pipe.Net.Test.Pipeline
{
    public class ExceptionNode : Node<OrderData>
    {
        public override Task InvokeAsync(OrderData data)
        {
            PipeTest.Logger.LogTrace(nameof(ExceptionNode));

            data.State = nameof(ExceptionNode);

            PipeTest.Logger.LogInformation($"State:{nameof(ExceptionNode)} objectState: " +
                                            $"{JsonConvert.SerializeObject(data)}");

            throw new Exception("100");
        }
    }
}