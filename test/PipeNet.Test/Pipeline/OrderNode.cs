using System.Threading.Tasks;

namespace PipeNet.Test.Pipeline
{
    public class OrderNode : Node<OrderData>
    {
        public override Task InvokeAsync(OrderData data)
        {
            data.State = nameof(OrderNode);
            return Task.CompletedTask;
        }
    }
}