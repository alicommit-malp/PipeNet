using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Pipe.Net.Test.Pipeline
{
    public class ProducingNode : Node<OrderData>
    {
        public override Task InvokeAsync(OrderData data)
        {
            PipeTest.Logger.LogTrace(nameof(ProducingNode));

            data.State = nameof(ProducingNode);

            PipeTest.Logger.LogInformation(message: $"State:{nameof(ProducingNode)} objectState: " +
                                                     $"{JsonConvert.SerializeObject(data)}");

            return Task.CompletedTask;
        }
    }
}