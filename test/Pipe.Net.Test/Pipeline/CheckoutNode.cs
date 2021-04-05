using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Pipe.Net.Test.Pipeline
{
    public class CheckoutNode : Node<OrderData>
    {
        public override Task InvokeAsync(OrderData data)
        {
            PipeTest.Logger.LogTrace(nameof(CheckoutNode));

            data.State = nameof(CheckoutNode);

            PipeTest.Logger.LogInformation($"State:{nameof(CheckoutNode)} objectState: " +
                                       $"{JsonConvert.SerializeObject(data)}");

            return Task.CompletedTask;
        }
    }
}