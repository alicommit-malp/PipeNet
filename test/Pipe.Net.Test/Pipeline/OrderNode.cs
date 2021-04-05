using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Pipe.Net.Test.Pipeline
{
    public class OrderNode : Node<OrderData>
    {
        public override Task InvokeAsync(OrderData data)
        {
            PipeTest.Logger.LogTrace(nameof(OrderNode));

            data.State = nameof(OrderNode);

            PipeTest.Logger.LogInformation($"State:{nameof(OrderNode)} objectState: " +
                                       $"{JsonConvert.SerializeObject(data)}");

            return Task.CompletedTask;
        }
    }
}