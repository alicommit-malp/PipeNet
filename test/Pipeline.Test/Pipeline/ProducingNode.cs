using System.Threading.Tasks;

namespace Pipe.Net.Test.Pipeline
{
    public class ProducingNode : Node<OrderData>
    {
        public override Task InvokeAsync(OrderData data)
        {
            data.State = nameof(ProducingNode);
            return Task.CompletedTask;
        }
    }
}